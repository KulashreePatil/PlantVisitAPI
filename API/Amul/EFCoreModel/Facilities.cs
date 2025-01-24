using System.ComponentModel.DataAnnotations;

namespace PlantVisit.EFCoreModel
{
    public class Facilities

    {
        [Key]
        public int FacilitiesId { get; set; }

        public string FaciltiesName { get; set; }
    }
}

