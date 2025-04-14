namespace ProzhektAPI.Data.Dtos
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public double Bmi { get; set; }
        // Password is excluded for privacy
    }
}
