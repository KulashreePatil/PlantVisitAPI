using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;


namespace PlantVisit.Service.Facilities
{
    public class Facilities: IFacilities
    {
        readonly PlantVisitDBContext dbContext;

        public int FacilitiesId { get; private set; }

        public Facilities(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }
        public async Task<int> Add(FacilitiesModel objFac)
        {
            using (var connection = dbContext)
            {
                await dbContext.Facilities.AddAsync(objFac);
                dbContext.SaveChanges();
            }
            return objFac.FacilitiesId;
        }
        public async Task<bool> Update(FacilitiesModel objFac)
        {
            var facility = dbContext.Facilities.Find(objFac.FacilitiesId);
            if (facility == null)
                return false;

            await dbContext.SaveChangesAsync();
            return true;
        }

        

        public List<FacilitiesModel> GetAll()
        {
            List<FacilitiesModel> lstdata = new List<FacilitiesModel>();
            using (var connection = dbContext)
            {
                lstdata = dbContext.Facilities.ToList();
            }
            return lstdata;
        }

       
    }
    }

