using System.ComponentModel.DataAnnotations;

namespace PlantVisit.EFCoreModel
{
    public class UserDatamodel
    {
        [Key]
       public int UserID { get; set; }
       public int UserNumber { get; set; }
    }
}
