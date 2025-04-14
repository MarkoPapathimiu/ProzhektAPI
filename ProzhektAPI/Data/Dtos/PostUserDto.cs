namespace ProzhektAPI.Data.Dtos
{
    public class PostUserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        // Bmi will be calculated later
    }
}
