using System.ComponentModel.DataAnnotations;

namespace ToDoList5As.Models
{
    public class TodoList
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
