namespace Helpers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public PaginationMeta? Meta { get; set; }

        public ApiResponse(bool success, string message, T? data, PaginationMeta? meta = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Meta = meta;
        }
    }
}