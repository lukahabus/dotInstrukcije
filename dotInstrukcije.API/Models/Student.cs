﻿namespace dotInstrukcije.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
