﻿using BookShop.Models.Entities;

namespace BookShop.Data
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
    }
}