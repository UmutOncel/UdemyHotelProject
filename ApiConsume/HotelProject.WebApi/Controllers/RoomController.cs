using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.DTOs.RoomDTOs;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RoomList() 
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddRoom(AddRoomDTO addRoomDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var value = _mapper.Map<Room>(addRoomDTO);      //addRoomDTO -> Room
            _roomService.TInsert(value);
            return Ok("Başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id) 
        {
            var value = _roomService.TGetByID(id);
            _roomService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDTO updateRoomDTO) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var value = _mapper.Map<Room>(updateRoomDTO);
            _roomService.TUpdate(value);
            return Ok("Başarıyla güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetRoom(int id) 
        {
            var value = _roomService.TGetByID(id);
            return Ok(value);
        }
    }
}
