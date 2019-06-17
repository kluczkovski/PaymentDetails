using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Angular.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PaymentDetailId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CarOwnerName { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        public string CardNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string ExpirationDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(3)")]
        public string CVV{ get; set; }

        public PaymentDetail()
        {
        }

        public override string ToString()
        {
            return $"Car Name {CarOwnerName}, and Number {CardNumber}"; 
        }
    }
}
