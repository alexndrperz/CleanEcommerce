using CleanEcomm.Application.Commands;
using CleanEcomm.Application.Contracts;
using CleanEcomm.Application.Events;
using CleanEcomm.Domain.Common;
using CleanEcomm.Domain.Entities;
using CleanEcomm.Domain.Interfaces;
using MediatR;

namespace CleanEcomm.Application.CommandsHandler;
public class CreateOrderCommandHandler(
    IOrderRepository orderRepo,
    IUnitOfWork uow,
    IPublisher publisher
) : IRequestHandler<CreateOrderCommand, Result<Guid>> {
    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken ct) {
        var orderResult = Order.Create(request.CustomerId, request.Amount);

        if (!orderResult.IsSuccess)
            return Result<Guid>.Failure(orderResult.Error);

        await orderRepo.AddAsync(orderResult.Value);
        await uow.CommitAsync(ct);

        await publisher.Publish(
            new PaymentRequestedEvent(
                orderResult.Value.Id,
                request.CustomerId,
                request.Amount
            ), ct);

        return Result<Guid>.Success(orderResult.Value.Id);
    }
}