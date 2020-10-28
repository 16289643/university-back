
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace University.BL.DTOs

{
    public enum Grade
    {
        A, B, C, D, E
    }

    public class EnrollmentDTO
    {
        [Required(ErrorMessage = "El campo Enrollment ID es requerido")]
        public int EnrollmentID { get; set; }

        [Required(ErrorMessage = "El campo Course ID es requerido")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "El campo Studen ID es requerido")]
        public int StudentID { get; set; }

        public Grade Grade { get; set; }

       
        public CourseDTO Course { get; set; }
        public StudentDTO Student { get; set; }

    }
}
