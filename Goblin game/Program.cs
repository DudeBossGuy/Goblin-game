using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace goblingame
{
    class Program
    {

        static void Main()
        {
            bool HasSword;
            bool HasAxe;
            bool HasBow;
            bool HasKey;
            int Arrows;
            int Potions;
            string Answer;
            byte Health;
            byte Room;
            Console.WriteLine("Hello, welcome to Goblin Village, goblins have taken over the world.");
            Console.ReadLine();
            Console.WriteLine("you job is to go kill everyone");
            Console.ReadLine();
            Console.WriteLine("have this sword");
            Console.ReadLine();
            HasSword = true;
            Item sword = new();
            sword.Name = "sword";
            sword.Description = "the sword is sharp, you should go kill some gobos with it";
            sword.Damage = 5;
            sword.Get();
            Map one = new();
            one.InitMap();
            one.RoomPath[0, 1] = true;
            one.RoomPath[1, 3] = true;

            one.RoomPath[1, 2] = true;
            one.RoomPath[5, 0] = true;

            one.RoomPath[5, 3] = true;
            one.RoomPath[4, 1] = true;
            one.Spawn = 0;
            one.End = 4;
            one.Nav();



        }
        public class Item
        {
            public string Name;
            public string Description;
            public int Damage;
            public void Get()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You now have a " + Name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Description);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("it does " + Damage + " damage");
                Console.ResetColor();
            }
        }
        public class Map
        {
            public string Answer;
            public int Direction;
            public int Room;
            public int Spawn;
            public int End;
            public string 
            public int[] RoomGobiLev;
            public int[] RoomLootLev;
            public bool[,] RoomPath;
            public void InitMap()
            {
                RoomPath = new bool[16, 4];
                RoomGobiLev = new int[16];
                RoomLootLev = new int[16];
            }
            public void Nav()
            {
                int RoomDir;
                Room = Spawn;
                Direction = 0;
                while (Room != End && Answer != "yes")
                {
                    Console.WriteLine("Do you want to:");
                    for (RoomDir = 0; RoomDir < 4; RoomDir++)
                    {
                        if (RoomPath[Room, RoomDir])
                        {
                            if (RoomDir == 0)
                                Console.WriteLine("Go north?");          
                            if (RoomDir == 1)
                                Console.WriteLine("Go east?");
                            if (RoomDir == 2)
                                Console.WriteLine("Go south?");
                            if (RoomDir == 3)
                                Console.WriteLine("Go west?");
                        }
                    }
                    if (Room == End)
                        Console.WriteLine("there is a portal here do you want to go through it?");
                    Answer = Console.ReadLine();
                    Answer = Answer.ToLower();
                    if (Answer.Contains("north") || Answer == "n")
                    {
                        Room = Room - 4;
                        Console.WriteLine("you head north");
                    }
                    if (Answer.Contains("east") || Answer == "e")
                    {
                        Room = Room + 1;
                        Console.WriteLine("you head east");
                    }
                    if (Answer.Contains("south") || Answer == "s")
                    {
                        Room = Room + 4;
                        Console.WriteLine("you go south");
                    }
                    if (Answer.Contains("west") || Answer == "w")
                    {
                        Room = Room + 1;
                        Console.WriteLine("you head west");
                    }

                }
            }
        }
    }
}
         