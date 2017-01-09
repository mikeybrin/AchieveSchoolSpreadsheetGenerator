using SchoolClubSpreadsheetPopulator.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace SchoolClubSpreadsheetPopulator
{
    /// <summary>
    /// Interaction logic for ucUpload.xaml
    /// </summary>
    public partial class ucUpload : UserControl
    {
        public delegate void GenerateSpreadsheetDelegate(Dictionary<string, Country> SchoolAndStudentData, int totalSpreadsheetsToGenerate);
        internal event GenerateSpreadsheetDelegate btnGenerateSpreadsheetClickEventHandler;

        private int _countriesLocated = 0;
        private int _schoolsLocated = 0;
        private int _studentsLocated = 0;
        private int _spreadsheetsToGenerate;
        private List<string> _errors = new List<string>();
        private List<string> _mappingErrors = new List<string>();

        private const string FileUploadFilter = "Excel 2010|*.xlsx|Excel|*.xls|Text documents (.txt)|*.txt|CSV files (*.csv)|*.csv";

        public Dictionary<string, Country> _schoolAndStudentData = new Dictionary<string, Country>();

        public ucUpload()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            btnValidate.Visibility = Visibility.Hidden;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.Filter = FileUploadFilter;

            // Display OpenFileDialog by calling ShowDialog method
            bool? result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                txtFileName.Text = filename;

                btnValidate.Visibility = Visibility.Visible;
            }
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            _schoolAndStudentData = new Dictionary<string, Country>();
            _countriesLocated = 0;
            _schoolsLocated = 0;
            _studentsLocated = 0;
            _errors = new List<string>();

            if (!string.IsNullOrEmpty(txtFileName.Text))
            {
                var filePath = txtFileName.Text;

                progressIndicator.IsBusy = true;

                // exspensive process reading excel files (much better if they wee CSV!) so lets start a background task to read it.
                Task.Factory.StartNew(() =>
                {
                    ReadFileContents(filePath);

                    if (!_schoolAndStudentData.Any() && !_mappingErrors.Any())
                    {
                        _errors.Add("The file has no data!");
                    }
                })
                .ContinueWith((task) =>
                {
                    // file has been read let's show the results
                    progressIndicator.IsBusy = false;
                    spUpload.Visibility = Visibility.Collapsed;
                    btnValidate.Visibility = Visibility.Collapsed;
                    spResult.Visibility = Visibility.Visible;
                    lblValidationResult.Visibility = Visibility.Visible;

                    if (!_mappingErrors.Any())
                    {
                        lblValidationResult.Text = $"Countries located = {_countriesLocated}, Schools located = {_schoolsLocated}, Students located = {_studentsLocated}{Environment.NewLine}Total spreadsheets to generate: {_spreadsheetsToGenerate}";
                    }
                    else
                    {
                        lblErrors.Content = $"Mapping file has errors";
                        lbErrors.Visibility = Visibility.Visible;
                        spResult.Visibility = Visibility.Visible;
                        btnProceed.Visibility = Visibility.Hidden;
                        spErrors.Visibility = Visibility.Visible;

                        foreach (var error in _mappingErrors)
                        {
                            lbErrors.Items.Add(new ListBoxItem { Content = error });
                        }
                    }

                    if (_errors.Any())
                    {
                        spErrors.Visibility = Visibility.Visible;
                        lbErrors.Visibility = Visibility.Visible;

                        foreach (var error in _errors)
                        {
                            lbErrors.Items.Add(new ListBoxItem { Content = error });
                        }

                        
                    }

                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                MessageBox.Show("Please select a file", "No file", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void ReadFileContents(string filePath)
        {
            Dispatcher.Invoke(() =>
            {
                spUpload.Visibility = Visibility.Collapsed;
                progressIndicator.BusyContent = $"Reading mappings file";
                btnValidate.Content = "Validating...";
            });

            XmlSerializer ser = new XmlSerializer(typeof(mappings));
            mappings mappings;
            using (XmlReader reader = XmlReader.Create(Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["PrincessTrustRootDirectory"], System.Configuration.ConfigurationSettings.AppSettings["MappingsFilePathDirectory"], System.Configuration.ConfigurationSettings.AppSettings["MappingsFileName"])))
            {
                try
                {
                    mappings = (mappings)ser.Deserialize(reader);
                }
                catch (InvalidOperationException ex)
                {
                    // invalid XML file
                    _mappingErrors.Add($"The was a problem with the mappings file: {ex.Message}");
                    return;
                }
            }

            if (MappingsFileIsValid(mappings))
            {
                Dispatcher.Invoke(() =>
                {
                    progressIndicator.BusyContent = $"Reading {Path.GetFileName(filePath)} file";
                });

                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath, ReadOnly: true);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int i = mappings.templatemaster.firstDataRowId; i <= rowCount; i++)
                {
                    var columnData = new string[colCount];

                    var countryName = GetColumnValue(xlRange, i, Utility.ExcelColumnNameToNumber(mappings.templatemaster.countryColumnId));

                    Country country = null;

                    if (!string.IsNullOrEmpty(countryName))
                    {
                        if (_schoolAndStudentData.ContainsKey(countryName))
                        {
                            country = _schoolAndStudentData[countryName];
                        }
                        else
                        {
                            country = new Country { Name = countryName, Schools = new Dictionary<string, School>() };
                            _schoolAndStudentData.Add(countryName, country);
                            _countriesLocated++;
                        }
                    }
                    else
                    {
                        _errors.Add($"Invalid or blank country name at row {i} column {mappings.templatemaster.countryColumnId}");
                    }

                    if (country != null)
                    {
                        var schoolName = GetColumnValue(xlRange, i, Utility.ExcelColumnNameToNumber(mappings.templatemaster.schoolColumnId));

                        School school = null;

                        if (!string.IsNullOrEmpty(schoolName))
                        {
                            if (country.Schools.ContainsKey(schoolName))
                            {
                                school = country.Schools[schoolName];
                            }
                            else
                            {
                                school = new School { Name = schoolName, Spreadsheets = new Dictionary<string, SpreadsheetData>() };
                                country.Schools.Add(schoolName, school);
                                _schoolsLocated++;
                            }
                        }
                        else
                        {
                            _errors.Add($"Invalid or blank school name at row {i} column {mappings.templatemaster.schoolColumnId}");
                        }

                        if (school != null)
                        {
                            if (mappings.templatemaster.spreadsheets.Any(x => x.countries.Any(y => y.name == countryName)))
                            {
                                foreach (var spreadsheet in mappings.templatemaster.spreadsheets.Where(x => x.countries.Any(y => y.name == countryName)))
                                {
                                    if (spreadsheet.countries.Any(x => x.name == country.Name))
                                    {
                                        var yearGroup = GetColumnValue(xlRange, i, Utility.ExcelColumnNameToNumber(mappings.templatemaster.yearGroupColumnId));

                                        if (spreadsheet.yeargroups.Any(x => x.name == yearGroup))
                                        {
                                            _studentsLocated++;

                                            Dispatcher.Invoke(() =>
                                            {
                                                progressIndicator.BusyContent = $"Countries located = {_countriesLocated}, Schools located = {_schoolsLocated}, Students located = {_studentsLocated}";
                                            });

                                            SpreadsheetData spreadSheetData = null;

                                            if (school.Spreadsheets.ContainsKey(spreadsheet.templatename))
                                            {
                                                spreadSheetData = school.Spreadsheets[spreadsheet.templatename];
                                            }
                                            else
                                            {
                                                _spreadsheetsToGenerate++;
                                                spreadSheetData = new SpreadsheetData { Name = spreadsheet.templatename, YearGroup = yearGroup, Students = new List<Student>(), TargetRowId = spreadsheet.targetFirstRowId };
                                                school.Spreadsheets.Add(spreadsheet.templatename, spreadSheetData);
                                            }

                                            var student = new Student { Values = new List<mappingsTemplatemasterSpreadsheetMapping>() };

                                            foreach (var column in spreadsheet.columnMappings)
                                            {
                                                var studentValue = GetColumnValue(xlRange, i, Utility.ExcelColumnNameToNumber(column.sourceColumnId));

                                                student.Values.Add(new mappingsTemplatemasterSpreadsheetMapping { targetColumnId = column.targetColumnId, value = studentValue });
                                            }

                                            spreadSheetData.Students.Add(student);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                _errors.Add($"There is no mapping for this country: {countryName} in the mapping file at row {i} column {mappings.templatemaster.countryColumnId}");
                            }
                        }
                    }
                }

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //close and release
                xlWorkbook.Close(false, null, null);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
            }
        }

        private bool MappingsFileIsValid(mappings mappings)
        {
            var result = true;

            // Check all our spreadsheet are distinct
            var spreadsheetNameList = mappings.templatemaster.spreadsheets.Select(x => x.templatename).ToList();
            if (spreadsheetNameList.Distinct().Count() != spreadsheetNameList.Count())
            {
                result = false;
                _mappingErrors.Add("The same spreadsheet is mentioned multiple times in the mapping file, please correct this.");
            }

            var appRoot = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var templateFilePathDirectory = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["PrincessTrustRootDirectory"], System.Configuration.ConfigurationSettings.AppSettings["TemplateFilePathDirectory"]);

            // Next check the spreadsheet names correspond to a valid template name
            foreach (var spreadsheet in mappings.templatemaster.spreadsheets)
            {
                if (!File.Exists($"{templateFilePathDirectory}\\{spreadsheet.templatename}"))
                {
                    result = false;
                    _mappingErrors.Add($"The spreadsheet called {spreadsheet.templatename} from the mappings file doesn't exist in the directory {templateFilePathDirectory}, please correct this and try again.");
                }
            }

            return result;
        }

        private string GetColumnValue(Excel.Range xlRange, int rowId, int columnId)
        {
            string value;

            if (xlRange.Cells[rowId, columnId] != null && xlRange.Cells[rowId, columnId].Value2 != null)
            {
                value = xlRange.Cells[rowId, columnId].Value2.ToString().Trim();
            }
            else
            {
                value = string.Empty;
            }

            return value;
        }

        private void btnCopyErrors_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.CommaSeparatedValue, string.Join("\n", _errors));
        }

        private void btnProcessSpreadsheet_Click(object sender, RoutedEventArgs e)
        {
            if (btnGenerateSpreadsheetClickEventHandler != null)
            {
                btnGenerateSpreadsheetClickEventHandler?.Invoke(_schoolAndStudentData, _spreadsheetsToGenerate);
            }
        }
    }
}
