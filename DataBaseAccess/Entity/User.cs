using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess.Entity
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CNPJ { get; set; }

        public List<Transaction> Transactions { get; set; }

    }
}
