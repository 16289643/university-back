using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class OfficeAssignmentDTO
    {
        [Required(ErrorMessage = "El campo Instructor ID es requerido")]
        public int InstructorID { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }


        public virtual InstructorDTO Instructor { get; set; }

    }
}
