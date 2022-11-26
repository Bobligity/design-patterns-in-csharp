namespace ProxyPattern{
    class Program{
        static void Main(string[] args){
            Client client = new Client();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine("Client: Executing the client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy);

            
        }
    }

    public interface ISubject{
        void Request();
    }

    class RealSubject: ISubject{
        public void Request(){
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    class Proxy: ISubject{
        private RealSubject _realSubject;
        public Proxy(RealSubject realSubject){
            this._realSubject = realSubject;
        }

        public void Request(){
            if(this.CheckAccess()){
                this._realSubject.Request();
                this.LogAccess();
            }
        }

        public bool CheckAccess(){
            Console.WriteLine("Proxy: Checking acess prior to firing a real Request.");
            return true;
        }

        public void LogAccess(){
            Console.WriteLine("Proxy: Logging the time of Request");
        }
    }

    class Client{
        public void ClientCode(ISubject subject){
            subject.Request();
        }
    }
}