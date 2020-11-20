using System.Collections.Generic;

namespace WithoutJoinEntity.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
