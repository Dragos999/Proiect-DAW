﻿using pro.Models;


namespace pro.Repositories.OrderRepo
{
    public interface IOrderRepo
    {
        //Get
        Task<List<Order>> Get();
        //Create
        string Add(Guid userId,Guid itemId,string adress="");

        //Find

        Task<Order> FindById(Guid id);

        //Delete
        string DeleteById(Guid userId,Guid itemID);

        //Save
        string Save();
    }
}