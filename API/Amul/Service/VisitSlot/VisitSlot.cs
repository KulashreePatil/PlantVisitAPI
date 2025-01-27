using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using System.Linq;

namespace PlantVisit.Service.VisitSlot
{
    public class VisitSlot : IVisitSlot
    {
        readonly PlantVisitDBContext dbContext;
        public int VisitSlotId { get; private set; }
        public VisitSlot(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }

        public List<VisitSlotModel> GetAll()
        {
            List<VisitSlotModel> lstdata = new List<VisitSlotModel>();
            using (var connection = dbContext)
            {
                lstdata = dbContext.VisitSlot.ToList();
            }
            return lstdata;
        }
        public async Task<int> Add(VisitSlotModel objModel)
        {
            using (var connection = dbContext)
            {
                await dbContext.VisitSlot.AddAsync(objModel);
                dbContext.SaveChanges();
            }
            return objModel.PlantID;
        }
        public async Task<bool> Update(VisitSlotModel objModel)
        {
            var Visits = dbContext.VisitSlot.Find(objModel.VisitID);
            if (Visits == null)
                return false;

            await dbContext.SaveChangesAsync();
            return true;
        }

    }
}

