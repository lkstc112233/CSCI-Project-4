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
    public class PMT_Entry
    {
        public int index { get; set; }
        public int pointer { get; set; }
        public char ch { get; set; }
    }

    /// <summary>
    /// PMT_Shower.xaml 的交互逻辑
    /// </summary>
    public partial class PMT_Shower : Window
    {
        private string word { get; set; }
        private int[] pMT { get; set; }
        public List<PMT_Entry> list { get; set; }

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
                index += 1;
                list.Add(et);
            }
            PMT_Entry ent = new PMT_Entry();
            ent.ch = ' ';
            ent.index = index;
            ent.pointer = pMT[index];
            list.Add(ent);
            DataContext = this;
            InitializeComponent();
        }
    }
}
