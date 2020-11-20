using System.Collections.Generic;

namespace WithoutJoinEntity.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Reader> Readers { get; set; }
    }
}
