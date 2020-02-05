using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore_Final_Exam.Models
{
    public enum Breed
    {
        Dog,
        Cat,
        Fish,
        Hamster,
        Guinea_Pig
    }

    public class Pet
    {
        public int Id { get; set; }

        [Required, StringLength(10)]
        public string Name { get; set; }

        [DisplayName("Date of Birth")]
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public Breed breed { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [DisplayName("Owner Name")]
        public virtual Owner MyOwner { get; set; }

    }
}
