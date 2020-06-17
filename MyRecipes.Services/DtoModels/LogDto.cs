using System;

namespace MyRecipes.Services.DtoModels
{
    public class LogDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Endpoint { get; set; }

        public string Message { get; set; }

        public int? UserId { get; set; }
    }
}
