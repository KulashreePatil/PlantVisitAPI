using System.ComponentModel.DataAnnotations;

namespace PlantVisit.EFCoreModel
{
    public class FacilitiesModel

    {
        [Key]
        public int? FacilitiesId { get; set; }

        public string? FacilitiesName { get; set; }
    }
}

