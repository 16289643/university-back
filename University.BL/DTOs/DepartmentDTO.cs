using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class DepartmentDTO
    {
        [Required (ErrorMessage = "El campo Department ID es requerido")]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "El campo Instructor ID es requerido")]
        public int InstructorID { get; set; }


      
        public InstructorDTO Instructor { get; set; }

    }
}
