using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP_Presentation
{
    class KMP_Model
    {
        public string source;
        public string word;
        public KMP_Model(string source, string word)
        {
            this.source = source;
            this.word = word;
        }
        public int i = 0;
        public int m = 0;
    }
}
