namespace ProzhektAPI.Data.Models
{
    public class FavoriteWorkout
    {
        public int Id { get; set; }

        public int UserId { get; set; } // Foreign Key Users
        public User? User { get; set; }

        public int WorkoutId { get; set; } //Foreign Key Workouts
        public Workout? Workout { get; set; }

    }
}
