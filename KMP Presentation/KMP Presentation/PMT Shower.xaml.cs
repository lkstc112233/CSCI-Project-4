using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class PMT_Entry : DependencyObject
    {
        public int index { get; set; }
        public int pointer { get; set; }
        public char ch { get; set; }
        public static readonly DependencyProperty currentUsingProperty = DependencyProperty.Register("currentUsing", typeof(int), typeof(PMT_Entry), new PropertyMetadata(-1));
        public int currentUsing { get { return (int)GetValue(currentUsingProperty); } set { SetValue(currentUsingProperty, value); } }
    }

    /// <summary>
    /// PMT_Shower.xaml 的交互逻辑
    /// </summary>
    public partial class PMT_Shower : Window
    {
        private string word { get; set; }
        private int[] pMT { get; set; }
        public List<PMT_Entry> list { get; set; }

        public static readonly DependencyProperty currentUsingProperty = DependencyProperty.Register("currentUsing", typeof(int), typeof(PMT_Shower), new PropertyMetadata(-1));
        public int currentUsing { get { return (int)GetValue(currentUsingProperty); } set { SetValue(currentUsingProperty, value); } }

        public PMT_Shower()
        {
            InitializeComponent();
        }

        public PMT_Shower(string word, int[] pMT)
        {
            this.word = word;
            this.pMT = pMT;
            list = new List<PMT_Entry>();
            int index = 0;
            foreach(var e in word)
            {
                PMT_Entry et = new PMT_Entry();
                et.ch = e;
                et.index = index;
                et.pointer = pMT[index];
                Binding binding = new Binding();
                binding.Source = this;
                binding.Path = new PropertyPath("currentUsing");
                BindingOperations.SetBinding(et, PMT_Entry.currentUsingProperty, binding);
                index += 1;
                list.Add(et);
            }
            PMT_Entry ent = new PMT_Entry();
            ent.ch = ' ';
            ent.index = index;
            ent.pointer = pMT[index];
            Binding bnd = new Binding();
            bnd.Source = this;
            bnd.Path = new PropertyPath("currentUsing");
            BindingOperations.SetBinding(ent, PMT_Entry.currentUsingProperty, bnd);
            list.Add(ent);
            DataContext = this;
            InitializeComponent();
        }
    }
}
