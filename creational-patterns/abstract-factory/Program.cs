namespace AbstractFactory{
    class Program{
        static void Main(string[] args){
            Console.WriteLine("Building an imaginary world!");
            new Client().Main();
        }
    }

    class Client{
        public void Main(){
            Console.WriteLine("STARTING FACTORY: ForestEnvFactory");
            ClientMethod(new ForestEnvFactory());
        }
        public void ClientMethod(IAbstractEnvFactory factory){
            var town = factory.CreateTown();
            var dungeon = factory.CreateDungeon();
            var npcs = factory.CreateNPCs();

            Console.WriteLine("Town Buildings:");
            Console.WriteLine(string.Join("\n", town.CreateBuildings()));

            Console.WriteLine("Town Decorations:");
            Console.WriteLine(string.Join("\n", town.CreateDecorations()));

            Console.WriteLine("Dungeon Enemies:");
            Console.WriteLine(string.Join("\n", dungeon.CreateEnemies()));

            Console.WriteLine("Dungeon Chests:");
            Console.WriteLine(string.Join("\n", dungeon.CreateChests()));

            Console.WriteLine("Dungeon Boss: " + dungeon.CreateBoss());

            Console.WriteLine("NPC Shopkeep: " + npcs.CreateShopKeep());

            Console.WriteLine("NPC Unique: " + npcs.CreateUniqueNPC());

            Console.WriteLine("NPC Innkeeper: " + npcs.CreateInnkeeper());
        }
    }

    public interface IAbstractEnvFactory{
        IAbstractTown CreateTown();
        IAbstractDungeon CreateDungeon();
        IAbstractNPCs CreateNPCs();
    }

    class ForestEnvFactory : IAbstractEnvFactory{
        public IAbstractTown CreateTown(){
            return new ForestTown();
        }
        public IAbstractDungeon CreateDungeon(){
            return new ForestDungeon();
        }
        public IAbstractNPCs CreateNPCs(){
            return new ForestNPCs();
        }
    }

    internal class ForestTown : IAbstractTown
    {
        public string[] CreateBuildings(){
            string[] buildingTemplates = {"Treehouse", "Cave", "Pond", "Cabin"};
            return Utils.RandomList(buildingTemplates, 3, 5);
        }

        public string[] CreateDecorations(){
            string[] decorationTemplates = {"Flowers", "Beehive", "Bush", "Signpost"};
            return Utils.RandomList(decorationTemplates, 5, 10);
        }
    }

    internal class ForestDungeon : IAbstractDungeon
    {
        public string[] CreateEnemies(){
            string[] enemyTemplates = {"Wolf", "Goblin", "Wasp", "Crow", "Witch"};
            return Utils.RandomList(enemyTemplates, 5, 8);
        }
        public string[] CreateChests(){
            string[] chestTemplates = {"Money", "Potions", "Rare Materials"};
            return Utils.RandomList(chestTemplates, 1, 3);
        }
        public string CreateBoss(){
            return "Queenicorn";
        }
    }

    internal class ForestNPCs : IAbstractNPCs{
        public string CreateShopKeep(){
            return "Alf the Minotaur";
        }
        public string CreateUniqueNPC(){
            return "Crazed Dream Warden";
        }
        public string CreateInnkeeper(){
            return "Gwen";
        }
    }

    public interface IAbstractTown{
        string[] CreateBuildings();
        string[] CreateDecorations();
    }

    public interface IAbstractDungeon{
        string[] CreateEnemies();
        string[] CreateChests();
        string CreateBoss();
    }

    public interface IAbstractNPCs{
        string CreateShopKeep();
        string CreateUniqueNPC();
        string CreateInnkeeper();
    }

    public static class Utils{
        public static T[] RandomList<T>(T[] templates, int min, int max){
            Random rand = new Random();
            List<T> randomList = new List<T>();
            for(int i = 0; i < rand.Next(min, max + 1); i++){
                randomList.Add(templates[rand.Next(0, templates.Length)]);
            }
            return randomList.ToArray<T>();
        }
    }

}