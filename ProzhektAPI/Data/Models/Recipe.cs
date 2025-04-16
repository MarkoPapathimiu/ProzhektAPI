namespace ProzhektAPI.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; } //recipeID (Not Null)
        public required string Name { get; set; } //recipeName (Not Null)
        public string? Description { get; set; } // recipeDesc (Nullable)
    }
}
