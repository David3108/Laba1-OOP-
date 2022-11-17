using System;

namespace HelloWorld
{
    class Start
    {
        
        static void Main(string[] args)
        {         
            GameAccount user1 = new GameAccount("Vasya");
            GameAccount user2 = new GameAccount("Vitalii");
            int number;
            int rating; 
            Console.Write("Enter rating: ");
            rating = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            number = rnd.Next(1,12);
            for (int i = 0; i < 3; i++)
            {
                
                if (number >= 6) 
                {                
                    try
                    {
                        user1.WinGame("Vitalii", rating);
                        user2.LoseGame("Vasya", rating);
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                    number = rnd.Next(1,12);
                }
                else
                {
                    try
                    {
                        user1.LoseGame("Vitalii", rating);
                        user2.WinGame("Vasya", rating);
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                    number = rnd.Next(1,12);
                }
            }
            Console.Write($"{user1.GetUserName} history is:\n");
            Console.Write(user1.GetStats());
            Console.Write($"{user2.GetUserName} history is:\n");
            Console.Write(user2.GetStats());
            Console.WriteLine($"Vasya rating:{user1.CurRating()}");
            Console.WriteLine($"Vitalii rating:{user2.CurRating()}");
            
        }
    }
}