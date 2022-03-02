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
            Console.WriteLine("Hello, welcome to Goblin Village, goblins have taken over the world.");
            Thread.Sleep(1000);
            Console.WriteLine("you job is to go kill everyone");
            Thread.Sleep(1000);
            Console.WriteLine("have this sword");
            Thread.Sleep(1000);
            HasSword = true;
            Item sword = new();
            sword.Name = "sword";
            sword.Description = "the sword is sharp, you should go kill some gobos with it";
            sword.Damage = 5;
            sword.Get();
            Console.WriteLine("there are two doors one to your right and one to your right which way do you go?");
            
            

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
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Description);
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("it does " + Damage + " damage");
                Console.ResetColor();
            }
        }
        public class Map
        {
            public string answer;
            public bool option1;
            public bool option2;
            public bool option3;
            public bool option4;
            public string option5;
            public void Nav()
            {
                Console.WriteLine("Do you want to");
                if (option1)
                {
                    Console.WriteLine("go back");
                }
                if (option1)
                {
                    Console.WriteLine("go back");
                }
                if (option1)
                {
                    Console.WriteLine("go back");
                }
                if (option1)
                {
                    Console.WriteLine("go back");
                }
                if (option1)
                {
                    Console.WriteLine("go back");
                }
                Console.WriteLine();


            }
        }
    }
}
         