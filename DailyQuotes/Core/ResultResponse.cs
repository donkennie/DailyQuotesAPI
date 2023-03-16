namespace DailyQuotes.Core
{
    public class ResultResponse<T>
    {
        public bool IsSuccess { get; set; }

        public T Value { get; set; }

        public string Error { get; set; }

        public static ResultResponse<T> Success(T value) => new ResultResponse<T> { IsSuccess = true, Value = value };

        public static ResultResponse<T> Failure(string error) => new ResultResponse<T> { IsSuccess = false, Error = error };
    }
}
