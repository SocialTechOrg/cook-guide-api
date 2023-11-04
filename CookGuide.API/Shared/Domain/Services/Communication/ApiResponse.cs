namespace CookGuide.API.Shared.Domain.Services.Communication;

public abstract class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Resource { get; set; }
    
    protected ApiResponse(string message, T data)
    {
        Message = message;
        Resource = data;
    }
    
    protected ApiResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }
    
    protected ApiResponse(T data)
    {
        Success = true;
        Message = string.Empty;
        Resource = data;
    }
}