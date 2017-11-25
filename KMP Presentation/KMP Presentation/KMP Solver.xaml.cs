using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

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
            switch (vm.OneStep())
            {
                case KMP_Status.Finished:
                    vm.Ended = true;
                    RemoveAllLowerChar();
                    break;
                case KMP_Status.Matching:
                    OneStep_Executed(sender, e);
                    break;
            }
        }

        private void OneStep_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            if (vm != null)
                if (vm.Ended)
                    e.CanExecute = false;
        }

        private void BeginPause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            if (vm != null)
                if (vm.Ended)
                    e.CanExecute = false;
        }

        DispatcherTimer timer = null;
        Binding timerBinding = null;

        private void BeginPause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                BindingOperations.ClearBinding(vm, KMP_View_Model.PresentationSpeedProperty);
                timer = null;
            }
            else
            {
                timer = new DispatcherTimer();
                timer.Tick += Automatic_Step;
                timerBinding = new Binding();
                timerBinding.Source = timer;
                timerBinding.Path = new PropertyPath("Interval");
                timerBinding.Mode = BindingMode.OneWayToSource;
                BindingOperations.SetBinding(vm, KMP_View_Model.PresentationSpeedProperty, timerBinding);
                timer.Start();
            }
        }

        private void Automatic_Step(object sender, EventArgs e)
        {
            if (vm.OneStep() == KMP_Status.Finished)
            {
                vm.Ended = true;
                timer.Stop();
                BindingOperations.ClearBinding(vm, KMP_View_Model.PresentationSpeedProperty);
                timer = null;
                RemoveAllLowerChar();
            }
        }

        private void RemoveAllLowerChar()
        {
            foreach (var ent in vm.stringModel)
            {
                ent.BounceDown = true;
            }
        }
    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand OneStep = new RoutedUICommand("One Step Forward", "OneStep", typeof(CustomCommands), new InputGestureCollection() { new KeyGesture(Key.PageDown), new KeyGesture(Key.Down) });
        public static readonly RoutedUICommand BeginPause = new RoutedUICommand("Begin or Pause the Presentation", "BeginPause", typeof(CustomCommands), new InputGestureCollection() { new KeyGesture(Key.Space) });
    }
}
