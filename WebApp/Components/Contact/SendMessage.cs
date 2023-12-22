using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Contact
{
    public class SendMessage : ViewComponent
    {
        IMessageService _messageService;

        public SendMessage(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
