using System;
using System.Collections.Generic;
using System.Windows;
using EnglishTrainer.EXMPL.DATA;
using EnglishTrainer.EXMPL.INTERFACES;
using EnglishTrainer.EXMPL.OBJECTS;
using EnglishTrainer.EXMPL.WINDOWS;

namespace EnglishTrainer.EXMPL {
    public partial class MainWindow {

        public MainWindow() {
            try {
                InitializeComponent();
                User = null;
                UsersData.Users = new List<User>();
                new Redactor().ReadQuests();
                
            }
            catch (Exception e) {
                MessageBox.Show($"{e}");
            }
        }

        public User User { get; set; }
        
        private void StartTrainer(object sender, RoutedEventArgs e) {
            if (User == null) {
                MessageBox.Show("Зарегистрируйтесь!");
                return;
            }
            if (Quests.LightQuests.Count == 0 && User.Level == Level.Junior) {
                MessageBox.Show("Заданий для вашего уровня навыков не обнаружено!");
                return;
            }
            if (Quests.MiddleQuests.Count == 0 && User.Level == Level.Middle) {
                MessageBox.Show("Заданий для вашего уровня навыков не обнаружено!");
                return;
            }
            if (Quests.HardQuests.Count == 0 && User.Level == Level.Senior) {
                MessageBox.Show("Заданий для вашего уровня навыков не обнаружено!");
                return;
            }
            
            new Trainer(new List<IQuest>(User.Level switch
            {
                Level.Junior => Quests.LightQuests,
                Level.Middle => Quests.MiddleQuests,
                Level.Senior => Quests.HardQuests,
                _ => Quests.LightQuests
            }), User).Show();
        }

        private void ChangeQuest(object sender, RoutedEventArgs e) => new Redactor().Show();
        private void Registration(object sender, RoutedEventArgs e) => new Registration(this).Show();

        private void Leaders(object sender, RoutedEventArgs e) {
            if (User == null) {
                MessageBox.Show("Зарегистрируйтесь!");
                return;
            }
            new TopPlayers().Show(); 
        } 
    }
}