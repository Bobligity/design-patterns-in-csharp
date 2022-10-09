using System;

namespace TemplatePattern{
    class Program{
        static void Main(string[] args){
            Console.WriteLine("Same Client code  can work with different subclasses");
            Client.ClientCode(new ConcreteClass1());

            Console.WriteLine("\nSame Client code can work with different subclasses");
            Client.ClientCode(new ConcreteClass2());
        }
    }

    abstract class AbstractClass{
        public void TemplateMethod(){
            this.BaseOperation1();
            this.RequiredOperation1();
            this.BaseOperation2();
            this.Hook1();
            this.RequiredOperation2();
            this.BaseOperation3();
            this.Hook2();
        }

        protected void BaseOperation1(){
            Console.WriteLine("AC says: I am doing some work");
        }

        protected void BaseOperation2(){
            Console.WriteLine("AC says: I am doing some more work");
        }

        protected void BaseOperation3(){
            Console.WriteLine("AC says: I am doing the rest of the work");
        }

        protected abstract void RequiredOperation1();
        protected abstract void RequiredOperation2();

        protected virtual void Hook1(){}
        protected virtual void Hook2(){}
    }

    class ConcreteClass1: AbstractClass{
        protected override void RequiredOperation1()
        {
            Console.WriteLine("ConcreteClass1 says: I am doing Operation1");
        }

        protected override void RequiredOperation2()
        {
            Console.WriteLine("ConcreteClass1 says: I am doing Operation2");
        }
    }

    class ConcreteClass2: AbstractClass{
        protected override void RequiredOperation1()
        {
            Console.WriteLine("ConcreteClass2 says: I am doing Operation1");
        }

        protected override void RequiredOperation2()
        {
            Console.WriteLine("ConcreteClass2 says: I am doing Operation2");
        }
        
        protected override void Hook1(){
            Console.WriteLine("ConcreteClass2 says: I am doing Hook1");
        }
    }

    class Client{
        public static void ClientCode(AbstractClass abstractClass){
            abstractClass.TemplateMethod();
        }
    }
}