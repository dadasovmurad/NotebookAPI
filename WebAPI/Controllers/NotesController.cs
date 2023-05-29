using Business.Abstract;
using Entities.Concrete;
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
            var result = _noteService.GetAll();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(long id)
        {
            var result = _noteService.GetById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Note note)
        {
            var result = _noteService.Add(note);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}