using BaseExchange.OrderGenerator.Domain.Common;

namespace BaseExchange.OrderGenerator.Domain.ValueObjects
{
    public class Quantity : ValueObject
    {
        public int Value { get; private set; }

        private Quantity(int value)
        {
            Value = value;
        }

        public static Result<Quantity> Create(int value)
        {
            if (value <= 0)
                return Result.Failure<Quantity>("Quantity must be greater than zero");

            if (value >= 100000)
                return Result.Failure<Quantity>("Quantity must be less than 100,000");

            return Result.Success(new Quantity(value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}