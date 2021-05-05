using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NET5_test.Models
{
    public class Expense
    {
        [Key]
        public int Id{ get; set; }

        public double Price { get; set; }

        [DisplayName("Expense Name")]
        public string ExpenseName { get; set; }

        //IEnumerable<Expense> objList
        public double Suma()
        {
            return 10.0;
 
        }


    }
}
