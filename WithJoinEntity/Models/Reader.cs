using System.Collections.Generic;

namespace WithJoinEntity.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<ReaderBook> ReaderBooks { get; set; }

    }
}
