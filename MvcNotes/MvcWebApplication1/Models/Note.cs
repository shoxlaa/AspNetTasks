namespace MvcWebApplication1.Models
{
    public class Note
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public string Tags { get; set; } = null!;

    }
}
