using PermissionManager.Domain.DataAnnota;
using System;
using System.ComponentModel.DataAnnotations;

namespace PermissionManager.Domain.DTO
{
    public class PermissionDTO
    {
        [Key]
        public int PermissionId { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido.")]
        [StringLength(50, ErrorMessage = "El campo nombre solo permite 50 caracteres.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El campo apellido es requerido.")]
        [StringLength(50, ErrorMessage = "El campo apellido solo permite 50 caracteres.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El campo tipo permiso es requerido.")]
        public int PermissionTypeId { get; set; }
        [FutureDate]
        public DateTime PermissionDate { get; set; }
        public string Description { get; set; }
    }
}
