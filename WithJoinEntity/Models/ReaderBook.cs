namespace WithJoinEntity.Models
{
    public class ReaderBook
    {
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public Book Book { get; set; }
        public Reader Reader { get; set; }
    }
}
