using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using EnglishTrainer.EXMPL.INTERFACES;
using EnglishTrainer.EXMPL.OBJECTS;

namespace EnglishTrainer.EXMPL.WINDOWS {
    public partial class Trainer {
        public Trainer(List<IQuest> quest, User user) {
            InitializeComponent();
            
            MainQuests = quest;
            User       = user;
            
            QuestCount.Content = $"{_position}/{MainQuests.Count - 1}";
            Quest.Content = MainQuests[_position].GetQuest();
        }
        private List<IQuest> MainQuests { get; }
        private User User { get; }
        private int _position;
        private int _score;
        private int _mistakes;
        
        private void NextQuestion(object sender, RoutedEventArgs e) {
            if (++_position == MainQuests.Count) {
                MessageBox.Show("Вы прошли тест!\n" +
                                $"Ошибки: {_mistakes}");
                User.MaxScore = _score;
                return;
            }
            var answer = new TextRange(PlayerAnswer.Document.ContentStart, PlayerAnswer.Document.ContentEnd).Text;
            QuestCount.Content = $"{_position}/{MainQuests.Count}";
            Quest.Content = MainQuests[_position].GetQuest();
            
            if (answer.Replace("\n", "") != MainQuests[_position - 1].GetAnswer()) {
                Mistakes.Content = $"Ошибки: {++_mistakes}";
                return;
            }
            
            Score.Content = $"Счёт: {_score += 50}";
        }
    }
}