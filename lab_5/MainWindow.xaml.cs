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
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace lab_5
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

        // запускаем поиск по введенному пользователем шаблону
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            listOfFiles.Items.Clear();
            listOfFiles.Visibility = Visibility.Visible;
            tbContext.Visibility = Visibility.Hidden;
            var dir = new DirectoryInfo(way.Text);
            string file = obj.Text;
            FindInDir(dir, file, findInFolders.IsChecked.Value);

            if (listOfFiles.Items.Count == 0)
            {
                System.Windows.MessageBox.Show("Файлы не найдены");
            }
        }

        // непосредственно сам поиск
        private void FindInDir(DirectoryInfo dir, string pattern, bool recursive)
        {
            try
            {
                foreach (FileInfo file in dir.GetFiles(pattern))
                {
                    listOfFiles.Items.Add(file.FullName);
                }
                if (recursive)
                {
                    foreach (DirectoryInfo subdir in dir.GetDirectories())
                    {
                        FindInDir(subdir, pattern, recursive);
                    }
                }

            }
            catch (SecurityException) { }
            catch (DirectoryNotFoundException) { }
            catch (UnauthorizedAccessException) { }
        }

        // получаем путь для поиска файлов
        private void View_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            DialogResult result = folderBrowser.ShowDialog();
            way.Text = folderBrowser.SelectedPath;
        }

        // очистка полей
        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            way.Text = string.Empty;
            obj.Text = string.Empty;
            tbContext.Text = string.Empty;
            listOfFiles.Items.Clear();
        }

        private void ListOfFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowFile sf = new ShowFile(listOfFiles.SelectedItem.ToString());
            sf.Show();
        }

    }
}
