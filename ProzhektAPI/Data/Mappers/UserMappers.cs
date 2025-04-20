using ProzhektAPI.Data.Mappers;
using ProzhektAPI.Data.Dtos;
using ProzhektAPI.Data.Models;

namespace ProzhektAPI.Data.Mappers
{
    public static class UserMappers
    {
        public static GetUserDto ToGetUserDto(User user)
        {
            return new GetUserDto
            {
                Id = user.Id,
                Username = user.Username,
                Age = user.Age,
                Height = user.Height,
                Weight = user.Weight,
                Bmi = user.Bmi
                // Password excluded for security reasons
            };
        }

        public static User ToUser(PostUserDto dto)
        {
            return new User
            {
                // Id is added automatically by the database
                Username = dto.Username,
                Password = dto.Password,
                Age = dto.Age,
                Height = dto.Height,
                Weight = dto.Weight,
                Bmi = CalculateBmi(dto.Weight, dto.Height)
            };
        }

        public static void ToPutUserDto(User user, PutUserDto dto)
        {
            // Id is already added
            // Password can't be changed
            user.Username = dto.Username;
            user.Age = dto.Age;
            user.Height = dto.Height;
            user.Weight = dto.Weight;
            user.Bmi = CalculateBmi(dto.Weight, dto.Height);
        }

        public static double CalculateBmi(int weight, int height)
        {
            double heightInMeters = height / 100.0;
            return Math.Round(weight / (heightInMeters * heightInMeters), 2);
        }
    }
}
