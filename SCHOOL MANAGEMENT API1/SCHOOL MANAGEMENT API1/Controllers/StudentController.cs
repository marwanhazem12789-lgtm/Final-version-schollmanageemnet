using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCHOOL_MANAGEMENT_API1.DTOS.StudentDto;
using SCHOOL_MANAGEMENT_API1.Mapping.StudentMapping;
using SCHOOL_MANAGEMENT_API1.Models;
<<<<<<< HEAD
using SCHOOL_MANAGEMENT_API1.Unit_Of_Work;
=======
using System.Linq;
>>>>>>> a7d6b7c3c0178f0af75572ed45f34bde0b20f48c

namespace SCHOOL_MANAGEMENT_API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork c;
        public StudentController(IUnitOfWork c , IMapper mapper)
        {
            this.c = c;

        
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = c.Students.GetAll();
            var studentsDto = mapper.Map<List<GetStudents>>(students);
            return Ok(studentsDto);
        }




        [HttpGet("Filter")]
        public ActionResult<List<GetStudents>> GetFilterStudent(int classroomId , int GradeLevel) 
        {
            var tt = c.Students.Include(b => b.ClassRoom).Where(o => o.ClassRoomId == classroomId)
                .Where(u => u.ClassRoom.GradeLevel ==  GradeLevel);

            var studentDtos = mapper.Map<List<GetStudents>>(tt);
            return Ok(studentDtos);
        }




        [HttpGet("First")]
        public ActionResult<List<GetStudents>> GetFirstStudent(int classroomId)
        {
            var tt = c.Students.Include(b => b.ClassRoom).First(o => o.ClassRoomId == classroomId);
               

            var studentDtos = mapper.Map<GetStudents>(tt);
            return Ok(studentDtos);
        }




        [HttpGet("FirstOrDefault")]
        public ActionResult<List<GetStudents>> GetFirstOrDefaultStudent(int classroomId)
        {
            var tt = c.Students.Include(b => b.ClassRoom).FirstOrDefault(o => o.ClassRoomId == classroomId);


            var studentDtos = mapper.Map<GetStudents>(tt);
            return Ok(studentDtos);
        }





        [HttpGet("Single")]
        public ActionResult<List<GetStudents>> GetSingleStudent(string Email)
        {
            var tt = c.Students.Include(b => b.ClassRoom).Single(o => o.Email == Email);


            var studentDtos = mapper.Map<GetStudents>(tt);
            return Ok(studentDtos);
        }




        [HttpGet("SingleOrDefualt")]
        public ActionResult<List<GetStudents>> GetSingleOrDefualtStudent(string Email)
        {
            var tt = c.Students.Include(b => b.ClassRoom).SingleOrDefault(o => o.Email == Email);
 

            var studentDtos = mapper.Map<GetStudents>(tt);
            return Ok(studentDtos);
        }





        [HttpGet("Last")]
        public ActionResult<List<GetStudents>> GetLastStudent(int StudentId)
        {
            var tt = c.Students.Include(b => b.ClassRoom).Include(i => i.Enrollments).OrderBy(p => p.).Last(o => o.Id == StudentId);


            var studentDtos = mapper.Map<GetStudents>(tt);
            return Ok(studentDtos);
        }





        [HttpGet("LastOrDefualt")]
        public ActionResult<List<GetStudents>> GetLastOrDefualtStudent(int StudentId)
        {
            var tt = c.Students.Include(b => b.ClassRoom).Include(o => o.Enrollments).OrderBy(p => p.Enrollments.e).LastOrDefault(o => o.Id == StudentId);


            var studentDtos = mapper.Map<GetStudents>(tt);
            return Ok(studentDtos);
        }



        [HttpGet("ElemntAt")]
        public ActionResult<GetStudents> GetElementAtStudents(int StudentId)
        {
            var tt = c.Students.Include(b => b.ClassRoom).OrderBy(l => l.Id).ElementAt(StudentId);


            var studentDtos = mapper.Map<GetStudents>(tt);
            return Ok(studentDtos);
        }


        [HttpGet("GetContainsdepartment")]
        public ActionResult<GetStudents> GetGetContainsdepartmentStudents(int StudentId)
        {
            var tt = c.Students.Include(b => b.ClassRoom).Where(l => l.ClassRoomId == StudentId);

            var studentDtos = mapper.Map<GetStudents>(tt);
            return Ok(studentDtos);
        }




        [HttpGet("Selected")]
        public ActionResult<List<GetStudents>> Selelele(int StudentId)
        {
            var tt = c.Students.Include(b => b.ClassRoom).Select(l => $"{l.FirstName} {l.LastName} " + l.ClassRoomId);

            var studentDtos = mapper.Map<GetStudents>(tt);
            return Ok(studentDtos);
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = c.Students.GetById(id);
            if (student == null)
                return NotFound($"not found.");

            var studentDto = mapper.Map<GetStudents>(student);
            return Ok(studentDto);
        }

        [HttpGet("by-classroom/{classroomId}")]
        public IActionResult GetFirstByClassRoomId(int classroomId)
        {
            var student = c.Students.GetStudentFirstByClassRoomId(classroomId);
            if (student == null)
                return NotFound($"No student found");

            var studentDto = mapper.Map<GetStudents>(student);
            return Ok(studentDto);
        }

        [HttpGet("by-email/{email}")]
        public IActionResult GetSingleByEmail(string email)
        {
            var student = c.Students.GetStudentSingle(email);
            if (student == null)
                return NotFound($"No student found");

            var studentDto = mapper.Map<GetStudents>(student);
            return Ok(studentDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentDo studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = mapper.Map<Student>(studentDto);

            c.Students.Add(student);
            c.Save();

            var readDto = mapper.Map<GetStudents>(student);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateStudent studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingStudent = c.Students.GetById(id);
            if (existingStudent == null)
                return NotFound($"not found.");

            mapper.Map(studentDto, existingStudent);

            c.Students.Update(existingStudent);
            c.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = c.Students.GetById(id);
            if (student == null)
                return NotFound($"not found.");

            c.Students.Delete(id);
            c.Save();

            return NoContent();
        }














        ////////////////////////////////////////////////////////////////////////

        //[HttpGet("filter")]
        //public IActionResult GetStudentFilter(int ClassRoomId, int minGrade)
        //{
        //    var s = c.Students
        //        .Include(i => i.ClassRoom)
        //        .Where(p => p.ClassRoomId == ClassRoomId && p.Enrollments.Any(e => e.Grade >= minGrade))
        //        .ToList();

        //    var studentDtos = mapper.Map<List<GetStudents>>(s);
        //    return Ok(studentDtos);
        //}

        //[HttpGet("first")]
        //public IActionResult GetStudentFirst(int ClassRoomId)
        //{
        //    var s = c.Students.Include(o => o.ClassRoom).First(p => p.ClassRoomId == ClassRoomId);
        //    var i = mapper.Map<GetStudentsById>(s);
        //    return Ok(i);
        //}

        //[HttpGet("first-or-default")]
        //public IActionResult GetStudentfirstOrDefault(int ClassRoomId)
        //{
        //    var s = c.Students.Include(o => o.ClassRoom).FirstOrDefault(p => p.ClassRoomId == ClassRoomId);
        //    if (s == null) return NotFound();

        //    var i = mapper.Map<GetStudentsById>(s);
        //    return Ok(i);
        //}

        //[HttpGet("single-by-email/{email}")]
        //public IActionResult GetStudentSingle(string email)
        //{
        //    var s = c.Students.Include(o => o.ClassRoom).Single(p => p.Email == email);
        //    var i = mapper.Map<GetStudentsById>(s);
        //    return Ok(i);
        //}

        //[HttpGet("single-or-default/{email}")]
        //public IActionResult GetStudentsingleOrDefault(string email)
        //{
        //    var s = c.Students.Include(o => o.ClassRoom).SingleOrDefault(p => p.Email == email);
        //    if (s == null) return NotFound();

        //    var i = mapper.Map<GetStudentsById>(s);
        //    return Ok(i);
        //}

        //[HttpGet("at/{index}")]
        //public IActionResult GetStudentAtIndex(int index)
        //{
        //    var s = c.Students
        //        .OrderBy(s => s.Id)
        //        .AsEnumerable()
        //        .ElementAt(index);

        //    var i = mapper.Map<GetStudentsById>(s);
        //    return Ok(i);
        //}

        //[HttpGet("all-have-phone/{classRoomId}")]
        //public IActionResult CheckPhone(int classRoomId)
        //{
        //    var x = c.Students
        //        .Where(s => s.ClassRoomId == classRoomId)
        //        .All(s => !string.IsNullOrEmpty(s.PhoneNumber));

        //    return Ok(x);
        //}

        //[HttpGet("contains-classroom/{classRoomId}")]
        //public IActionResult ContainClass(int classRoomId)
        //{
        //    var list = c.Students.Select(s => s.ClassRoomId).ToList();
        //    var res = list.Contains(classRoomId);
        //    return Ok(res);
        //}

        //[HttpGet("select")]
        //public IActionResult GetSelected(int classRoomId)
        //{
        //    var res = c.Students
        //        .Where(s => s.ClassRoomId == classRoomId)
        //        .Select(s => new { s.Id, FullName = s.FirstName + " " + s.LastName })
        //        .ToList();

        //    return Ok(res);
        //}

        //[HttpGet("basic-info")]
        //public IActionResult GetInfo(int classRoomId)
        //{
        //    var res = c.Students
        //        .Where(s => s.ClassRoomId == classRoomId)
        //        .Select(s => new { s.Id, FullName = s.FirstName + " " + s.LastName, s.Email })
        //        .ToList();

        //    return Ok(res);
        //}

        //[HttpGet("order-by-name")]
        //public IActionResult OrderName()
        //{
        //    var s = c.Students.OrderBy(s => s.LastName).ToList();
        //    var dtos = mapper.Map<List<GetStudents>>(s);
        //    return Ok(dtos);
        //}

        //[HttpGet("order-by-grade-desc")]
        //public IActionResult OrderGradeDesc(int classRoomId)
        //{
        //    var s = c.Students
        //        .Where(s => s.ClassRoomId == classRoomId)
        //        .OrderByDescending(s => s.Enrollments.Max(e => e.Grade))
        //        .ToList();

        //    var dtos = mapper.Map<List<GetStudents>>(s);
        //    return Ok(dtos);
        //}

        //[HttpGet("order-by-classroom")]
        //public IActionResult OrderClassThenName()
        //{
        //    var s = c.Students
        //        .OrderBy(s => s.ClassRoomId)
        //        .ThenBy(s => s.LastName)
        //        .ToList();

        //    var dtos = mapper.Map<List<GetStudents>>(s);
        //    return Ok(dtos);
        //}

        //[HttpGet("order-by-classroom-grade")]
        //public IActionResult OrderClassThenGrade()
        //{
        //    var s = c.Students
        //        .OrderBy(s => s.ClassRoomId)
        //        .ThenByDescending(s => s.Enrollments.Max(e => e.Grade))
        //        .ToList();

        //    var dtos = mapper.Map<List<GetStudents>>(s);
        //    return Ok(dtos);
        //}




    }
}
