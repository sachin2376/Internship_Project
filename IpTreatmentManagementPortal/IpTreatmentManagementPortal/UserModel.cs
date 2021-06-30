using System;
using System.ComponentModel.DataAnnotations;

namespace IpTreatmentManagementPortal
{
    public class UserModel
    {

        [Key]
        [Required]
        [StringLength(10,ErrorMessage ="Username Too Long"),MinLength(4,ErrorMessage ="Username Too Short")]
        [DataType("varchar 25")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password Too Long"), MinLength(4, ErrorMessage = "Username Too Short")]
        [DataType("varchar 100")]
        public string Password { get; set; }
    }
    
}
