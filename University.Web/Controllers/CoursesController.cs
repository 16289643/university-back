using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using University.BL.Data;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;
using University.BL.DTOs;
using University.BL.Models;
using System.Web.Http.Description;

namespace University.Web.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private IMapper mapper;
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Obtiene los objetos de cursos
        ///</summary>
        ///<returns>Listado de los Obejtos de cursos</returns>
        ///<response code="200">Ok. Devuelve el listado de objetos solicitados.</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<CourseDTO>))]
        public async Task<IHttpActionResult> Get()
        {
            var courses = await courseService.GetAll();
            var coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));

            return Ok(coursesDTO); // Status code 200
        }

        /// <summary>
        /// Obtiene un objeto Course por su Id
        ///</summary>
        ///<remarks>
        ///Aqui una descripcion mas larga si fuera necesario. Obtiene un objeto por su Id
        ///</remarks>
        ///<param name="id">Id del Objeto</param>
        ///<returns>Objeto Course</returns>
        ///<response code="200">Ok. Devuelve el Objeto solicitados.</response>
        ///<response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet]
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var course = await courseService.GetById(id);
            var courseDTO = mapper.Map<CourseDTO>(course);

            return Ok(courseDTO); // Status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // status code 400

            //var course = new CourseDTO
            //{
            //    CourseId = courseDTO.CourseId,
            //    Title = courseDTO.Title,
            //    Credits = courseDTO.Credits
            //};

            //Ctrl + K + S Redondear el codigo
            try
            {
                var course = mapper.Map<Course>(courseDTO);

                //var course = mapper.Map<Course>(courseDTO);
                //course = await courseService.Insert(course);
                //return Ok(courseDTO); //Sastus code 400

                course = await courseService.Insert(course);
                return Ok(courseDTO); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }  
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id) // object - cuerpo pero si es prmitivo por la url 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // status code 400

            if (courseDTO.CourseId != id)
                return BadRequest();

            var flag = await courseService.GetById(id);

            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Update(course);
                return Ok(course); //Sastus code 200
                //return Ok(courseDTO); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }



        [HttpDelete]
        public async Task<IHttpActionResult> Delete( int id)
        { 
            var flag = await courseService.GetById(id);
            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                //if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);
                //else
                   // throw new Exception("ForengKeys");

                return Ok(); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }


    }
}
