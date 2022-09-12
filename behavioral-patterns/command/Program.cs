namespace CommandPattern{
    class Program{
        static void Main(string[] args){
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new SimpleCommand("Hello, world!"));

            Receiver receiver = new Receiver();
            invoker.SetOnFinish(new ComplexCommand(receiver, "Send text", "Save picture"));

            invoker.DoSomethingImportant();
        }
    }

    public interface ICommand{
        void Execute();
    }

    class SimpleCommand : ICommand{
        private string _payload = string.Empty;

        public SimpleCommand(string payload){
            this._payload = payload;
        }

        public void Execute(){
            Console.WriteLine($"SimpleCommand with a simple plan: print \"{this._payload}\"");
        }
    }

    class ComplexCommand : ICommand{
        private Receiver _receiver;
        private string _a, _b;

        public ComplexCommand(Receiver receiver, string a, string b){
            this._receiver = receiver;
            this._a = a;
            this._b = b;
        }

        public void Execute(){
            Console.WriteLine("ComplexCommand: complex stuff being done by some business consumer.");
            this._receiver.DoSomething(this._a);
            this._receiver.DoSomethingElse(this._b);
        }
    }

    class Receiver{
        public void DoSomething(string a){
            Console.WriteLine($"Receiver: Working on ({a}.)");
        }

        public void DoSomethingElse(string b){
            Console.WriteLine($"Receiver: Working on ({b}.)");
        }
    }

    class Invoker{
        private ICommand _onStart, _onFinish;

        public void SetOnStart(ICommand command){
            this._onStart = command;
        }
        public void SetOnFinish(ICommand command){
            this._onFinish = command;
        }

        public void DoSomethingImportant(){
            Console.WriteLine("Invoker: Does anybody want something done before I begin?");
            if(this._onStart is ICommand){
                this._onStart.Execute();
            }

            Console.WriteLine("Invoker: Doing something important...");

            Console.WriteLine("Invoker: Does anybody want something done after I finish?");
            if(this._onFinish is ICommand){
                this._onFinish.Execute();
            }            
        }
    }

}