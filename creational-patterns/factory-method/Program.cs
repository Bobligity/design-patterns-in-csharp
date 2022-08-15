namespace FactoryMethod{
    class Program{
        static void Main(string[] args){
            new Client().Main();
        }
    }

    abstract class BossCreator{
        public abstract IBoss SpawnBoss();

        public string Fight(){
            IBoss boss = SpawnBoss();
            return "The boss begins to charge its special attack: " + boss.SpecialAttack();
        }
    }

    class BloodBossCreator : BossCreator{
        public override IBoss SpawnBoss()
        {
            return new BloodBoss();
        }
    }
     
    class NatureBossCreator : BossCreator{
        public override IBoss SpawnBoss()
        {
            return new NatureBoss();
        }
    }

    public interface IBoss{
        string SpecialAttack();
    }

    class BloodBoss : IBoss{
        public string SpecialAttack(){
            return "Sanguine Syphon";
        }
    }

    class NatureBoss : IBoss{
        public string SpecialAttack(){
            return "Underbrush Bunker";
        }
    }

    class Client{
        public void Main(){
            Console.WriteLine("Fight has started with the Nature Boss!!");
            ClientCode(new NatureBossCreator());

            Console.WriteLine("Fight has started with the Blood Boss!!");
            ClientCode(new BloodBossCreator());
        }

        public void ClientCode(BossCreator bossCreator){
            Console.WriteLine("3, 2, 1... FIGHT!");
            Console.WriteLine(bossCreator.Fight());
        }
    }
}