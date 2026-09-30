using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCHOOL_MANAGEMENT_API1.DTOS.StudentDto;
using SCHOOL_MANAGEMENT_API1.DTOS.TeacherDtos;
using SCHOOL_MANAGEMENT_API1.Mapping.TeacherMapping;
using SCHOOL_MANAGEMENT_API1.Models;
using SCHOOL_MANAGEMENT_API1.Unit_Of_Work;

namespace SCHOOL_MANAGEMENT_API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IUnitOfWork c;
        private readonly IMapper _mapper;

        public TeachersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            c = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teachers = c.Teachers.GetAll();
            var dtos = _mapper.Map<List<GetTeachers>>(teachers);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = c.Teachers.GetById(id);
            if (teacher == null)
                return NotFound($"not found.");

            var dto = _mapper.Map<GetTeachers>(teacher);
            return Ok(dto);
        }

        [HttpGet("filter")]
        public IActionResult FilterTeachers(int departmentId,  double minSalary)
        {
            var teachers = c.Teachers.FilterTeachers(departmentId, minSalary);
            var dtos = _mapper.Map<List<GetTeachers>>(teachers);
            return Ok(dtos);
        }

        [HttpGet("by-email/{email}")]
        public IActionResult GetTeacherByEmail(string email)
        {
            var teacher = c.Teachers.GetTeacherByEmail(email);
            if (teacher == null)
                return NotFound($"No teacher found");

            var dto = _mapper.Map<GetTeachers>(teacher);
            return Ok(dto);
        }

        [HttpGet("{id}/has-subjects")]
        public IActionResult HasSubjects(int id)
        {
            var hasSubjects = c.Teachers.HasSubjects(id);
            return Ok(new { TeacherId = id, HasSubjects = hasSubjects });
        }

        [HttpGet("names-in-department/{departmentId}")]
        public IActionResult GetTeacherNamesInDepartment(int departmentId)
        {
            var result = c.Teachers.GetTeacherNamesInDepartment(departmentId);
            return Ok(result);
        }

        [HttpGet("ordered-by-salary")]
        public IActionResult GetTeachersOrderedBySalary()
        {
            var teachers = c.Teachers.GetTeachersOrderedBySalary();
            var dtos = _mapper.Map<List<GetTeachers>>(teachers);
            return Ok(dtos);
        }
        [HttpGet("ordered-by-dept-and-lastname")]
        public IActionResult GetTeachersOrderedByDeptAndLastName()
        {
            var teachers = c.Teachers.GetTeachersOrderedByDeptAndLastName();
            var dtos = _mapper.Map<List<GetTeachers>>(teachers);
            return Ok(dtos);
        }

        [HttpGet("average-salary/{departmentId}")]
        public IActionResult GetAverageSalary(int departmentId)
        {
            var avgSalary = c.Teachers.GetAverageSalary(departmentId);
            return Ok(new { DepartmentId = departmentId, AverageSalary = avgSalary });
        }

        [HttpGet("max-salary/{departmentId}")]
        public IActionResult GetMaxSalary(int departmentId)
        {
            var maxSalary = c.Teachers.GetMaxSalary(departmentId);
            return Ok(new { DepartmentId = departmentId, MaxSalary = maxSalary });
        }

        [HttpGet("group-by-department")]
        public IActionResult GroupTeachersByDepartment()
        {
            var grouped = c.Teachers.GroupTeachersByDepartment();
            return Ok(grouped);
        }

        [HttpGet("distinct-departments")]
        public IActionResult GetDistinctDepartmentIds()
        {
            var deptIds = c.Teachers.GetDistinctDepartmentIds();
            return Ok(deptIds);
        }

        [HttpGet("union-dept-teachers")]
        public IActionResult GetUnionDepartmentTeacherIds([FromQuery] int dept1, [FromQuery] int dept2)
        {
            var ids = c.Teachers.GetUnionDepartmentTeacherIds(dept1, dept2);
            return Ok(ids);
        }

        [HttpGet("except-dept-teachers")]
        public IActionResult GetExceptDepartmentTeacherIds([FromQuery] int dept1, [FromQuery] int dept2)
        {
            var ids = c.Teachers.GetExceptDepartmentTeacherIds(dept1, dept2);
            return Ok(ids);
        }

        [HttpGet("dictionary/{departmentId}")]
        public IActionResult GetTeachersDictionary(int departmentId)
        {
            var dict = c.Teachers.GetTeachersDictionary(departmentId);
            return Ok(dict);
        }

        [HttpGet("deferred/{departmentId}")]
        public IActionResult GetDeferredQuery(int departmentId)
        {
            var query = c.Teachers.GetDeferredQuery(departmentId);
            var teachers = query.ToList(); 
            var dtos = _mapper.Map<List<GetTeachers>>(teachers);
            return Ok(dtos);
        }

        // 17. SKIP TEACHERS
        [HttpGet("skip/{count}")]
        public IActionResult SkipTeachers(int count)
        {
            var teachers = c.Teachers.SkipTeachers(count);
            var dtos = _mapper.Map<List<GetTeachers>>(teachers);
            return Ok(dtos);
        }

        [HttpGet("paged")]
        public IActionResult GetPagedTeachers(
             int pageNumber = 1,
             int pageSize = 10,
            int departmentId = 0,
             double minSalary = 0)
        {
            var teachers = c.Teachers.GetPagedTeachers(pageNumber, pageSize, departmentId, minSalary);
            var dtos = _mapper.Map<List<GetTeachers>>(teachers);
            return Ok(dtos);
        }

        [HttpPost]
        public IActionResult Create( CraeteeacherDto teacherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var teacher = _mapper.Map<Teacher>(teacherDto);

            c.Teachers.Add(teacher);
            c.Save();

            return Created();
        }

        // 20. UPDATE TEACHER
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTeacher teacherDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingTeacher = c.Teachers.GetById(id);
            if (existingTeacher == null)
                return NotFound($"not found");

            _mapper.Map(teacherDto, existingTeacher);

            c.Teachers.Update(existingTeacher);
            c.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = c.Teachers.GetById(id);
            if (teacher == null)
                return NotFound($"not found.");

            c.Teachers.Delete(id);
            c.Save();

            return  NoContent();
        }
    }
}
