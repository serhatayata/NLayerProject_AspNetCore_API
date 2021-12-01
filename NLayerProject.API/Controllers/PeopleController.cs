using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWork;
using NLayerProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IService<Person> _personService;
        public PeopleController(IService<Person> personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var people = await _personService.GetAllAsync();
            return Ok(people);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(person);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var addedPerson = await _personService.AddASync(person);
            return Ok(addedPerson);
        }
        [HttpPut]
        public IActionResult Update(Person person)
        {
            var updatedPerson = _personService.Update(person);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var deletedPerson = _personService.GetByIdAsync(id).Result;
            _personService.Remove(deletedPerson);
            return NoContent();
        }
    }
}
