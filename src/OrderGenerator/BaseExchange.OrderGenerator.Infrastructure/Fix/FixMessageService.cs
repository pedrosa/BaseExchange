using BaseExchange.OrderGenerator.Application.Interfaces;
using BaseExchange.OrderGenerator.Domain.Entities;
using BaseExchange.OrderGenerator.Domain.Enums;
using Microsoft.Extensions.Logging;
using BaseExchange.OrderGenerator.Domain.Models;

namespace BaseExchange.OrderGenerator.Infrastructure.Fix
{
    public class FixMessageService : IFixMessageService
    {
        private readonly FixApplication _fixApplication;
        private readonly ILogger<FixMessageService> _logger;

        public FixMessageService(FixApplication fixApplication, ILogger<FixMessageService> logger)
        {
            _fixApplication = fixApplication;
            _logger = logger;
        }

        public async Task SendNewOrderSingle(Order order)
        {
            try
            {
                var message = new QuickFix.FIX44.NewOrderSingle(
                    new QuickFix.Fields.ClOrdID(order.Id.ToString()),
                    new QuickFix.Fields.Side(order.Side == Side.Buy ? '1' : '2'),
                    new QuickFix.Fields.TransactTime(DateTime.UtcNow),
                    new QuickFix.Fields.OrdType('1')
                );

                message.Set(new QuickFix.Fields.Symbol(order.Symbol.ToString()));
                message.Set(new QuickFix.Fields.OrderQty(order.Quantity.Value));
                message.Set(new QuickFix.Fields.Price(order.Price.Value));

                await Task.Run(() => QuickFix.Session.SendToTarget(message));
                _logger.LogInformation($"New order single sent: {order.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending new order single");
                throw;
            }
        }

        public Task ProcessExecutionReport(ExecutionReport report)
        {
            _logger.LogInformation($"Processing execution report: {report}");
            return Task.CompletedTask;
        }
    }
}