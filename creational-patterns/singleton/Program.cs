namespace FactoryMethod{
    class Program{
        static void Main(string[] args){
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if(s1 == s2){
                Console.WriteLine("Singleton works");
            } else {
                Console.WriteLine("Singleton failed");
            }
        }
    }

    public sealed class Singleton{
        private static Singleton _instance;
        private Singleton(){}

        public static Singleton GetInstance(){
            if(_instance == null){
                _instance = new Singleton();
            }
            return _instance;
        }

        public void doSomething(){
            Console.WriteLine("Something?");
        }

    }
}