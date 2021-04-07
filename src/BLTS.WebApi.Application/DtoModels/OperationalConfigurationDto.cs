namespace BLTS.WebApi.DtoModels
{
    public class OperationalConfigurationDto : DtoEntity<long>
    {
        public long ApplicationId { get; set; }
        public string PropertyName { get; set; }
    }
}
