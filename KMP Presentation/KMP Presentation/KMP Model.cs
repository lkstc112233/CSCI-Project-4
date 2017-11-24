using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP_Presentation
{
    enum KMP_Status
    {
        Beginning,
        Matching,
        Matches,
        Mismatches,
        Found,
        Finished,
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
            status = KMP_Status.Beginning;
        }
        public int Matching = 0;
        public int Candidate = 0;
        public int[] PartialMatchTable;
        public ObservableCollection<int> Answers { get; } = new ObservableCollection<int>();
        private KMP_Status status;
        public KMP_Status OneStep()
        {
            var PMTE = PartialMatchTable[Matching - Candidate];
            switch(status)
            {
                case KMP_Status.Beginning:
                    Matching = 0;
                    Candidate = 0;
                    status = KMP_Status.Matching;
                    break;
                case KMP_Status.Matching:
                    if (Matching - Candidate >= word.Length)
                    {
                        Answers.Add(Candidate);
                        status = KMP_Status.Found;
                    }
                    else
                    {
                        if (source.Length - Candidate < word.Length || Matching >= source.Length)
                            status = KMP_Status.Finished;
                        else if (word[Matching - Candidate] == source[Matching])
                            status = KMP_Status.Matches;
                        else
                            status = KMP_Status.Mismatches;
                    }
                    break;
                case KMP_Status.Matches:
                    Matching += 1;
                    status = KMP_Status.Matching;
                    break;
                case KMP_Status.Found:
                case KMP_Status.Mismatches:
                    Candidate = Matching - PMTE;
                    if (PMTE < 0)
                        Matching += 1;
                    status = KMP_Status.Matching;
                    break;
                case KMP_Status.Finished:
                    break;
            }
            return status;
        }
    }
}
