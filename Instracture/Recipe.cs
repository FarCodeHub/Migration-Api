namespace Instracture
{
    public class Recipe  
    {
        public static string SelectFoodRecipe(string id)
        {
            var pizzaRecipe = new PizzaRecipe();
            var omletRecipe = new OmletRecipe();

            return id == "1" ? pizzaRecipe.SelectPizzaRecipe() : omletRecipe.SelectOmletRecipe();
        }
    }
}
