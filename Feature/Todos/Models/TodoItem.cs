using System.ComponentModel.DataAnnotations;

namespace Feature.Todos
{
    public class TodoItem
    {
        public string Key {get; set;}
        [Required]
        public string Name { get; set;}
        [Required]
        public string Description { get; set;}
        public bool IsComplete {get;set;}
    }  
}
