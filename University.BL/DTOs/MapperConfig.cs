using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.DTOs;

namespace University.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDTO>();// GET
                cfg.CreateMap<CourseDTO, Course>(); //metodos que se encargan de recibir infromacion POST-PUT

                cfg.CreateMap<CourseInstructor, CourseInstructorDTO>();
                cfg.CreateMap<CourseInstructorDTO, CourseInstructor>();

                cfg.CreateMap<Department, DepartmentDTO>();
                cfg.CreateMap<DepartmentDTO, Department>();

                cfg.CreateMap<Enrollment, EnrollmentDTO>();
                cfg.CreateMap<EnrollmentDTO, Enrollment>();

                cfg.CreateMap<Instructor, InstructorDTO>();
                cfg.CreateMap<InstructorDTO, Instructor>();

                cfg.CreateMap<OfficeAssignment, OfficeAssignmentDTO>();
                cfg.CreateMap<OfficeAssignmentDTO, OfficeAssignment>();

                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentDTO, Student>();
                  
            });
        }
    }
}
