using BaseExchange.OrderGenerator.Domain.Common;

namespace BaseExchange.OrderGenerator.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }

        private Money(decimal value)
        {
            Value = value;
        }

        public static Result<Money> Create(decimal value)
        {
            if (value <= 0)
                return Result.Failure<Money>("Price must be greater than zero");

            if (value >= 1000)
                return Result.Failure<Money>("Price must be less than 1000");

            if (value % 0.01m != 0)
                return Result.Failure<Money>("Price must be a multiple of 0.01");

            return Result.Success(new Money(value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}