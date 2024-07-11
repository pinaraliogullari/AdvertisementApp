namespace AdvertisementApp.Shared
{
    public interface IResponse<T>:IResponse
    {
         T Data { get; set; }
         List<CustomValidationError> ValidationErrors { get; set; }
    }
}
