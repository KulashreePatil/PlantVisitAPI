using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using System.Linq;


namespace PlantVisit.Service.Plant
{
    public class PlantList : IPlantList
    {
        readonly PlantVisitDBContext dbContext;
        public int PlantListId { get; private set; }
        public PlantList(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }

        public List<PlantListModel> GetAll()
        {
            List<PlantListModel> lstdata = new List<PlantListModel>();
            using (var connection = dbContext)
            {
                lstdata = dbContext.Plant.ToList();
            }
            return lstdata;
        }
        public async Task<int> Add(PlantListModel objModel)
        {
            using (var connection = dbContext)
            {
                await dbContext.Plant.AddAsync(objModel);
                dbContext.SaveChanges();
            }
            return objModel.PlantID;
        }
        public async Task<bool> Update(PlantListModel objModel)
        {
            var Plantl = dbContext.Plant.Find(objModel.PlantID);
            if (Plantl == null)
                return false;

            await dbContext.SaveChangesAsync();
            return true;
        }

    }
}

