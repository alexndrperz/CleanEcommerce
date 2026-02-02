using CleanEcomm.Domain.Common;
using MediatR;

namespace CleanEcomm.Application.Commands;
public record CreateOrderCommand(
    Guid CustomerId,
    decimal Amount
) : IRequest<Result<Guid>>;