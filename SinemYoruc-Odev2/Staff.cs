using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinemYoruc_Odev2
{
    public class Staff
    {
        public long Id { get; set; }

        [StringLength(maximumLength: 120, MinimumLength = 20, ErrorMessage = "Name must be range in 20-120")] //Name alani 20 ve 120 karakter arasinda olmali
        [RegularExpression(@"^[a-zA-Z\s]*$")] //Rakamlara ve ozel karakterlere izin verilmiyor, bosluklara izin veriliyor
        public string Name { get; set; }


        [StringLength(maximumLength: 120, MinimumLength = 20, ErrorMessage = "Lastname must be range in 20-120")] //Lastname alani 20 ve 120 karakter arasinda olmali
        [RegularExpression(@"^[a-zA-Z\s]*$")] //Rakamlara ve ozel karakterlere izin verilmiyor, bosluklara izin veriliyor
        public string Lastname { get; set; }


        //[RegularExpression(@"[0-9]{2}[\/\-\.][0-9]{2}[\/\-\.][0-9]{2,4}")]       //DateTime formatina uymadigi için hata aliyor, degisken string olursa calisir
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "11/11/1945", "10/10/2002")] //dogum tarihi 11/11/1945 ve 10/10/2002 arasinda olmali
        [Required]
        public DateTime DateOfBirth { get; set; }


         [Required]
         [EmailAddress(ErrorMessage = "Email address is not valid.")] //@ ve . kontrolu yapiliyor
        [RegularExpression(@"^[a-zA-Z]*$")]
        public string Email { get; set; }



         [Required]
         [RegularExpression(@"^[+]905[0-9]{9}$")]  //Telefon numarasının +905 ile baslayıp 9 rakam daha ekleme validasyonu
         [Phone(ErrorMessage = "Phone is not valid.")] 
         public string PhoneNumber { get; set; }




         [Range(minimum: 2000, maximum: 9000, ErrorMessage = "Salary must be range in 2000-9000")] //Maas 2000 ve 9000 arasinda olmali
         public double Salary { get; set; }
    }
}
