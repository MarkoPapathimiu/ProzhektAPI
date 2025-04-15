namespace ProzhektAPI.Data.Models
{
    public class Workout
    {
        public int Id { get; set; } //workoutID (Not Null)
        public required string Name { get; set; } //workoutName (Not Null)
        public string? Description { get; set; } //workoutDesc (Nullable)

        // Favorited by [User]
        public ICollection<FavoriteWorkout>? FavoritedBy { get; set; }
    }
}
