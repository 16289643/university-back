using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.BL.DTOs
{
    public class CourseInstructorDTO
    {
        [Required (ErrorMessage = "El campo CourseInstructor ID es requerido")]
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo Course ID es requerido")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "El campo Instructor ID es requerido")]
        public int InstructorID { get; set; }


        public InstructorDTO instructor { get; set; }
        public CourseDTO Course { get; set; }
    }
}
