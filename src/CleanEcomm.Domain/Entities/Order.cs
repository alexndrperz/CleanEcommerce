using System;
using System.Collections.Generic;
using System.Text;
using CleanEcomm.Domain.Common;
using CleanEcomm.Domain.Enums;

namespace CleanEcomm.Domain.Entities;
    public  class Order {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public decimal Amount { get; }
        public OrderStatus Status { get; private set; }

        private Order(Guid id, Guid customerId, decimal amount) {
            Id = id;
            CustomerId = customerId;
            Amount = amount;
            Status = OrderStatus.Pending;
        }

        public static Result<Order> Create(Guid customerId, decimal amount) {
            if (amount <= 0)
                return Result<Order>.Failure("Amount must be greater than zero");

            return Result<Order>.Success(
                new Order(Guid.NewGuid(), customerId, amount)
            );
        }

        public void MarkAsPaid() => Status = OrderStatus.Paid;
    }
