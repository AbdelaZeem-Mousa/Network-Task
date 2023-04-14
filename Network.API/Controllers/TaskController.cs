using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Network.API.Migrations;
using Network.API.Model;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using Network.API.Model.Filter;

namespace Network.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly APIDbContext _context;
        public TaskController(APIDbContext context)
        {
            _context = context;
        }



        [HttpGet("GetAll")]
        public IEnumerable<Student> GetAll([FromQuery] StudentFilterDto studentFilterDto)
        {


            var param = new SqlParameter("@Name", studentFilterDto.Name);
            var students =  _context.Students.FromSqlRaw("[dbo].[GetStudents] @Name", param).ToList();

            return students;
        }
        [HttpPost("AddUpdateStudent")]
        public async Task<Student> AddUpdateStudent(Student input)
        {
            if (input.Id == 0)
            {
             var saved = await  _context.Students.AddAsync(input);
                await _context.SaveChangesAsync();
                return saved.Entity;
            }
            else
            {
                var data = await _context.Students.FirstOrDefaultAsync(q => q.Id == input.Id);
                data.Age = input.Age;
                data.ContactNumber = input.ContactNumber;
                data.Name = input.Name;
                await _context.SaveChangesAsync();

                return data;
            }

        }
    }
}
