namespace Blazor.Models
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public bool IsFavourite { get; set; }
        public int OwnerId { get; set; }
    }
}