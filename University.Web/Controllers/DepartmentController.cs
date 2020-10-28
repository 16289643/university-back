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

namespace University.Web.Controllers
{
    public class DepartmentController : ApiController
    {
        private IMapper mapper;
        private readonly DepartmentService departmentService = new DepartmentService(new DepartmentRepository(UniversityContext.Create()));

        public DepartmentController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }


        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var department = await departmentService.GetAll();
            var departmentDTO = department.Select(x => mapper.Map<DepartmentDTO>(x));

            return Ok(departmentDTO); // Status code 200
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var department = await departmentService.GetById(id);
            var departmentDTO = mapper.Map<DepartmentDTO>(department);

            return Ok(departmentDTO); // Status code 200
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(DepartmentDTO departmentDTO)
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
                var department = mapper.Map<Department>(departmentDTO);

                //var course = mapper.Map<Course>(courseDTO);
                //course = await courseService.Insert(course);
                //return Ok(courseDTO); //Sastus code 400

                department = await departmentService.Insert(department);
                return Ok(departmentDTO); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }


        [HttpPut]
        public async Task<IHttpActionResult> Put(DepartmentDTO departmentDTO, int id) // object - cuerpo pero si es prmitivo por la url 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // status code 400

            if (departmentDTO.DepartmentID != id)
                return BadRequest();

            var flag = await departmentService.GetById(id);

            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                var department = mapper.Map<Department>(departmentDTO);
                department = await departmentService.Update(department);
                return Ok(department); //Sastus code 200
                //return Ok(courseDTO); //Sastus code 200
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); //Status code 500
            }
        }



        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await departmentService.GetById(id);
            if (flag == null)
                return NotFound(); // status code 404

            try
            {
                //if (!await courseService.DeleteCheckOnEntity(id))
                await departmentService.Delete(id);
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
