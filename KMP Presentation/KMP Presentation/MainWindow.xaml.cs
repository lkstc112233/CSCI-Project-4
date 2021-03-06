﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KMP_Presentation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(MainWindow));
        public string Source { get { return (string)GetValue(SourceProperty); } set { SetValue(SourceProperty, value); } }
        private static readonly DependencyProperty WordProperty = DependencyProperty.Register("Word", typeof(string), typeof(MainWindow));
        public string Word { get { return (string)GetValue(WordProperty); } set { SetValue(WordProperty, value); } }

        SettingContentWindow settings = null;

        public MainWindow()
        {
            DataContext = this;
            Source = "ABC ABCDAB ABCDABCDABCDABDABE";
            Word = "ABCDABD";
            InitializeComponent();
        }

        private void Show_Solver_Click(object sender, RoutedEventArgs e)
        {
            KMP_Model mod = new KMP_Model(Source, Word);
            KMP_View_Model vm = new KMP_View_Model(mod);
            KMP_Solver solver = new KMP_Solver(vm);
            solver.Show();
        }

        private void Show_Settings(object sender, RoutedEventArgs e)
        {
            if (settings == null)
            {
                settings = new SettingContentWindow();
                settings.Closed += Settings_Closed;
            }
            settings.Show();
        }

        private void Settings_Closed(object sender, EventArgs e)
        {
            settings = null;
        }

        private void PS1(object sender, RoutedEventArgs e)
        {
            KMP_Model mod = new KMP_Model("abcxabcdabxabcdabcdabcy", "abcdabcy");
            KMP_View_Model vm = new KMP_View_Model(mod);
            KMP_Solver solver = new KMP_Solver(vm);
            solver.Show();
        }

        private void PS2(object sender, RoutedEventArgs e)
        {
            KMP_Model mod = new KMP_Model("AAAAAAAAAAAAAAAAAAAAAB", "AAAAB");
            KMP_View_Model vm = new KMP_View_Model(mod);
            KMP_Solver solver = new KMP_Solver(vm);
            solver.Show();
        }

        private void PS3(object sender, RoutedEventArgs e)
        {
            KMP_Model mod = new KMP_Model("AAAAAAAAAAAAAAAAAAA", "AAAAAA");
            KMP_View_Model vm = new KMP_View_Model(mod);
            KMP_Solver solver = new KMP_Solver(vm);
            solver.Show();
        }
    }
}
