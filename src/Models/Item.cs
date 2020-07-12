namespace todo.Models
{
    using Microsoft.Azure.Documents;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }



        [JsonProperty(PropertyName = "student_no")]
        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "This field must be 8 characters")]
        [Display(Name = "Student Number")]
        public string Student_Number { get; set; }


        [JsonProperty(PropertyName = "First Name")]
        [Required]
        [StringLength(20, ErrorMessage = "This field cannot contain more than 20 characters")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }


        [JsonProperty(PropertyName = "Last Name")]
        [Required]
        [StringLength(20, ErrorMessage = "This field cannot contain more than 20 characters")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [JsonProperty(PropertyName = "Email address")]
        [Display(Name = "Email address")]
        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Home Address")]
        [JsonProperty(PropertyName = "Home Address")]
        [Required]
        public string Home_Address { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.PhoneNumber)]
        [JsonProperty(PropertyName = "Contact Number")]
        [Display(Name = "Contact Number")]
        [Required()]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered Contact number format is not valid.")]
        public string Mobile { get; set; }


        [Display(Name = "Photo Path")]
        [JsonProperty(PropertyName = "Photo Path")]
        public string Photo_Path { get; set; }



        [Required]
        [JsonProperty(PropertyName = "Status")]
        [Display(Name = "Status")]
        public bool Status { get; set; }





    }
}