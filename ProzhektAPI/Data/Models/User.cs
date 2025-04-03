using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProzhektAPI.Data.Models
{
    public class User
    {
        public int Id { get; set; } //userID //mbase do duhet ta heqim kte sepse databaza e vendos vet ID
        public required string Username { get; set; } //userName (Not Null)
        public required string Password { get; set; } //password (Not Null)
        public int Age { get; set; } //userAge
        public int Height { get; set; } //userHeight
        public int Weight { get; set; } //userWeight
        public double? Bmi { get; set; } //userBMI (Nullable)
    }
}
