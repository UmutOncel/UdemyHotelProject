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

        [HttpGet("GetContactsInCategoryThank")]
        public IActionResult GetContactsInCategoryThank() 
        {
            var values = _contactService.TGetContactsInCategoryThank();
            return Ok(values);
        }

        [HttpGet("GetContactsInCategoryComplaint")]
        public IActionResult GetContactsInCategoryComplaint()
        {
            var values = _contactService.TGetContactsInCategoryComplaint();
            return Ok(values);
        }

        [HttpGet("GetContactsInCategoryDemand")]
        public IActionResult GetContactsInCategoryDemand()
        {
            var values = _contactService.TGetContactsInCategoryDemand();
            return Ok(values);
        }

        [HttpGet("GetContactsInCategoryJobApplication")]
        public IActionResult GetContactsInCategoryJobApplication()
        {
            var values = _contactService.TGetContactsInCategoryJobApplication();
            return Ok(values);
        }

        [HttpGet("GetContactsInCategoryOther")]
        public IActionResult GetContactsInCategoryOther()
        {
            var values = _contactService.TGetContactsInCategoryOther();
            return Ok(values);
        }

        [HttpGet("GetContactsInCategorySuggestion")]
        public IActionResult GetContactsInCategorySuggestion()
        {
            var values = _contactService.TGetContactsInCategorySuggestion();
            return Ok(values);
        }
    }
}
