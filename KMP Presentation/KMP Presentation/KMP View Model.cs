using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace KMP_Presentation
{
    class KMP_View_Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private KMP_Model m_model;

        private Binding getBinding(string path)
        {
            Binding b = new Binding();
            b.Source = this;
            b.Path = new PropertyPath(path);
            return b;
        }

        public KMP_View_Model(KMP_Model model)
        {
            m_model = model;
            string s = model.source;
            m_stringModel = new ObservableCollection<Presenter>();
            int indexCount = 0;
            LowerCharConverter lcc = new LowerCharConverter();
            LowerIndexConverter lic = new LowerIndexConverter();
            foreach (var ch in s)
            {
                Presenter p = new Presenter();
                p.UpperIndex = indexCount;
                p.UpperChar = ch;
                MultiBinding mb = new MultiBinding();
                mb.Bindings.Add(getBinding("Word"));
                mb.Bindings.Add(getBinding("Matching"));
                mb.Bindings.Add(getBinding("Candicate"));
                mb.Converter = lcc;
                mb.ConverterParameter = indexCount;
                BindingOperations.SetBinding(p, Presenter.LowerCharProperty, mb);
                mb = new MultiBinding();
                mb.Bindings.Add(getBinding("Word"));
                mb.Bindings.Add(getBinding("Matching"));
                mb.Bindings.Add(getBinding("Candicate"));
                mb.Converter = lic;
                mb.ConverterParameter = indexCount;
                BindingOperations.SetBinding(p, Presenter.LowerIndexProperty, mb);
                indexCount += 1;
                stringModel.Add(p);
            }
        }

        internal KMP_Status OneStep()
        {
            var v = m_model.OneStep();
            OnPropertyChange("Matching");
            OnPropertyChange("Candicate");
            if (v == KMP_Status.Found)
                stringModel[m_model.Answers.Last()].IsAnswer = true;
            return v;
        }

        public int[] PMT { get { return m_model.PartialMatchTable; } }
        public string Word { get { return m_model.word; } }
        public int Matching { get { return m_model.Matching; } }
        public int Candicate { get { return m_model.Candidate; } }
        public bool Ended { get; set; } = false;

        public ObservableCollection<Presenter> stringModel { get { return m_stringModel; } }
        private ObservableCollection<Presenter> m_stringModel;
    }

    internal class LowerIndexConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string word = values[0] as string;
            int matching = (int)values[1];
            int candicate = (int)values[2];
            int index = (int)parameter;
            if (candicate <= index && candicate + word.Length > index && matching >= index)
                return index - candicate;
            return -1;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class LowerCharConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string word = values[0] as string;
            int matching = (int)values[1];
            int candicate = (int)values[2];
            int index = (int)parameter;
            if (candicate <= index && candicate + word.Length > index && matching >= index)
                return word[index - candicate];
            return ' ';
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
