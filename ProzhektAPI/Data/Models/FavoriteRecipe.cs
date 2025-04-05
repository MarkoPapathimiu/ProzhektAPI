namespace ProzhektAPI.Data.Models
{
    public class FavoriteRecipe
    {
        public int Id { get; set; }

        public required int UserId { get; set; } // Foreign Key Users
        public required User User { get; set; }

        public required int RecipeId { get; set; } // Foreign Key Recipes
        public required Recipe Recipe { get; set; }
    }
}
