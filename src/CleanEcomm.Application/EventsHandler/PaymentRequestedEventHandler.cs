using CleanEcomm.Application.Events;
using MediatR;

public class PaymentRequestedHandler(
    IStripePaymentService stripe,
    IKafkaProducer kafka
) : INotificationHandler<PaymentRequestedEvent> {
    public async Task Handle(PaymentRequestedEvent notification, CancellationToken ct) {
        var paymentIntentId = await stripe.CreatePaymentIntent(
            notification.OrderId,
            notification.Amount
        );

        await kafka.PublishAsync("payments.requested", new
        {
            notification.OrderId,
            notification.CustomerId,
            notification.Amount,
            paymentIntentId
        });
    }
}