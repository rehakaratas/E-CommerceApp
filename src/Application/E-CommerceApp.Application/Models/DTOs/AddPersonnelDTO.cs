using E_CommerceApp.Application.Extensions;
using E_CommerceApp.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Application.Models.DTOs
{
    public class AddPersonnelDTO
    {
        public Guid Id => Guid.NewGuid();

        [Required(ErrorMessage = "Cannot be Empty !!")]
        [MaxLength(25, ErrorMessage = "You Cannot Enter More Than 25 Characters..")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cannot be Empty !!")]
        [MaxLength(50, ErrorMessage = "You Cannot Enter More Than 50 Characters..")]
        public string Surname { get; set; }
        public DateTime CreatedDate => DateTime.Now;

        [BirthDateExtension(ErrorMessage = "\r\n The age of the employee must be over 18")]
        public DateTime BirthDate { get; set; }
        public Status Status => Status.Active;
        public Roles Roles => Roles.Personnel;
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }
        public string? ImagePath { get; set; }
    }
}
