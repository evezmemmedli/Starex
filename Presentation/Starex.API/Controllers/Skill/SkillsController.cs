﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Starex.API.Controllers.Skill
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _service;

        public SkillsController(ISkillService service)
        {
            _service = service;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] SkillPostDto request)
        {
            await _service.AddAsync(request);
            return Created(string.Empty, string.Empty);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(false, id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromForm] SkillPostDto dto, int id)
        {
            _service.Update(dto, id);
            return NoContent();
        }
    }
}
