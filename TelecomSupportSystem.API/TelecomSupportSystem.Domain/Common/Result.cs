using System.Diagnostics.CodeAnalysis;

namespace TelecomSupportSystem.Domain.Common
{
    public class Result
    {
        [MemberNotNullWhen(false, nameof(Error))]
        public bool IsSuccess { get; }
        public string? Error { get; }

        protected Result(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        protected Result(bool isSuccess, IEnumerable<string> errors)
        {
            IsSuccess = isSuccess;
            Error = string.Join(",", errors);
        }

        public static Result Success() => new(true, error: null);
        public static Result Failure(string error) => new(false, error);

        public static Result Failure(IEnumerable<string> errors) => new(false, errors);
    }

    public class Result<T> : Result
    {
        public T? Value { get; }
        public new string? Error => base.Error;

        [MemberNotNullWhen(true, nameof(Value))]
        [MemberNotNullWhen(false, nameof(Error))]
        public new bool IsSuccess => base.IsSuccess;

        private Result(T value) : base(true, error: null) => Value = value;
        private Result(string error) : base(false, error) => Value = default;
        private Result(IEnumerable<string> errors) : base(false, errors) => Value = default;
        public static Result<T> Success(T value) => new(value);
        public static new Result<T> Failure(string error) => new(error);

        public static new Result<T> Failure(IEnumerable<string> errors) => new(errors);
    }
}
