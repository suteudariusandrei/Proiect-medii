using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Threading.Tasks;
using System.Threading.Tasks;


namespace ProiectMedii.Models
{
    public class MechanicList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250), Unique]
        public string Description { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(typeof(Mechanic))]
        public int ShopID { get; set; }
    }
}
