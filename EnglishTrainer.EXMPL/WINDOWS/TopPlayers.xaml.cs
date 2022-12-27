using System.Windows;
using EnglishTrainer.EXMPL.DATA;

namespace EnglishTrainer.EXMPL.WINDOWS {
    public partial class TopPlayers {
        public TopPlayers() {
            InitializeComponent();
            foreach (var user in UsersData.GetSortedList())
                PlayerTop.Content += $"{user.Name} - {user.MaxScore}\n";
        }
    }
}