using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Day13Demos.Models
{
   // [Table("tblEmployee")]
    class Employee
    {
     //   [Key]
        public int Id { get; set; }
        
//        [Required]
        public string Name { get; set; }
        public string Department { get; set; }
        public string Manager { get; set; }
        public double Salary { get; set; }
    }
}
