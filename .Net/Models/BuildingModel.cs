

namespace Models
{
    public class BuildingModel
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string BuildingNumber { get; set; }
        public int NumberOfFloors { get; set; }
        public string BuildingType { get; set; }
        public string AdditionalData { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
