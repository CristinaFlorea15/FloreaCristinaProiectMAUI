using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FloreaCristinaProiect.Models
{
    public class Review
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Stars { get; set; } // Rating from 1 to 5
        public string Comment { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
