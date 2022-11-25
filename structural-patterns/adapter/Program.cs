namespace AdapterPattern{
    class Program{
        static void Main(string[] args){
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client");
            Console.WriteLine("But with the adapter, client can cal it's method");

            Console.WriteLine(target.GetRequest());
        }
    }

    public interface ITarget{
        string GetRequest();
    }

    class Adaptee{
        public string GetSpecificRequest(){
            return "Specific Request.";
        }
    }

    class Adapter: ITarget{
        private readonly Adaptee _adaptee;
        public Adapter(Adaptee adaptee){
            this._adaptee = adaptee;
        }

        public string GetRequest(){
            return $"This is '{this._adaptee.GetSpecificRequest()}'";
        }
    }
}