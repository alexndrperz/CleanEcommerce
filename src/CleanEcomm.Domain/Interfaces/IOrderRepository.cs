using CleanEcomm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanEcomm.Domain.Interfaces;
public interface IOrderRepository {
    Task AddAsync(Order order);
    Task<Order?> GetByIdAsync(Guid id);
}

