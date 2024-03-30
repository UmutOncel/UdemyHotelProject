using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList() 
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact) 
        {
            _contactService.TInsert(contact);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id) 
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok(); 
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id) 
        {
            var value = _contactService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateContact(Contact contact) 
        {
            _contactService.TUpdate(contact);
            return Ok();
        }

        //Parametresiz 2 Get metodu var. Karışmaması için bu şekilde metot adını HttpGet yanına yazıyoruz.
        [HttpGet("GetContactCount")]        
        public IActionResult GetContactCount() 
        {
            var value = _contactService.TGetContactCount();
            return Ok(value); 
        }
    }
}
