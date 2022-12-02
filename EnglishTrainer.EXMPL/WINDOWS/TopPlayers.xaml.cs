using System.Collections.Generic;
using System.Windows;
using EnglishTrainer.EXMPL.DATA;
using EnglishTrainer.EXMPL.OBJECTS;

namespace EnglishTrainer.EXMPL.WINDOWS {
    public partial class TopPlayers {
        public TopPlayers() {
            InitializeComponent();
            foreach (var user in UsersData.GetSortedList() ?? new List<User>{new()})
                PlayerTop.Content += $"{user.Name} - {user.MaxScore}\n";
        }
    }
}