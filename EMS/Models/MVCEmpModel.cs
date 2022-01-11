using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class MVCEmpModel
    {
        public long ID { get; set; }
        [Required(ErrorMessage ="this field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Department { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public decimal Salary { get; set; }
        public bool Status { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}