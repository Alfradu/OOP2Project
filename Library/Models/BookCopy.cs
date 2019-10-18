namespace Library.Models
{
    public class BookCopy
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int Condition { get; set; } //TODO: complicate later
    }
}