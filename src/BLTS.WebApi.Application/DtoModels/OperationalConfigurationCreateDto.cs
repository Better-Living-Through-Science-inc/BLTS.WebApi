namespace BLTS.WebApi.DtoModels
{
    public class OperationalConfigurationCreateDto
    {
        public string PropertyName { get; set; }
        public dynamic PropertyValue { get; set; }
        public bool IsUpdateDatabase { get; set; }
    }
}
