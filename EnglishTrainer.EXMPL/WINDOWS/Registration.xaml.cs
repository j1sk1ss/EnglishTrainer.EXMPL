using System.Windows;
using EnglishTrainer.EXMPL.DATA;
using EnglishTrainer.EXMPL.OBJECTS;

namespace EnglishTrainer.EXMPL.WINDOWS {
    public partial class Registration : Window {
        public Registration(MainWindow mainWindow) {
            MainWindow = mainWindow;
            User       = mainWindow.User;
            
            InitializeComponent();
        }
        private MainWindow MainWindow { get; }
        private User User { get; set; }

        private void SaveUser(object sender, RoutedEventArgs e) {
            MainWindow.UserName.Content = $"Приветствую вас, {UserName.Text}";
            
            User = new User {
                Name = UserName.Text,
                Surname = UserSurname.Text,
                Level = Level.Text switch {
                    "Плохой"  => OBJECTS.Level.Junior,
                    "Средний" => OBJECTS.Level.Middle,
                    "Высокий" => OBJECTS.Level.Senior,
                    _         => OBJECTS.Level.Junior
                }
            };
            
            MainWindow.User = User;
            UsersData.Users.Add(User);
            
            Close();
        }
    }
}