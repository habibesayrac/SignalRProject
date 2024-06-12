using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                Mail = createMessageDto.Mail,
                Phone = createMessageDto.Phone,
                NameSurname=createMessageDto.NameSurname,
                Subject = createMessageDto.Subject,
                MessageContent= createMessageDto.MessageContent,
                MessageSendDate = createMessageDto.MessageSendDate,
                Status=false

            };
            _messageService.TAdd(message);
            return Ok("Mesaj kısmı başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            _messageService.TDelete(value);
            return Ok("Mesaj Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {

                Mail = updateMessageDto.Mail,
                Phone = updateMessageDto.Phone,
                NameSurname = updateMessageDto.NameSurname,
                Subject = updateMessageDto.Subject,
                MessageContent = updateMessageDto.MessageContent,
                MessageSendDate = updateMessageDto.MessageSendDate,
                Status = false,
                MessageID=updateMessageDto.MessageID
            };
            _messageService.TUpdate(message);
            return Ok("Mesaj başarılı bir şekilde güncellendi");
        }
    }
}