using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCHOOL_MANAGEMENT_API1.DTOS.ClassRoomDto;
using SCHOOL_MANAGEMENT_API1.DTOS.Department;
using SCHOOL_MANAGEMENT_API1.Mapping.ClassRoomMapping;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly Context c;
        public ClassRoomsController(Context c)
        {
            this.c = c;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ClassRoomProfile());
            }).CreateMapper();
        }

        [HttpGet]
<<<<<<< HEAD
        public ActionResult<List<ClassRoom>> GetClassRooms()
        {
            var t = c.classRooms.ToList();
            var tt = mapper.Map<List<GetClassRooms>>(t);
=======
        public ActionResult<List<ClassRoom>> GetClassRoooms()
        {
            var t = c.classRooms.ToList();
            var tt = mapper.Map<List<GetCalssRoooms>>(t);
>>>>>>> 2cc9e5f736dec4ba8beec69e6337d6fe8dc7c472
            return Ok(tt);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var t = c.classRooms.FirstOrDefault(s => s.Id == id);
            if (t == null)
            {
                return NotFound();
            }

            var h = mapper.Map<GetClassRoomsById>(t);
            return Ok(h);
        }


        [HttpPost]
<<<<<<< HEAD
        public IActionResult CreateClassRoom(CreateClassRoom y)
=======
        public IActionResult CreaeClassroom(CreateClassRoom y)
>>>>>>> 2cc9e5f736dec4ba8beec69e6337d6fe8dc7c472
        {


            var e = mapper.Map<ClassRoom>(y);
            c.classRooms.Add(e);
            c.SaveChanges();
            return Created("", e);

        }


        [HttpPut("{id}")]
<<<<<<< HEAD
        public IActionResult UpdateClasssRoom(int id, UpdateClassRooom dto)
=======
        public IActionResult UpdateClassRoom(int id, UpdateClassRooom dto)
>>>>>>> 2cc9e5f736dec4ba8beec69e6337d6fe8dc7c472
        {
            var ff = c.classRooms.Find(id);
            if (ff == null) return NotFound();
            mapper.Map(dto, ff);
            c.SaveChanges();
            return Ok(ff);
        }


        [HttpPatch("{id}")]
<<<<<<< HEAD
        public IActionResult PatchClassRoom(int id, PatchClasssRoom dto)
=======
        public IActionResult PatchClassRoom(int id, PatchClassRoom dto)
>>>>>>> 2cc9e5f736dec4ba8beec69e6337d6fe8dc7c472
        {
            var tt = c.classRooms.Find(id);
            if (tt == null) return NotFound();

            if (!string.IsNullOrEmpty(dto.Name))
                tt.Name = dto.Name;

            c.SaveChanges();
            return Ok(tt);
        }


        [HttpDelete("{id}")]
<<<<<<< HEAD
        public IActionResult Deleteclassroom(int id)
=======
        public IActionResult DeleteClassRoom(int id)
>>>>>>> 2cc9e5f736dec4ba8beec69e6337d6fe8dc7c472
        {
            var tt = c.classRooms.Find(id);
            if (tt == null) return NotFound(" not found ");

            c.classRooms.Remove(tt);
            c.SaveChanges();

            return NoContent();
        }
    }
}
