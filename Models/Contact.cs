using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models.Contacts{
    public class Contact{
        [Key]
        public int Id {get; set;}
        [Column(TypeName="nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage ="Phai nhap {0}")]
        [DisplayName("Ho ten")]
        public string FullName{set; get;}
        [Required(ErrorMessage = "Phai nhap {0}")]
        [StringLength(100)]
        [DisplayName("Dia chi Email")]
        [EmailAddress(ErrorMessage ="Phai la dia chi email")]
        public string Email {get; set;}
        public DateTime DateSent{get; set;}

        [DisplayName("Noi dung")]
        public string Message{set; get;}

        [StringLength(50)]
        [Phone(ErrorMessage ="Phai la so dien thoai")]
        [DisplayName("So dien thoai")]
        public string Phone {set;get;}
    }
}