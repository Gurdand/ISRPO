﻿using System;
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
using System.Windows.Shapes;
using System.IO;

namespace lab_5
{
    /// <summary>
    /// Логика взаимодействия для ShowFile.xaml
    /// </summary>
    public partial class ShowFile : Window
    {
        public ShowFile(string fileName = null)
        {
            InitializeComponent();
            ReadText(fileName);
        }

        void ReadText(string fileName)
        {
            using (FileStream fstream = File.OpenRead(fileName))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                tbContent.Text = System.Text.Encoding.Default.GetString(array);
            }
        }

    }
}
