using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KMP_Presentation
{
    class Presenter : DependencyObject
    {
        public int UpperIndex { get { return (int)GetValue(UpperIndexProperty); } set { SetValue(UpperIndexProperty, value); } }
        public static readonly DependencyProperty UpperIndexProperty = DependencyProperty.Register("UpperIndex", typeof(int), typeof(Presenter), new PropertyMetadata(-1)); 
        public char UpperChar { get { return (char)GetValue(UpperCharProperty); } set { SetValue(UpperCharProperty, value); } }
        public static readonly DependencyProperty UpperCharProperty = DependencyProperty.Register("UpperChar", typeof(char), typeof(Presenter), new PropertyMetadata('\0'));
        public int LowerIndex { get { return (int)GetValue(LowerIndexProperty); } set { SetValue(LowerIndexProperty, value); } }
        public static readonly DependencyProperty LowerIndexProperty = DependencyProperty.Register("LowerIndex", typeof(int), typeof(Presenter), new PropertyMetadata(-1));
        public char LowerChar { get { return (char)GetValue(LowerCharProperty); } set { SetValue(LowerCharProperty, value); } }
        public static readonly DependencyProperty LowerCharProperty = DependencyProperty.Register("LowerChar", typeof(char), typeof(Presenter), new PropertyMetadata('\0'));
        public bool IsAnswer { get { return (bool)GetValue(IsAnswerProperty); } set { SetValue(IsAnswerProperty, value); } }
        public static readonly DependencyProperty IsAnswerProperty = DependencyProperty.Register("IsAnswer", typeof(bool), typeof(Presenter), new PropertyMetadata(false));
        public bool BounceDown { get { return (bool)GetValue(BounceDownProperty); } set { SetValue(BounceDownProperty, value); } }
        public static readonly DependencyProperty BounceDownProperty = DependencyProperty.Register("BounceDown", typeof(bool), typeof(Presenter), new PropertyMetadata(false));
    }
}
