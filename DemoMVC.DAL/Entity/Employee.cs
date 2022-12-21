using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.DAL.Entity

{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string? Notes { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsUpdated { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int DepatmentId { get; set; }
        [ForeignKey("DepatmentId")]
        public Department? Department { get; set; }
        public int? DistrictId { get; set; }
        public District District { get; set; }
        public string? ImageName { get; set; }
        public string? CVName { get; set; }
    }
}
