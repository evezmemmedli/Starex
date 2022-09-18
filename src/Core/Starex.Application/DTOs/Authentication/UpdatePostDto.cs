using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starex.Application.DTOs.Authentication
{
    public class UpdatePostDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }
        public int DeliveryPointId { get; set; }
        public int PoctAdressId { get; set; }
        public string IdentityNumber { get; set; }
        public string Fin { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewConfirmPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
