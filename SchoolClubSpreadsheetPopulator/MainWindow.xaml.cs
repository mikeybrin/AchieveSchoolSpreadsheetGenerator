using SchoolClubSpreadsheetPopulator.Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SchoolClubSpreadsheetPopulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Main window containing the layout and housing all of the relevent user controls.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetDefaultState();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ccWelcome.Visibility = Visibility.Hidden;
            btnStartOver.Visibility = Visibility.Visible;

            CreateUploadControl();
        }

        private void btnStartAgain_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultState();
        }

        private void SetDefaultState()
        {
            var ucWelcome = new ucWelcome();
            ucWelcome.btnStartClickEventHandler += new EventHandler(btnStart_Click);
            ccWelcome.Content = ucWelcome;
            ccWelcome.Visibility = Visibility.Visible;

            ccUpload.Visibility = Visibility.Hidden;
            ccGenerate.Visibility = Visibility.Hidden;
            btnStartOver.Visibility = Visibility.Hidden;
        }

        private void CreateUploadControl()
        {
            var ucUpload = new ucUpload();
            ucUpload.btnGenerateSpreadsheetClickEventHandler += UcUpload_btnGenerateSpreadsheetClickEventHandler;
            ccUpload.Content = ucUpload;

            ccUpload.Visibility = Visibility.Visible;
        }

        private void UcUpload_btnGenerateSpreadsheetClickEventHandler(Dictionary<string, Country> SchoolAndStudentData, int spreadsheetsToGenerate)
        {
            ccUpload.Visibility = Visibility.Hidden;
            btnStartOver.Visibility = Visibility.Visible;

            var ucGenerateSpreadsheets = new ucGenerateSpreadsheets();
            ucGenerateSpreadsheets.SchoolAndStudentData = SchoolAndStudentData;
            ucGenerateSpreadsheets.ExpectedSpreadsheetsToGenerate = spreadsheetsToGenerate;
            ucGenerateSpreadsheets.GenerateData();

            ccGenerate.Content = ucGenerateSpreadsheets;
            ccGenerate.Visibility = Visibility.Visible;

            ccUpload.Visibility = Visibility.Hidden;
        }
    }
}
