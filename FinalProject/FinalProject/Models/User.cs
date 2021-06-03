using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //first name and last name 
        [Required]
        [Column(TypeName ="varchar(150)")]
        public string FirstName { get; set; }


        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Lastname { get; set; }

        //Username credentials
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Password { get; set; }

    }
}
