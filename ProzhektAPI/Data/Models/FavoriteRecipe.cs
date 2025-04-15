namespace ProzhektAPI.Data.Models
{
    public class FavoriteRecipe
    {
        public int Id { get; set; }

        public int UserId { get; set; } // Foreign Key Users
        public User? User { get; set; }

        public int RecipeId { get; set; } // Foreign Key Recipes
        public Recipe? Recipe { get; set; }
    }
}
