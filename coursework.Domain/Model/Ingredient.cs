namespace coursework.Domain.Model
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public IngredType Type { get; set; }

        public Ingredient(int id, string name, int weight, IngredType type)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Type = type;
        }
    }
}