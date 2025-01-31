namespace PlantVisit.EFCoreModel.Common
{
    public class APIResponseModel
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
