using System.ComponentModel.DataAnnotations;

namespace CoreTechs.Web.Models.ModelEntities
{
    public class Employees
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        public string Salary { get; set; }
    }
}
