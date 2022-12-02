namespace EnglishTrainer.EXMPL.OBJECTS {
    public class User {
        public User() {
            Name = "Пользователь";
            Surname = "NULL";
            Level = Level.Junior;
            MaxScore = 0;
        }
        public string Name { get; init; }
        public string Surname { get; init; }
        public Level Level { get; set; }
        
        public int MaxScore { get; set; }
    }
    public enum Level {
        Junior,
        Middle,
        Senior
    }
}