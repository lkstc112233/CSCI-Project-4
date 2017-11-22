﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public KMP_View_Model(KMP_Model model)
        {
            m_model = model;
            string s = model.source;
            m_stringModel = new ObservableCollection<Presenter>();
            int indexCount = 0;
            foreach (var ch in s)
            {
                Presenter p = new Presenter();
                p.UpperIndex = indexCount;
                p.UpperChar = ch;
                indexCount += 1;
                stringModel.Add(p);
            }
        }

        public int[] PMT { get { return m_model.PartialMatchTable; } }
        public string Word { get { return m_model.word; } }

        public ObservableCollection<Presenter> stringModel { get { return m_stringModel; } }
        private ObservableCollection<Presenter> m_stringModel;
    }
}
