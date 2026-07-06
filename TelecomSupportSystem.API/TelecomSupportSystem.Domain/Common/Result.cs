namespace TelecomSupportSystem.Domain.Common
{
    using System.Diagnostics.CodeAnalysis;

    public class Result
    {
        [MemberNotNullWhen(false, nameof(Error))]
        public bool IsSuccess { get; }
        public string? Error { get; }
        public ErrorType ErrorType { get; }

        protected Result(bool isSuccess, ErrorType errorType, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
            ErrorType = errorType;
        }

        public static Result Success() => new(true, ErrorType.None, null);
        public static Result Failure(string error) => new(false, ErrorType.Failure, error);
        public static Result NotFound(string error) => new(false, ErrorType.NotFound, error);
        public static Result Forbidden(string error) => new(false, ErrorType.Forbidden, error);
        public static Result Validation(string error) => new(false, ErrorType.Validation, error);

    }

    public class Result<T> : Result
    {
        public T? Value { get; }
        public new string? Error => base.Error;

        [MemberNotNullWhen(true, nameof(Value))]
        [MemberNotNullWhen(false, nameof(Error))]
        public new bool IsSuccess => base.IsSuccess;

        protected Result(bool isSuccess, T? value, ErrorType errorType, string? error)
            : base(isSuccess, errorType, error)
        {
            Value = value;
        }

        public static Result<T> Success(T value) => new(true, value, ErrorType.None, null);
        public static new Result<T> Failure(string error) => new(false, default, ErrorType.Failure, error);
        public static new Result<T> NotFound(string error) => new(false, default, ErrorType.NotFound, error);
        public static new Result<T> Forbidden(string error) => new(false, default, ErrorType.Forbidden, error);
        public static new Result<T> Validation(string error) => new(false, default, ErrorType.Validation, error);

    }

    public static class StringCollectionExtensions
    {
        public static string ConcatErrors(this IEnumerable<string> errors, string separator = ", ")
            => string.Join(separator, errors);
    }

    public enum ErrorType
    {
        None,
        Failure,
        NotFound,
        Forbidden,
        Validation
    }
}
