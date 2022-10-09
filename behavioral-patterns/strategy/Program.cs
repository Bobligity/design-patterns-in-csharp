namespace StrategyPattern{
    class Program{
        static void Main(string[] args){
            Context context = new Context();
            
            Console.WriteLine("Client: Strategy is set to normal sorting");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomething();

            Console.WriteLine("Client: Strategy is set to reverse sorting");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomething();
        }
    }

    class Context{
        private IStrategy _strategy;
        public Context(){}

        public Context(IStrategy strategy){
            this._strategy = strategy;
        }
        public void SetStrategy(IStrategy strategy){
            this._strategy = strategy;
        }

        public void DoSomething(){
            Console.WriteLine("Context: Sorting data");
            List<string> result = this._strategy.DoAlgorithm(new List<string> {"a", "b", "c", "d", "e", "f", "g", "h"});

            string resultStr = string.Empty;
            foreach(string element in result as List<string>){
                resultStr += element + ",";
            }
            Console.WriteLine(resultStr);
        }
    }

    class ConcreteStrategyA: IStrategy{
        public List<string> DoAlgorithm(List<string> data){
            data.Sort();
            return data;
        }
    }

    class ConcreteStrategyB: IStrategy{
        public List<string> DoAlgorithm(List<string> data){
            data.Sort();
            data.Reverse();
            return data;
        }
    }

    public interface IStrategy{
        List<string> DoAlgorithm(List<string> data);
    }
}