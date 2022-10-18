using System.ComponentModel.DataAnnotations;

namespace ToDoList5As.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
