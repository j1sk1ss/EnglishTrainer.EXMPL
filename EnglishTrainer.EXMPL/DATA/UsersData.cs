using System.Collections.Generic;
using EnglishTrainer.EXMPL.OBJECTS;

namespace EnglishTrainer.EXMPL.DATA {
    public static class UsersData {
        static UsersData() => Users = new List<User>();
        public static List<User> Users { get; }
        public static List<User> GetSortedList() {
            var list = new List<User>(Users ?? new List<User>());
            for (var i = 0; i < list.Count; i++) {
                for (var j = 0; j < list.Count - 1; j++) {
                    var temp = list[j];
                    if (temp.MaxScore >= list[j + 1].MaxScore) continue;
                    list[i] = list[i + 1];
                    list[i + 1] = temp;
                }
            }

            return list;
        }
    }
}