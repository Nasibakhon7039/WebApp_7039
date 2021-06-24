using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WAD.WebApp._7039.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int? DepartmentId { get; set; }

        public JobPosition JobPosition { get; set; }

        public string Salary { get; set; }

        public virtual Department Department { get; set; }
    }

    public enum JobPosition
    {
        Developer,
        QA,
        ProjectManager,
        SalesManager,
        HR
    }
}
