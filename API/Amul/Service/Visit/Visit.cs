using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using System.Linq;

namespace PlantVisit.Service.Visit
{
    public class Visit : IVisit
    {
        readonly PlantVisitDBContext dbContext;
        public int VisitId { get; private set; }
        public Visit(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }

        public async Task<List<VisitModel>> GetAll()
        {
            List<VisitModel> lstdata = new List<VisitModel>();
            using (var connection = dbContext)
            {
                lstdata = await dbContext.Visit.ToListAsync();
            }
            return lstdata;
        }
        public async Task<VisitModel> GetByID(int id)
        {
            return await dbContext.Set<VisitModel>().FindAsync(id);
        }

        public async Task<int> Add(VisitModel objvisit)
        {
            var existingVisit = new VisitModel
            {
                VisitTime  = objvisit.VisitTime,
                PlantID = objvisit.PlantID,
                Capacity = objvisit.Capacity,
            };

            dbContext.Visit.Add(existingVisit);
            await dbContext.SaveChangesAsync();
            return existingVisit.VisitID;
        }
        public async Task<bool> Update(VisitModel objvisit)
        {

            VisitModel? existingvisit = await GetByID(objvisit.VisitID);
            if (existingvisit != null)
            {
                existingvisit.PlantID = objvisit.PlantID;
                existingvisit.Capacity = objvisit.Capacity;
                existingvisit.VisitTime = objvisit.VisitTime;


                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}

