using MediatR;

namespace CleanEcomm.Application.Events;

public record PaymentRequestedEvent(
    Guid OrderId,
    Guid CustomerId,
    decimal Amount
) : INotification;