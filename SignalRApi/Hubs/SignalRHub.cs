﻿using Microsoft.AspNetCore.SignalR;
using SignalR.DatatAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub:Hub
    {
       SignalRContext context = new SignalRContext();
        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }

    }
}