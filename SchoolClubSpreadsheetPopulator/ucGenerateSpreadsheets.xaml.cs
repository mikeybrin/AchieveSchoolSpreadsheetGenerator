using SchoolClubSpreadsheetPopulator.Classes;
using System.Collections.Generic;
using System.Windows.Controls;
using System;
using System.Linq;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;

namespace SchoolClubSpreadsheetPopulator
{
    /// <summary>
    /// Interaction logic for ucGenerateSpreadsheets.xaml
    /// </summary>
    public partial class ucGenerateSpreadsheets : UserControl
    {
        public Dictionary<string, Country> SchoolAndStudentData { get; internal set; }
        public int ExpectedSpreadsheetsToGenerate { get; internal set; }

        private List<string> _errors = new List<string>();
        private string _outputDirectory;
        private int _spreadsheetsGenerated = 0;
        private int _schoolsGenerated = 0;
        private int _studentsGenerated = 0;

        public ucGenerateSpreadsheets()
        {
            InitializeComponent();
        }

        public void GenerateData()
        {
            if (SchoolAndStudentData.Any())
            {
                progressIndicator.IsBusy = true;

                // exspensive process reading excel files (much better if they wee CSV!) so lets start a background task to read it.
                Task.Factory.StartNew(() =>
                {
                    GenerateSpreadsheets();
                })
                .ContinueWith((task) =>
                {
                    // file has been read let's show the results
                    progressIndicator.IsBusy = false;
                    btnOpenDirectory.Visibility = Visibility.Visible;

                    lblGenerationResult.Text = $"Completed spreadsheet generation for {_schoolsGenerated} schools for {_studentsGenerated} students with {_errors.Count()} errors.{Environment.NewLine}Total spreadsheets generated: {_spreadsheetsGenerated}";
                    lblGenerationResult.Visibility = Visibility.Visible;

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
        }

        private void GenerateSpreadsheets()
        {
            var generatedDropDirectory = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["PrincessTrustRootDirectory"], System.Configuration.ConfigurationSettings.AppSettings["GeneratedFilePathDirectory"]);

            _outputDirectory = $"{generatedDropDirectory}\\{DateTime.Now.ToString("dd-MM-yyyy HHmmss")}";

            try
            {
                // try to remove any data that is already in the target directory
                Directory.Delete(_outputDirectory, true);
            }
            catch (Exception ex)
            {
                // do nothing the directory just doesn't exist
            }

            Directory.CreateDirectory(_outputDirectory);

            foreach (var schoolAndStudentData in SchoolAndStudentData)
            {
                var country = schoolAndStudentData.Value;
                var outputCountryDirectory = $"{_outputDirectory}\\{country.Name}";

                foreach (var school in country.Schools.Where(x => x.Value.Spreadsheets.Any(y => y.Value.Students.Any())))
                {
                    _schoolsGenerated++;

                    foreach (var spreadsheet in school.Value.Spreadsheets)
                    {
                        var students = spreadsheet.Value.Students;

                        var outputSchoolDirectory = $"{outputCountryDirectory}\\{school.Value.Name}";
                        var outputSchoolSpreadsheetName = $"{outputSchoolDirectory}\\{school.Key}_{spreadsheet.Value.YearGroup}.xlsx";

                        if (students.Any())
                        {
                            Dispatcher.Invoke(() =>
                            {
                                progressIndicator.BusyContent = $"Generating spreadsheet for School: {school.Key}, Country: {country.Name}. Remaining spreadsheets to generate: {ExpectedSpreadsheetsToGenerate - _spreadsheetsGenerated}";
                            });

                            _spreadsheetsGenerated++;

                            Directory.CreateDirectory(outputCountryDirectory);
                            Directory.CreateDirectory(outputSchoolDirectory);

                            if (File.Exists(outputSchoolSpreadsheetName))
                            {
                                File.Delete(outputSchoolSpreadsheetName);
                            }

                            var appRoot = AppDomain.CurrentDomain.BaseDirectory;
                            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                            Workbook xlWorkbook = null;
                            _Worksheet xlWorksheet = null;

                            try
                            {
                                var templateFilePathDirectory = Path.Combine(System.Configuration.ConfigurationSettings.AppSettings["PrincessTrustRootDirectory"], System.Configuration.ConfigurationSettings.AppSettings["TemplateFilePathDirectory"]);

                                xlWorkbook = xlApp.Workbooks.Open($"{templateFilePathDirectory}\\{spreadsheet.Value.Name}", ReadOnly: true);
                                xlWorksheet = xlWorkbook.Worksheets[1];
                                Range xlRange = xlWorksheet.UsedRange;

                                var targetRowId = int.Parse(spreadsheet.Value.TargetRowId);

                                foreach (var student in students)
                                {
                                    _studentsGenerated++;

                                    Range range = (Range)xlWorksheet.Cells[targetRowId, xlRange.Columns.Count].EntireRow;

                                    foreach (var mapping in student.Values)
                                    {
                                        range.Cells[1, Utility.ExcelColumnNameToNumber(mapping.targetColumnId)] = mapping.value;
                                    }

                                    targetRowId++;
                                }

                                xlWorkbook.SaveAs(outputSchoolSpreadsheetName);

                            }
                            catch (Exception ex)
                            {
                                _spreadsheetsGenerated--;
                                _schoolsGenerated--;


                                _errors.Add($"There was an error processing the template: {spreadsheet.Value.Name} for school: {school.Key}. Error was: {ex.Message + Environment.NewLine + ex.StackTrace}");
                            }
                            finally
                            {
                                GC.Collect();
                                GC.WaitForPendingFinalizers();

                                //close and release
                                if (xlWorkbook != null)
                                {
                                    xlWorkbook.Close(false, null, null);
                                    Marshal.ReleaseComObject(xlWorksheet);
                                    Marshal.ReleaseComObject(xlWorkbook);
                                }
                                xlApp.Quit();
                                Marshal.ReleaseComObject(xlApp);
                            }
                        }
                    }
                }
            }
        }

        public void AddData(_Worksheet xlWorksheet, int row, int col, string data)
        {
            xlWorksheet.Cells[row, col] = data;
        }

        private void btnOpenDirectory_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start(_outputDirectory);
        }

        private void btnCopyErrors_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.CommaSeparatedValue, string.Join("\n", _errors));
        }
    }
}
