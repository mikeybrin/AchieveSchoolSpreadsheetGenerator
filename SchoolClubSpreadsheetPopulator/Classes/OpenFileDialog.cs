﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SchoolClubSpreadsheetPopulator
{
    public class OpenFileDialog1
    {
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.RegisterAttached(
                "Filter",
                typeof(string),
                typeof(OpenFileDialog1),
                new PropertyMetadata("All documents (.*)|*.*", (d, e) => AttachFileDialog((TextBox)d, e))
            );


        public static string GetFilter(UIElement element)
        {
            return (string)element.GetValue(FilterProperty);
        }

        public static void SetFilter(UIElement element, string value)
        {
            element.SetValue(FilterProperty, value);
        }

        private static void AttachFileDialog(TextBox textBox, DependencyPropertyChangedEventArgs args)
        {
            var textBoxParent = textBox.Parent as Panel;
            if (textBoxParent == null)
            {
                Debug.Print("Failed to attach File Dialog Launching Button Click Handler to Textbox parent panel!");
                return;
            }


            textBoxParent.Loaded += delegate
            {
                var button = textBoxParent.Children.Cast<object>().FirstOrDefault(x => x is Button) as Button;
                if (button == null)
                    return;

                var filter = (string)args.NewValue;

                button.Click += (s, e) =>
                {
                    var dlg = new OpenFileDialog { Filter = filter };

                    var result = dlg.ShowDialog();

                    if (result == true)
                    {
                        textBox.Text = dlg.FileName;
                    }
                };
            };
        }
    }
}
