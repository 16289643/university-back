using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;
using University.BL.Repositories;
using University.BL.Repositories.Implements;

namespace University.BL.Services.Implements
{
    public class CourseInstructorService : GenericService<CourseInstructor>, ICourseInstructorService
    {
        public CourseInstructorService(ICourseInstructorRepository courseInstructorRepository) : base (courseInstructorRepository)
        {

        }
    }
}
