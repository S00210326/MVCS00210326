using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainClasses.S00210326.Models
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }

        public int TransactionType { get; set; }

        //[EnumDataType(typeof(TransactionType))]
        //public virtual TransactionType Transactiontype { get; set; }

        public decimal Ammount { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        public int AccountID { get; set; }
        [ForeignKey("AccountID")]

        public virtual Account Account { get; set; }








    }
   
}
