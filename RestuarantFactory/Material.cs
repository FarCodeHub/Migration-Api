using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestuarantFactory
{
    public interface IMaterial
    {
         string Brand { get; set; }
         int Price { get; set; }
         int Quantity { get; set; }

         void Print(IOutputHandler outputHandler);

    }
    public  abstract class Material: IMaterial
    {

        public Material()
        {
            Quantity = 1;
        }
        public string Brand { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public abstract void Print(IOutputHandler outputHandler);
    }

    public abstract class Sause : Material
    {
      
    }

    public  class Meat : Material
    {


        public override void Print(IOutputHandler outputHandler)
        {
            throw new NotImplementedException();
        }
    }

    public class RedSause : Sause
    {
        public RedSause()
        {
            Brand = "Mahram";
            Price = 1000;
        }

        public override void Print(IOutputHandler outputHandler)
        {
            outputHandler.Write(Brand+" "+Price);
        }
    }

    public class WhiteSause : Sause
    {
        public WhiteSause()
        {
            Brand = "Mahram";
            Price = 1100;
        }

        public override void Print(IOutputHandler outputHandler)
        {
            outputHandler.Write(Brand + " " + Price);
        }
    }

    public abstract class Cheese : Material
    {

    }

    public class KalehCheese : Cheese
    {
        public KalehCheese()
        {
            Brand = "Caleh";
            Price = 2000;
        }

        public override void Print(IOutputHandler outputHandler)
        {
            outputHandler.Write(Brand + " " + Price);
        }
    }

    public abstract class Bread : Material
    {

    }

    public class HamburgerBread : Bread
    {
        public HamburgerBread()
        {
            Brand = "CaAgharleh";
            Price = 2000;
        }

        public override void Print(IOutputHandler outputHandler)
        {
            outputHandler.Write(Brand + " " + Price);
       
        }
    }

    public class PizzaBread : Bread
    {
        public PizzaBread()
        {
            Brand = "CaAgharleh";
            Price = 2000;
        }

        public override void Print(IOutputHandler outputHandler)
        {
            Console.WriteLine(Brand + ":" + Price);
            File.WriteAllText("C://", Brand + ":" + Price);
        }
    }

    public class BuggetBread : Bread
    {
        public BuggetBread()
        {
            Brand = "CaAgharleh";
            Price = 2000;
        }

        public override void Print(IOutputHandler outputHandler)
        {
            Console.WriteLine(Brand + ":" + Price);
            File.WriteAllText("C://", Brand + ":" + Price);
        }
    }


}
