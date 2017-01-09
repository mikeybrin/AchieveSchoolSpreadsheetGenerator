using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolClubSpreadsheetPopulator
{
    /// <summary>
    /// Interaction logic for ucWelcome.xaml
    /// </summary>
    public partial class ucWelcome : UserControl
    {
        public event EventHandler btnStartClickEventHandler;

        public ucWelcome()
        {
            InitializeComponent();
        }

        private void btnGeneration_Click(object sender, RoutedEventArgs e)
        {
            btnStartClickEventHandler?.Invoke(this, e);
        }
    }
}
