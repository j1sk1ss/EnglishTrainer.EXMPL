using System.Collections.Generic;
using EnglishTrainer.EXMPL.INTERFACES;

namespace EnglishTrainer.EXMPL.OBJECTS {
    public class MiddleQuest : IQuest {
        public string Quest { get; set; }
        public string Answer { get; set; }
        public MiddleQuest Set(string quest, string answer) {
            Quest = quest;
            Answer = answer;
            return this;
        }
        
        public string GetQuest() => Quest;

        public string GetAnswer() => Answer;
    }
}