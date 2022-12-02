using System.Collections.Generic;
using EnglishTrainer.EXMPL.OBJECTS;

namespace EnglishTrainer.EXMPL.DATA {
    public static class Quests {
        static Quests() {
            LightQuests = new List<LightQuest>();
            MiddleQuests = new List<MiddleQuest>();
            HardQuests = new List<HardQuest>();
        }
        public static List<LightQuest> LightQuests { get; set; }
        public static List<MiddleQuest> MiddleQuests { get; set; }
        public static List<HardQuest> HardQuests { get; set; }
    }
}