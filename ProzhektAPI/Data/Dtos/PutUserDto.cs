namespace ProzhektAPI.Data.Dtos
{
    public class PutUserDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        // Bmi will be updated automatically
        // Password can't be changed
    }
}
