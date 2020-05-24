using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace lab_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (System.Windows.Media.FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                cbFontFamily.Items.Add(fontFamily.Source);
            }

            cbFontFamily.SelectedIndex = 0;

            
        }

        private void BBolt_Click(object sender, RoutedEventArgs e)
        {
            if (richTextBox != null)
            {
                if (richTextBox.Selection.GetPropertyValue(Run.FontWeightProperty) is FontWeight &&
                    ((FontWeight)richTextBox.Selection.GetPropertyValue(Run.FontWeightProperty)) == FontWeights.Normal)
                {
                    richTextBox.Selection.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Bold);
                } else { 
                    richTextBox.Selection.ApplyPropertyValue(Run.FontWeightProperty, FontWeights.Normal);
                }
            }
        }

        private void BItalics_Click(object sender, RoutedEventArgs e)
        {
            if (richTextBox != null)
            {
                if (richTextBox.Selection.GetPropertyValue(Run.FontStyleProperty) is FontStyle &&
                    ((FontStyle)richTextBox.Selection.GetPropertyValue(Run.FontStyleProperty)) == FontStyles.Normal) 
                {
                    richTextBox.Selection.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Italic);
                } else {
                    richTextBox.Selection.ApplyPropertyValue(Run.FontStyleProperty, FontStyles.Normal);
                }
            }
        }

        private void SFontSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (richTextBox != null)
            {
                richTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, sFontSize.Value);
            }
        }

        private void cbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (richTextBox != null && cbFontFamily.SelectedValue != null)
            {
                richTextBox.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, cbFontFamily.SelectedValue);
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                textRange.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (richTextBox != null)
            {
                var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                var str = textRange.Text;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, str);
                }
            }
        }
    }
}
