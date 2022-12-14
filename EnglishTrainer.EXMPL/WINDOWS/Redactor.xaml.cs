using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using EnglishTrainer.EXMPL.DATA;
using EnglishTrainer.EXMPL.OBJECTS;

namespace EnglishTrainer.EXMPL.WINDOWS {
    public partial class Redactor {
        public Redactor() {
            InitializeComponent();
            ReadQuests();
        }

        public void ReadQuests() {
            try {
                if (File.Exists("Light.txt")) {
                   var lines = File.ReadAllText("Light.txt").Split("\n", StringSplitOptions.RemoveEmptyEntries);
                   for (var i = 0; i < lines.Length - 1; i += 2) 
                       Quests.LightQuests.Add(new LightQuest().Set(lines[i], lines[i+1] ?? "")); 
                }
                
                if (File.Exists("Middle.txt")) { 
                    var lines = File.ReadAllText("Middle.txt").Split("\n", StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < lines.Length - 1; i += 2) 
                        Quests.MiddleQuests.Add(new MiddleQuest().Set(lines[i], lines[i+1] ?? ""));               
                }
                
                if (File.Exists("Hard.txt")) {
                    var lines = File.ReadAllText("Hard.txt").Split("\n", StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < lines.Length - 1; i += 2) 
                        Quests.HardQuests.Add(new HardQuest().Set(lines[i], lines[i+1] ?? ""));                
                }
            }
            catch (Exception e) {
                MessageBox.Show($"{e}");
            }
            
        }
        
        private void SaveQuest(object sender, RoutedEventArgs e) {
            try {
                var text = new TextRange(QuestBody.Document.ContentStart, QuestBody.Document.ContentEnd).Text;
                var lines = text.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                
                if (lines.Length % 2 != 0) {
                    MessageBox.Show("Введите корректные данные!");
                    return;
                }
                var temp = "";
                switch (Difficult.SelectionBoxItem) {
                    case "1 уровень":
                        Quests.LightQuests.Clear();
                        temp = "";
                        for (var i = 0; i < lines.Length; i += 2) {
                            temp += lines[i] + "\n" + lines[i + 1];
                            Quests.LightQuests.Add(new LightQuest().Set(lines[i], lines[i+1] ?? ""));
                            File.WriteAllText("Light.txt", temp);
                        }
                        break;
                    case "2 уровень":
                        Quests.MiddleQuests.Clear();
                        temp = "";
                        for (var i = 0; i < lines.Length; i += 2) {
                            temp += lines[i] + "\n" + lines[i + 1];
                            Quests.MiddleQuests.Add(new MiddleQuest().Set(lines[i], lines[i+1] ?? ""));
                            File.WriteAllText("Middle.txt", temp);
                        }
                        break;
                    case "3 уровень":
                        Quests.HardQuests.Clear();
                        temp = "";
                        for (var i = 0; i < lines.Length; i += 2) {
                            temp += lines[i] + "\n" + lines[i + 1];
                            Quests.HardQuests.Add(new HardQuest().Set(lines[i], lines[i+1] ?? ""));
                            File.WriteAllText("Hard.txt", temp);
                        }
                        break;
                }
            }
            catch (Exception exception) {
                MessageBox.Show($"{exception}");
            }
        }

        private void ViewQuests(object sender, SelectionChangedEventArgs e) {
            QuestBody.Document.Blocks.Clear();
            var text = "";
            
            if (Difficult.SelectedValue.ToString()!.Contains("1 уровень")) text = 
                Quests.LightQuests.Aggregate(text, (current, quest) =>
                    current + $"{quest.Quest}\n{quest.Answer}\n");
            
            if (Difficult.SelectedValue.ToString()!.Contains("2 уровень")) text =
                Quests.MiddleQuests.Aggregate(text, (current, quest) => 
                    current + $"{quest.Quest}\n{quest.Answer}\n");
            
            if (Difficult.SelectedValue.ToString()!.Contains("3 уровень")) 
                text = Quests.HardQuests.Aggregate(text, (current, quest) => 
                    current + $"{quest.Quest}\n{quest.Answer}\n");


            QuestBody.Document.Blocks.Add(new Paragraph(new Run(text)));
        }
    }
}