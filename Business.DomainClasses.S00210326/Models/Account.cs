using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainClasses.S00210326.Models
{
    public class Account
    {

        [Key]
        public int Id { get; set; }

        public string AccountName { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime InceptionDate { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]

        public virtual Customer Customer { get; set; }

        public decimal CurrentBalance { get; set; }

        public int AccountTypeID {get;set;}

       


        
    }
}
