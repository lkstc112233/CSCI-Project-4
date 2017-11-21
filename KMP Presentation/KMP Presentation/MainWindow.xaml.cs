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

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
