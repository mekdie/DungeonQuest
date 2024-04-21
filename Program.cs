namespace DungeonQuest
{
    class Program
    {
        public static void Main()
        {
            using StreamReader reader = new("./TextFiles/introduction.txt");
            string line;
            bool completePrint = false;

            while ((line = reader.ReadLine()!) != null)
            {
                if (completePrint)
                {
                    Console.WriteLine(line); // Print the entire line immediately
                }
                else
                {
                    foreach (char c in line)
                    {
                        Console.Write(c);
                        Thread.Sleep(1);

                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(intercept: true).Key;
                            if (key == ConsoleKey.Spacebar)
                            {
                                completePrint = true;
                                Console.Write(line[Console.CursorLeft..]); // Print the rest of the line
                                break; // Exit the foreach loop
                            }
                        }
                    }
                    Console.WriteLine(); // Move to the next line after printing one line
                }
            }

            if (completePrint)
            {
                Console.ReadKey(); // Wait for any key press 
                                   // TODO: Begin your game here
            }
        }
    }
}