using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FloreaCristinaProiect.Models
{
    public class PastriesList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string Ingredients { get; set; }

        public int Price { get; set; }

        [MaxLength(5000)]
        public string PastriesImage { get; set; }

    }

}
