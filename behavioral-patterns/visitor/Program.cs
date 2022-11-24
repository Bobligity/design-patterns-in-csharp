namespace VisitorPattern{
    class Program{
        static void Main(string[] args){
            List<IComponent> components = new List<IComponent>{
                new ConcreteComponentA(),
                new ConcreteComponentB()
            };

            Console.WriteLine("The client code works with all visitors via the base Visitor interface:");
            IVisitor visitor1 = new ConcreteVistor1();
            Client.ClientCode(components, visitor1);

            Console.WriteLine("It allows the same client code to work with different types of visitors:");
            IVisitor visitor2 = new ConcreteVistor2();
            Client.ClientCode(components, visitor2);
        }
    }

    public class Client{
        public static void ClientCode(List<IComponent> components, IVisitor visitor){
            foreach(IComponent component in components){
                component.Accept(visitor);
            }
        }
    }

    public interface IComponent{
        void Accept(IVisitor visitor);
    }

    public interface IVisitor{
        void VisitConcreteComponentA(ConcreteComponentA element);

        void VisitConcreteComponentB(ConcreteComponentB element);
    }

    public class ConcreteComponentA: IComponent{
        public void Accept(IVisitor visitor){
            visitor.VisitConcreteComponentA(this);
        }

        public string ExclusiveMethodOfConcreteComponentA(){
            return "A";
        }
    }

    public class ConcreteComponentB: IComponent{
        public void Accept(IVisitor visitor){
            visitor.VisitConcreteComponentB(this);
        }

        public string ExclusiveMethodOfConcreteComponentB(){
            return "B";
        }
    }

    class ConcreteVistor1: IVisitor{
        public void VisitConcreteComponentA(ConcreteComponentA element){
            Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVistor1");
        }

        public void VisitConcreteComponentB(ConcreteComponentB element){
            Console.WriteLine(element.ExclusiveMethodOfConcreteComponentB() + " + ConcreteVistor1");
        }
    }

    class ConcreteVistor2: IVisitor{
        public void VisitConcreteComponentA(ConcreteComponentA element){
            Console.WriteLine(element.ExclusiveMethodOfConcreteComponentA() + " + ConcreteVistor2");
        }

        public void VisitConcreteComponentB(ConcreteComponentB element){
            Console.WriteLine(element.ExclusiveMethodOfConcreteComponentB() + " + ConcreteVistor2");
        }
    }

}