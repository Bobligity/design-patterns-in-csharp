namespace PrototypeMethod{
    class Program{
        static void Main(string[] args){
            Enemy e1 = new Enemy();
            e1.Hp = 100;
            e1.Name = "Goblin_1";
            e1.enemyId = new EnemyId(1);

            Enemy e2 = e1.ShallowCopy();
            Enemy e3 = e1.DeepCopy();

            Console.WriteLine("Before Values:");
            Console.WriteLine("e1");
            DisplayValues(e1);
            Console.WriteLine("e2");
            DisplayValues(e2);
            Console.WriteLine("e3");
            DisplayValues(e3);

            e1.Hp = 185;
            e1.Name = "Orc_1";
            e1.enemyId.Id = 2;
            
            Console.WriteLine("\nAfter Values:");
            Console.WriteLine("e1");
            DisplayValues(e1);
            Console.WriteLine("e2");
            DisplayValues(e2);
            Console.WriteLine("e3");
            DisplayValues(e3);
        }

        public static void DisplayValues(Enemy e){
            Console.WriteLine("\tName: {0:s} \tHp: {1:d}", e.Name, e.Hp);
            Console.WriteLine("\tId: " + e.enemyId.Id);
        }
    }

    public class Enemy{
        public int Hp;
        public string Name;
        public EnemyId enemyId;

        public Enemy ShallowCopy(){
            return (Enemy) this.MemberwiseClone();
        }
        public Enemy DeepCopy(){
            Enemy clone = (Enemy) this.MemberwiseClone();
            clone.enemyId = new EnemyId(enemyId.Id);
            clone.Name = new string(Name);
            return clone;
        }

    }

    public class EnemyId{
        public int Id;
        public EnemyId(int id){
            this.Id = id;
        }
    }
}