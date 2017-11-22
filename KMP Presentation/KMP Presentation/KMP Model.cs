using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP_Presentation
{
    enum KMP_Status
    {
        Matching,
        Discarding,
        Matched,
        Finished,
    }
    class StepInfo
    {
        KMP_Status status;
        object additionalData;
    }
    class KMP_Model
    {
        public string source;
        public string word;
        public KMP_Model(string source, string word)
        {
            this.source = source;
            this.word = word;
            BuildPartialMatchTable();
        }

        private void BuildPartialMatchTable()
        {
            PartialMatchTable = new int[word.Length + 1];
            int candidateMatcher = 0;
            int cursor = 1;
            PartialMatchTable[0] = -1;
            while (cursor < word.Length)
            {
                if (word[cursor] == word[candidateMatcher])
                    PartialMatchTable[cursor] = PartialMatchTable[candidateMatcher];
                else
                {
                    PartialMatchTable[cursor] = candidateMatcher;
                    do
                        candidateMatcher = PartialMatchTable[candidateMatcher];
                    while (candidateMatcher >= 0 && word[candidateMatcher] != word[cursor]);
                }
                candidateMatcher += 1;
                cursor += 1;
            }
            PartialMatchTable[cursor] = candidateMatcher;
        }

        public int MatchBegin = 0;
        public int Candidate = 0;
        public int[] PartialMatchTable;
        public void OneStep()
        {
            
        }
    }
}
