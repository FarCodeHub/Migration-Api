using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantFactory
{
    public abstract class Food
    {
        protected IOutputHandler _outputHandler;

        public Food(IOutputHandler outputHandler)
        {
            _outputHandler = outputHandler;
        }

        public int Price { get; set; }

        public Food()
        {
            Reciept = new Reciept();
        }
        public Reciept Reciept { get; set; }

        public abstract void Cook(IOutputHandler outputHandler);
    }

    

    public abstract class Pizza:Food
    {
        public Pizza() 
        {
            Reciept.AddItem(new RedSause(),100);
            Reciept.AddItem(new KalehCheese(),250);
            Reciept.AddItem(new PizzaBread(),300);
        }

    }

    public  class SteakPizza : Pizza
    {
        public SteakPizza()
        {
            Reciept.AddItem(new Meat(), 150);
        }

        public override void Cook(IOutputHandler outputHandler)
        {
            Reciept.GetByType<PizzaBread>().Print(outputHandler);
            Reciept.GetByType<RedSause>().Print(outputHandler);
            Reciept.GetByType<Meat>().Print(outputHandler);
            Reciept.GetByType<KalehCheese>().Print(outputHandler);
        }
    }

    public class VegtablePizza : Pizza
    {
        public VegtablePizza()
        {
          //  Reciept.AddItem(new Tomato(), 150);
        }

        public override void Cook()
        {
            Console.WriteLine(Reciept.Items[3]);
            Console.WriteLine(Reciept.Items[1]);
            Console.WriteLine(Reciept.Items[2]);
        }
    }
}
