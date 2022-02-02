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

    public partial class Customer
    {
        [Required(ErrorMessage = "Customer ID is Required")]
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "Customer Name is Required")]
        [RegularExpression(@"(\S\D)+", ErrorMessage = " Space and numbers not allowed")]
        [StringLength(10, MinimumLength = 3)]
        public string CustomerName { get; set; }


        [Required(ErrorMessage = "Customer Mail is Required")]
        [DataType(DataType.EmailAddress)]
        public string CustomerMail { get; set; }


        [Required(ErrorMessage = "Customer Gender is Required")]
        public string CustomerGender { get; set; }

        [Required(ErrorMessage = "Phone No is Required")]
        [DataType(DataType.PhoneNumber)]
        public string CustomerPhoneNo { get; set; }

        [Required(ErrorMessage = "Customer Address is Required")]
        [DataType(DataType.Text)]
        public string CustomerAddress { get; set; }
    }
}
