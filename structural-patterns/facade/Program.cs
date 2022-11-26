namespace FacadePattern{
    class Program{
        static void Main(string[] args){
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();

            Facade facade = new Facade(subsystem1, subsystem2);
            Client.ClientCode(facade);
        }
    }

    public class Facade{
        protected Subsystem1 _subsystem1;
        protected Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2){
            this._subsystem1 = subsystem1;
            this._subsystem2 = subsystem2;
        }
        
        public string Operation(){
            string result = "Facade initialize subsystems:\n";
            result += this._subsystem1.Operation1();
            result += this._subsystem2.Operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += this._subsystem1.OperationN();
            result += this._subsystem2.OperationZ();
            return result;
        }
    }

    public class Subsystem1{
        public string Operation1(){
            return "Subsystem1: Ready!\n";
        }
        public string OperationN(){
            return "Subsystem1: Go!\n";
        }
    }

    public class Subsystem2{
        public string Operation1(){
            return "Subsystem2: Ready!\n";
        }
        public string OperationZ(){
            return "Subsystem2: Go!\n";
        }
    }

    class Client{
        public static void ClientCode(Facade facade){
            Console.WriteLine(facade.Operation());
        }
    }
}