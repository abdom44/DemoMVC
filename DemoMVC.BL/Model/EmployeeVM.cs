using DemoMVC.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.BL.Model
{
    public class EmployeeVM

    {
        public EmployeeVM()
        {
            this.IsDeleted = false;
            this.CreationDate = DateTime.Now;
            this.IsUpdated = false;
        } 
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [MaxLength(50 , ErrorMessage ="max len is : 50")]
        [MinLength(3 , ErrorMessage ="min len is : 30")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Salary Required")]
        [Range(300,5000, ErrorMessage ="must between 3K:50K")]
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string? Notes { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "email invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsUpdated { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        [Required(ErrorMessage ="department required")]
        public int DepatmentId { get; set; }
        [ForeignKey("DepatmentId")]
        public Department? Department { get; set; }
    }
}
