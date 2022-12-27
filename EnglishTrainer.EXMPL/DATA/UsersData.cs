using System;
using System.Collections.Generic;
using System.Windows;
using EnglishTrainer.EXMPL.OBJECTS;

namespace EnglishTrainer.EXMPL.DATA {
    public static class UsersData {
        public static List<User> Users { get; set; }

        public static List<User> GetSortedList() {
            try {
                var list = new List<User>(Users);

                for (var i = 0; i < list.Count; i++) 
                    for (var j = 0; j < list.Count - 1; j++) {
                        var temp = list[j];
                        if (temp.MaxScore >= list[j + 1].MaxScore) continue;
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                
                return list;
            }
            catch (Exception e) {
                MessageBox.Show($"{e}");
                return null;
            }
        }
    }
}