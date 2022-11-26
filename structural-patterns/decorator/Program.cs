namespace DecoratorPatter{
    class Program{
        static void Main(string[] args){
            Client client = new Client();

            Component simple = new ConcreteComponent();
            Console.WriteLine("Client: I got a simple component:");
            client.ClientCode(simple);

            ConcreteDecoratorA decoratorA = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decoratorB = new ConcreteDecoratorB(decoratorA);
            Console.WriteLine("Client: Now I have a decorated component");
            client.ClientCode(decoratorB);
        }
    }

    public abstract class Component{
        public abstract string Operation();
    }

    class ConcreteComponent: Component{
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    abstract class Decorator: Component{
        protected Component _component;

        public Decorator(Component component){
            this._component = component;
        }

        public void SetComponent(Component component){
            this._component = component;
        }

        public override string Operation(){
            if(this._component != null){
                return this._component.Operation();
            } else {
                return string.Empty;
            }
        }
    }

    class ConcreteDecoratorA: Decorator{
        public ConcreteDecoratorA(Component component): base(component){}

        public override string Operation(){
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    class ConcreteDecoratorB: Decorator{
        public ConcreteDecoratorB(Component component): base(component){}

        public override string Operation(){
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }

    public class Client{
        public void ClientCode(Component component){
            Console.WriteLine($"Result: {component.Operation()}");
        }
    }
}