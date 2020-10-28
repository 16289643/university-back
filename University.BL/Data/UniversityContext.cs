using System.Data.Entity;
using University.BL.Models;
using System.Data.SqlClient;

namespace University.BL.Data
{


    public class UniversityContext : DbContext
    {
        
        
        public UniversityContext()
            : base ("UniversityContext")
            //: base(@"Server=DESKTOP-OTC56SV\SQLEXPRESS;Database=University;Integrated Security=True")
        { 
            
        }
          
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Student> Students { get; set; }
        

        public static UniversityContext Create()
        {
            return new UniversityContext();
        }


    }
}



//public int ID {get; set;}
//public string Name {get; set;}

//atajos
// ctrl + k + d Formatear el codigo y acomodarlo
//ctrl + k + c Comentamos todo un bloque
// ctrl + k + u descomentamos todo un bloque
//Ctrl + k + s Rodeamos el codigo
// prop (doble tab)
// Ctrl + d con el click al final de la liena copia rapido
//despues de inicar un for se le da Tab y costruye todo
//ctor (doble tab) contruye el metodo constructor



