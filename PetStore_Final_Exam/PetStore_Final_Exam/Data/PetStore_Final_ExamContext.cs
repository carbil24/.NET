using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetStore_Final_Exam.Models;

namespace PetStore_Final_Exam.Models
{
    public class PetStore_Final_ExamContext : DbContext
    {
        public PetStore_Final_ExamContext (DbContextOptions<PetStore_Final_ExamContext> options)
            : base(options)
        {
        }

        public DbSet<PetStore_Final_Exam.Models.Owner> Owner { get; set; }

        public DbSet<PetStore_Final_Exam.Models.Pet> Pet { get; set; }
    }
}
