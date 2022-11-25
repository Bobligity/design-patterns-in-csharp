namespace BridgePattern{
    class Program{
        static void Main(string[] args){
            Client client = new Client();

            Abstraction abstraction = new Abstraction(new ConcreteImplementationA());
            client.ClientCode(abstraction);

            abstraction = new Abstraction(new ConcreteImplementationB());
            client.ClientCode(abstraction);
        }
    }

    class Abstraction{
        protected IImplementation _implementation;

        public Abstraction(IImplementation implementation){
            this._implementation = implementation;
        }

        public virtual string Operation(){
            return "Abstract: Base operation with :\n\t" + _implementation.OperationImplementation();
        }
    }

    class ExtendedAbstraction : Abstraction{
        public ExtendedAbstraction(IImplementation implementation): base(implementation){}

        public override string Operation()
        {
            return "ExtendedAbstraction: Extended operation with :\n\t" + base._implementation.OperationImplementation();
        }
    }

    public interface IImplementation{
        string OperationImplementation();
    }

    class ConcreteImplementationA: IImplementation{
        public string OperationImplementation(){
            return "ConcreteImplementationA: The result in platform A";
        }
    }

    class ConcreteImplementationB: IImplementation{
        public string OperationImplementation(){
            return "ConcreteImplementationB: The result in platform B";
        }
    }

    class Client{
        public void ClientCode(Abstraction abstraction){
            Console.WriteLine(abstraction.Operation());
        }
    }
}