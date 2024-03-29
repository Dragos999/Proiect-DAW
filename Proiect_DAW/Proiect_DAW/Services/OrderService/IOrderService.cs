﻿using Proiect_DAW.Models;

namespace Proiect_DAW.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();

        string AddOrder(Guid userId, Guid itemID, string adress = "");
        Task<string> RemoveOrder(Guid userId, Guid itemId);
    }
}
