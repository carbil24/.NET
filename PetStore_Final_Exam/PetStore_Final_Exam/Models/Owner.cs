using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Final_Exam.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string FullName { get; set; }

        [Required, StringLength(20)]
        public string Street { get; set; }

        [Required, StringLength(20)]
        public string City { get; set; }

        [Required, EmailAddress]
        public string EmailAddress { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required, StringLength(20)]
        public string Occupation { get; set; }


        public virtual ICollection<Pet> MyPets { get; set; }
    }
}
