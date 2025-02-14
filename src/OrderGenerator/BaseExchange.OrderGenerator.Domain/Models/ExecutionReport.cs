using BaseExchange.OrderGenerator.Domain.Enums;

namespace BaseExchange.OrderGenerator.Domain.Models
{
    public class ExecutionReport
    {
        public Guid OrderId { get; private set; }
        public string ExecType { get; private set; }
        public string ExecId { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public Symbol Symbol { get; private set; }
        public Side Side { get; private set; }
        public decimal LeavesQty { get; private set; }
        public decimal CumQty { get; private set; }
        public decimal AvgPx { get; private set; }

        private ExecutionReport(
            Guid orderId,
            string execType,
            string execId,
            OrderStatus orderStatus,
            Symbol symbol,
            Side side,
            decimal leavesQty,
            decimal cumQty,
            decimal avgPx)
        {
            OrderId = orderId;
            ExecType = execType;
            ExecId = execId;
            OrderStatus = orderStatus;
            Symbol = symbol;
            Side = side;
            LeavesQty = leavesQty;
            CumQty = cumQty;
            AvgPx = avgPx;
        }

        public static ExecutionReport Create(
            Guid orderId,
            string execType,
            string execId,
            OrderStatus orderStatus,
            Symbol symbol,
            Side side,
            decimal leavesQty,
            decimal cumQty,
            decimal avgPx)
        {
            return new ExecutionReport(
                orderId,
                execType,
                execId,
                orderStatus,
                symbol,
                side,
                leavesQty,
                cumQty,
                avgPx);
        }
    }
}