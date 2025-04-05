namespace ProzhektAPI.Data.Models
{
    public class FavoriteWorkout
    {
        public int Id { get; set; }

        public required int UserId { get; set; } // Foreign Key Users
        public required User User { get; set; }

        public required int WorkoutId { get; set; } //Foreign Key Workouts
        public required Workout Workout { get; set; }

    }
}
