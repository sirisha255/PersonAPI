using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private List<Person> persons = new List<Person>()
        {
            new Person()
            {
                Id =1,
                Name ="Siri",
                Email = "siri@gmail.com"

            },
            new Person()
            {
                Id =2,
                Name ="mani",
                Email = "man@gmail.com"

            }
            };

        [HttpGet]
        [Route("getPersons")]
        public async Task<ActionResult<Person>> GetPersons()
        {
            
            return Ok(persons);
        
        
        }
        [HttpGet]
        [Route("getPerson")]

        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = persons.Find(x =>x.Id == id);
            if (person == null)


                return BadRequest("not found");
            return Ok(person);

        }
        [HttpPost]
        [Route("addPerson")]

        public async Task<ActionResult<Person>> AddPerson(Person request)
        {
            persons.Add(request);

            return Ok(persons);

        }
        [HttpPut]
        [Route("updatePerson")]

        public async Task<ActionResult<Person>> UpdatePerson(Person request)
        {
            var person = persons.Find(x =>x.Id == request.Id);
            if (person == null)
                return BadRequest("No Person Found");
            person.Name = request.Name;
            person.Email = request.Email;
           
            return Ok(persons);

        }
        [HttpDelete]
        [Route("deletePerson")]

        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = persons.Find(x => x.Id == id);
            if (person == null)
                return BadRequest("No Person Found");
            
            persons.Remove(person);
            return Ok(persons);

        }
    }
}
