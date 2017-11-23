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
        PMT_Shower shower;

        internal KMP_Solver(KMP_View_Model vm)
        {
            this.vm = vm;
            this.DataContext = vm;
            shower = new PMT_Shower(vm.Word, vm.PMT);
            InitializeComponent();
        }

        private void Show_PMT(object sender, RoutedEventArgs e)
        {
            shower.Show();
        }

        private void OneStep_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (vm.OneStep() == KMP_Status.Finished)
                vm.Ended = true;
        }

        private void OneStep_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            if (vm != null)
                if (vm.Ended)
                    e.CanExecute = false;
        }
    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand OneStep = new RoutedUICommand("One Step Forward", "OneStep", typeof(CustomCommands), new InputGestureCollection() { new KeyGesture(Key.PageDown), new KeyGesture(Key.Down) });
    }
}
