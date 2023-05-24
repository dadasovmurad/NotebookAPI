using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService service)
        {
            _noteService = service;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_noteService.GetAll());
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(long id)
        {
            return Ok(_noteService.GetById(id));
        }
    }
}
