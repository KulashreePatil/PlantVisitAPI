using System.ComponentModel.DataAnnotations;

namespace PlantVisit.EFCoreModel
{
    public class BookingTable
    {
        [Key]
       public int BookingID { get; set; }
       public int UserID { get; set; }
       public int PlantID { get; set; }
       public int VisitID { get; set; }
       public DateOnly BookingDate { get; set; }
       public int Capacity { get; set; }
    }
}
