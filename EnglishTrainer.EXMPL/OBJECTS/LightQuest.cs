using System.Collections.Generic;
using EnglishTrainer.EXMPL.INTERFACES;

namespace EnglishTrainer.EXMPL.OBJECTS {
    public class LightQuest : IQuest {
        public string Quest { get; set; }
        public string Answer { get; set; }
        public LightQuest Set(string quest, string answer) {
            Quest  = quest;
            Answer = answer;
            return this;
        }
        
        public string GetQuest() => Quest;

        public string GetAnswer() => Answer;
    }
}