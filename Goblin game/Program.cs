namespace goblingame
{
    class Program
    {
        static void Main()
        {
            Next Ent = new();
            Console.WriteLine("Hello, welcome to Goblin inc. goblins have taken over the world.");
            Ent.E();
            Console.WriteLine("your job is to go kill everyone");
            Ent.E();
            Console.WriteLine("have this sword");
            Ent.E();
            Player temp = new();
            temp.Loot = "Sword";
            temp.Get();
            Map one = new();
            one.InitMap();
            one.RoomPath[0, 1] = true;
            one.RoomPath[1, 3] = true;
            one.RoomPath[1, 1] = true;
            one.RoomPath[2, 3] = true;
            one.RoomPath[2, 1] = true;
            one.RoomPath[3, 3] = true;


            one.Description[0] = "you see a garbarge can on the east side of the room";
            one.Description[1] = "amongus";
            one.Description[2] = "the potatoes are coming";
            one.Description[3] = "you see a big chandelier";
            one.Spawn = 0; 
            one.End = 3;
            one.Nav();
            Console.WriteLine("piss");
        }
        public class Player
        {
            public string Loot;
            public string Answer;
            public int Damage;
            public int Health;
            public bool HasSword;
            public bool HasAxe;
            public bool HasBow;
            public int Arrows;
            public int Potions;
            public int Armour;
            public void Get()
            {
                if (Loot == "Sword")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You now have a sword");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("the sword is sharp you should kill some goblins with it");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("it does 5 damage");
                    Console.ResetColor();
                    HasSword = true;
                }
                else if (Loot == "Axe")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You now have an axe");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("the axe is heavy you should kill some goblins with it");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("it does 8 damage");
                    Console.ResetColor();
                    HasAxe = true;
                }
                else if (Loot == "Bow")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You now have a bow");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("the bow is pretty damn good, it can shoot twice per turn. you should kill some goblins with it");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("it does 5 damage");
                    Console.ResetColor();
                    HasBow = true;
                }
                else if (Loot == "Arrow")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You now have 5 more arrows");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("the arrows are sharp, they get shot by the bow, you should kill some goblins with them");
                    Arrows = Arrows + 5;
                    Console.ResetColor();
                }
                else if (Loot == "Potions")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You now have 2 more potions");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("the potions will heal you, you cant kill goblins with them");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Potions = Potions + 2;
                    Console.ResetColor();
                }
                else if (Loot == "Armour")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    switch (Armour)
                    {
                        case 0:
                            Console.WriteLine("you now have leather armour");
                            Armour = 1;
                            break;
                        case 1:
                            Console.WriteLine("you now have bronze armour");
                            Armour = 2;
                            break;
                        case 2:
                            Console.WriteLine("you now have steel armour");
                            Armour = 3;
                            break;
                    }
                        
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("this will protect you againts goblin strikes");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("it has " + Armour + " protection");
                    Console.ResetColor();
                }
            }
            public void Heal()
            {
                if (Potions > 0)
                {
                    Console.WriteLine("You heal");
                    Potions = Potions - 1;
                    Health = 8;
                }
                else
                    Console.WriteLine("You don't have enough potions to heal");
            }
            public void Attack()
            {
                if (HasAxe || HasBow)
                {
                    Console.WriteLine("Which weapon do you want to use?");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Answer = Console.ReadLine();
                    Answer = Answer.ToLower();
                    Console.ResetColor();
                    if (Answer.Contains("sword") || Answer == "s")
                    {
                        Console.WriteLine("You swing your sword at the goblin and do 5 damage to the goblin");
                        Damage = 5;
                    }
                    else if ((Answer.Contains("axe") || Answer == "a") && HasAxe == true)
                    {
                        Console.WriteLine("You swing your axe at the goblin and do 8 damage to the goblin");
                        Damage = 8;
                    }
                    else if ((Answer.Contains("bow") || Answer == "b") && HasBow == true)
                    {
                        if (Arrows >= 2)
                        {
                            Console.WriteLine("You fire 2 shots and do 10 damage to the goblin");
                            Damage = 10;
                        }
                        if (Arrows < 2)
                        {
                            Console.WriteLine("You fire 1 shot and do 5 damage to the goblin");
                            Damage = 5;
                        }
                        else
                        {
                            Console.WriteLine("You try and load your bow but you realise you've run out of arrows!");
                            Damage = 0;
                        }
                    }
                    else
                    {
                        Damage = 0;
                        Console.WriteLine("you look for a " + Answer + " but you can't find it");
                    }
                }
                else
                {
                    Console.WriteLine("You swing your sword at the goblin and do 5 damage to the goblin");
                    Damage = 5;
                }
            }
        }
        public class Map
        {
            public bool[] GoblinFin;
            public string Answer;
            public int Direction;
            public int Room;
            public int Spawn;
            public int End;
            public int Health;
            public int GoblinHealth;
            public int GoblinMaxHealth;
            public string[] Description;
            public int[] RoomGobiLev;
            public int[] RoomLootLev;
            public bool[,] RoomPath;
            string HealthOut;
            public void InitMap()
            {
                RoomPath = new bool[16, 4];
                RoomGobiLev = new int[16];
                RoomLootLev = new int[16];
                Description = new string[16];
                GoblinFin = new bool[16];
            }
            public void Nav()
            {
                int RoomDir;
                int T;
                int i;
                int TotalDam;
                bool IsDone;
                Next EnPL = new();
                Player play = new();
                play.HasSword = true;
                Health = 20;
                IsDone = false;
                Room = Spawn;
                Direction = 0;
                while ((Room != End) || (Answer != "Elevator"))
                {
                    IsDone = false;
                    T = RoomGobiLev[Room];
                    Console.WriteLine(Description[Room]);
                    GoblinHealth = 1;
                    if (T > 0)
                    {
                        while (GoblinHealth > 0 && Health > 0 && GoblinFin[Room] == false)
                        {
                            if (IsDone == false)
                            {
                                switch (T)
                                {
                                    case 1:
                                        GoblinMaxHealth = 10;
                                        GoblinHealth = GoblinMaxHealth;
                                        Console.WriteLine("There is a goblin intern in front of you, he spots you and procedes to have a panic attack.");
                                        IsDone = true;
                                        break;
                                    case 2:
                                        GoblinMaxHealth = 15;
                                        GoblinHealth = GoblinMaxHealth;
                                        Console.WriteLine("You see a sad lonley goblin, sipping his coffee as though his life means nothing.");
                                        IsDone = true;
                                        break;
                                    case 3:
                                        GoblinMaxHealth = 20;
                                        GoblinHealth = GoblinMaxHealth;
                                        Console.WriteLine("You see a a goblin stabbing a printer, bouncing of the walls, she has a knife and is ready to kill.");
                                        IsDone = true;
                                        break;
                                    case 4:
                                        GoblinMaxHealth = 25;
                                        GoblinHealth = GoblinMaxHealth;
                                        Console.WriteLine("you see a goblin gaurd, chowing down on calamari on the end of his spear.");
                                        IsDone = true;
                                        break;
                                    case 5:
                                        GoblinMaxHealth = 35;
                                        GoblinHealth = GoblinMaxHealth;
                                        Console.WriteLine("You encounter the CEO of Gobin inc. and there is the goblin intern you bullied at the start, the CEO is his dad");
                                        IsDone = true;
                                        break;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("you engage in combat!");
                                EnPL.E();
                                Console.ResetColor();
                            }
                            Console.WriteLine("Do you want to attack or heal?");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Answer = Console.ReadLine();
                            Answer = Answer.ToLower();
                            Console.ResetColor();
                            if (Answer.Contains("attack") || Answer == "a")
                            {
                                play.Attack();
                                GoblinHealth = GoblinHealth - play.Damage;
                            }
                            else if (Answer.Contains("heal") || Answer == "h")
                            {
                                play.Heal();
                                Health = Health + play.Health;
                                if (Health > 20)
                                    Health = 20;
                            }
                            else
                                Console.WriteLine("you can't do that right now");
                            TotalDam = RoomGobiLev[Room] * 2 + 1 - play.Armour;
                            if (GoblinHealth > 0)
                            {
                                Console.WriteLine("The goblin attacks you and does " + TotalDam + " damage");
                                Health = Health - TotalDam;
                                HealthOut = "";
                                for (i = 0; i < 5; i++)
                                {   

                                    if (Health > i*4)
                                    {
                                        HealthOut = HealthOut + "%";
                                    }
                                    else
                                    {
                                        HealthOut = HealthOut + " ";
                                    }
                                }
                                Console.WriteLine("Your health:" + HealthOut + " " + Health + "/20");
                                Console.WriteLine("Goblin health: " + GoblinHealth + "/" + GoblinMaxHealth);
                                if (Health <= 0)
                                {
                                    Room = Spawn;
                                    Console.WriteLine("you died and were sent back to the first room you found");

                                }
                            }
                            else
                            {
                                GoblinFin[Room] = true;
                                Console.WriteLine("You defeated the Goblin!");
                            }
                        }
                    }
                    T = RoomLootLev[Room];
                    switch (T)
                    {
                        case 1:
                            if (play.HasAxe == false)
                            {
                                Console.WriteLine("You find an axe, and pick it up");
                                play.Loot = "Axe";
                                play.Get();

                            }
                            break;
                        case 2:
                            if (play.HasBow == false)
                            {
                                Console.WriteLine("You find a bow, and pick it up");
                                play.Loot = "Bow";
                                play.Get();
                            }
                            break;
                        case 3:
                            Console.WriteLine("You find some arrows");
                            play.Loot = "Arrows";
                            play.Get();
                            break;
                        case 4:
                            Console.WriteLine("You find some potions");
                            break;
                        case 5:
                            break;
                    }
                    if (Room == End)
                        Console.WriteLine("There is an elevator here do you want to go through it? type 'elevator' to go through");
                    else
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
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Answer = Console.ReadLine();
                        Answer = Answer.ToLower();
                        Console.ResetColor();
                        if ((Answer.Contains("north") || Answer == "n") && RoomPath[Room, 0])
                        {
                            Room = Room - 4;
                            Console.WriteLine("you head north");
                        }
                        else if ((Answer.Contains("east") || Answer == "e") && RoomPath[Room, 1])
                        {
                            Room = Room + 1;
                            Console.WriteLine("you head east");
                        }
                        else if ((Answer.Contains("south") || Answer == "s") && RoomPath[Room, 2])
                        {
                            Room = Room + 4;
                            Console.WriteLine("you go south");
                        }
                        else if ((Answer.Contains("west") || Answer == "w") && RoomPath[Room, 3])
                        {
                            Room = Room - 1;
                            Console.WriteLine("you head west");
                        }
                        else if (Answer.Contains("yes"))
                        {
                            Console.WriteLine("dont type yes, type in the direction listed");
                        }
                        else
                        {
                            Console.WriteLine("You cant do that, try typing in the direction.");
                        }
                    }
                }
            }

        }
        public class Next
        {
            public void E()
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press 'Enter' to Continue");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.ReadLine();
                Console.ResetColor();
            }
        }
    }
}