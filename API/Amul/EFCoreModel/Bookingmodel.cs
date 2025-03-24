using System.ComponentModel.DataAnnotations;

namespace PlantVisit.EFCoreModel
{
    public class Bookingmodel
    {
        [Key]
       public int BookingID { get; set; }
       public int UserID { get; set; }
       public int PlantID { get; set; }
       public int VisitID { get; set; }
       public DateTime BookingDate { get; set; }
       public int Capacity { get; set; }
    }
}
