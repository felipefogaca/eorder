namespace eOrder.Api.ApiModels
{
    public class ApiResponse<TResponse> 
    {
        public ApiResponse(TResponse data)
        {
            Data = data;
        }

        public TResponse Data { get; private set; }
    }
}
