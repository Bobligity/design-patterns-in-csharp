namespace BuilderPattern{
    class Program{
        static void Main(string[] args){
            Console.WriteLine("Building a builder");
            Director director = new Director();
            ConcreteBuilder builder = new ConcreteBuilder();
            director.Builder = builder;

            director.BuildBaseProduct();
            Console.WriteLine("Building the base product!");
            Console.WriteLine(builder.GetProduct().ListParts());

            director.BuildFullProduct();
            Console.WriteLine("Building the full product!");
            Console.WriteLine(builder.GetProduct().ListParts());

            builder.BuildPartA();
            builder.BuildPartC();
            Console.WriteLine("Building a custom product!");
            Console.WriteLine(builder.GetProduct().ListParts());
        }
    }

    public interface IBuilder{
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    public class ConcreteBuilder : IBuilder{
        private Product _product = new Product();

        public ConcreteBuilder(){
            this.Reset();
        }

        public void Reset(){
            this._product = new Product();
        }

        public void BuildPartA(){
            this._product.Add("PartA");
        }
        public void BuildPartB(){
            this._product.Add("PartB");
        }
        public void BuildPartC(){
            this._product.Add("PartC");
        }

        public Product GetProduct(){
            Product result = this._product;
            this.Reset();
            return result;
        }
    }

    public class Product{
        private List<object> _parts = new List<object>();

        public void Add(string part){
            this._parts.Add(part);
        }

        public string ListParts(){
            return "Product Parts:\n" + String.Join("\n", this._parts);
        }
    }

    public class Director{
        private IBuilder? _builder;

        public IBuilder Builder{
            set {_builder = value;}
        }

        public void BuildBaseProduct(){
            this._builder!.BuildPartA();
        }
    
        public void BuildFullProduct(){
            this._builder!.BuildPartA();
            this._builder!.BuildPartB();
            this._builder!.BuildPartC();
        }
    }
}