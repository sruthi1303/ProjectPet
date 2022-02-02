//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectPet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        [Required(ErrorMessage = "Employee ID is Required")]
        public int EmpId { get; set; }


        [Required(ErrorMessage = "Employee Name is Required")]
        [StringLength(10, MinimumLength = 3)]

        public string EmpName { get; set; }


        [Required(ErrorMessage = "Employee Mail is Required")]
        [DataType(DataType.EmailAddress)]
        public string EmpMail { get; set; }


        [Required(ErrorMessage = "Employee Gender is Required")]
        public string Gender { get; set; }
       
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Employee DOB is Required")]
        public System.DateTime DOB { get; set; }
        


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Employee DOJ is Required")]
        public System.DateTime DOJ { get; set; }


        [Required(ErrorMessage = "Employee Address is Required")]
        public string Address { get; set; }
    }
}
