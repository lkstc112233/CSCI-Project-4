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
using System.Windows.Shapes;

namespace KMP_Presentation
{
    /// <summary>
    /// KMP_Solver.xaml 的交互逻辑
    /// </summary>
    public partial class KMP_Solver : Window
    {
        private KMP_View_Model vm;

        public KMP_Solver()
        {
            InitializeComponent();
        }

        internal KMP_Solver(KMP_View_Model vm)
        {
            this.vm = vm;
            this.DataContext = vm;
            InitializeComponent();
        }

        private void Show_PMT(object sender, RoutedEventArgs e)
        {
            PMT_Shower shower = new PMT_Shower(vm.Word, vm.PMT);
            shower.Show();
        }
    }
}
