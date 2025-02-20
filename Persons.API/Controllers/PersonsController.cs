
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using Persons.API.Database.Entities;
using Persons.API.Dtos.Common;
using Persons.API.Dtos.Persons;
using Persons.API.Services.Interfaces;
using SQLitePCL;

namespace Persons.API.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService _personsService;
        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }
       
        [HttpPost] //Crea un usuario en la DB
        public async Task<ActionResult<ResponseDto<PersonActionResponseDto>>> Post([FromBody] PersonCreateDto dto)
        {
            var response = await _personsService.CreateAsync(dto);

                return StatusCode(response.StatusCode, new
                {
                    response.Status,
                    response.Message,
                    response.Data,
                }); 
        }

        [HttpGet]   //Pide una lista de todos los usuarios de la base de datos
        public async Task<ActionResult<ResponseDto<List<PersonDto>>>> GetList()
        {

            var response = await _personsService.GetListAsync();

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data
            });
        }

        [HttpGet("{id}")]   //Pide un usuario por Id
        public async Task<ActionResult<ResponseDto<PersonDto>>> GetOne(Guid id)
        {
            var response = await _personsService.GetOneByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")] // Modifica un usuario mediante id

        public async Task<ActionResult<ResponseDto<PersonActionResponseDto>>> Edit([FromBody] PersonEditDto dto, Guid Id)
        {
            var response = await _personsService.EditAsync(dto, Id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<PersonActionResponseDto>>> Delete(Guid id)
        {
            var response = await _personsService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
