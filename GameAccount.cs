namespace HelloWorld
{
    class GameAccount
    {
        private string UserName { get; set; }
        public string GetUserName {
            get
            {
                return UserName;
            }
        }
        private int CurrentRating { get; set; }           
        private int GamesCount { get; set; }
        //Створення списку, у якому буде історія про користувача

        private List<History> history = new List<History>() ;
        public static String WIN = "Win";
        public static String LOSE = "Lose";

        public GameAccount(string name)
        {
            UserName = name;
            CurrentRating = 20;
            GamesCount = 0;
        }
        public void WinGame(String opponentName, int rating) {
            if (rating < 0)
            {
                throw new Exception("Rating cannot be negative!");
                return;
            }

            History UserHistory = new History();
                UserHistory.OpponentName = opponentName;
                UserHistory.Result = WIN;
                UserHistory.Rating = rating;
                UserHistory.GamesCount = ++GamesCount;
                CurrentRating += rating;
                history.Add(UserHistory);
        }
        public void LoseGame(String opponentName, int rating)
        {
            if (rating < 0)
            {
                throw new Exception("Rating cannot be negative!");
                return;
            }          
                History UserHistory = new History();
                UserHistory.OpponentName = opponentName;
                UserHistory.Result = LOSE;
                UserHistory.Rating = rating;
                UserHistory.GamesCount = ++GamesCount;
                if (CurrentRating - rating < 1)
                {
                    CurrentRating = 1;
                }
                else
                {
                    CurrentRating -= rating;
                }
                history.Add(UserHistory);           

        }

        public string GetStats()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine("Game Index |Opponent Name |Rating |Result ");
            foreach (var item in history)
            {
                report.AppendLine($" {item.GamesCount} - {item.OpponentName} - {item.Rating} - {item.Result}\t");
            }
            return report.ToString();
        }

        public int CurRating()
        {
            return CurrentRating;
        }     
        

    }
//Створення класу, у якому буде історія про користувача

    class History
    {
        public String UserName { get; set; }
        public String OpponentName { get; set; }
        public string Result { get; set; }
        public int Rating { get; set; }
        private int gamesCount = 0;
         public int GamesCount { get; set; }
         /*{
             get { return GamesCount; }
             set { GamesCount = value; }
         }*/
         
        
    }
}