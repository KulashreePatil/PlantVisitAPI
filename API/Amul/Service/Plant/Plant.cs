using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using System.Linq;


namespace PlantVisit.Service.Plant
{
    public class Plant : IPlant
    {
        readonly PlantVisitDBContext dbContext;
        public int PlantId { get; private set; }
        public Plant(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }

        public PlantVisitDBContext GetDbContext()
        {
            return dbContext;
        }

        public async Task<List<PlantModel>> GetAll()
        {
            List<PlantModel> lstdata = new List<PlantModel>();
            using (var connection = dbContext)
            {
                lstdata = await dbContext.Plant.ToListAsync();
            }
            return lstdata;
        }
        public async Task<PlantModel> GetByID(int id)
        {
            var plant = await dbContext.Set<PlantModel>().FindAsync(id);
            if (plant == null)
            {
                throw new KeyNotFoundException($"Plant with ID {id} not found.");
            }
            return plant; 
        }


        public async Task<int> Add(PlantModel objplant)
        {
            objplant.PlantID = dbContext.Plant.Max(p => (int?)p.PlantID).GetValueOrDefault() + 1;
            var existingPlant = new PlantModel
            {
                PlantName = objplant.PlantName,
                PlantDescription = objplant.PlantDescription,
                PlantLocation = objplant.PlantLocation,
                PlantNumber = objplant.PlantNumber,
                PlantEmail = objplant.PlantEmail
            };

            dbContext.Plant.Add(existingPlant);
            await dbContext.SaveChangesAsync();
            return objplant.PlantID;
        }

        public async Task<bool> Update(PlantModel objplant)
        {

            if (objplant.PlantID <= 0)
            {
                return false;
            }
                PlantModel? existingplant = await GetByID(objplant.PlantID);
            if (existingplant != null)
            {
                existingplant.PlantName = objplant.PlantName;
                existingplant.PlantDescription = objplant.PlantDescription;
                existingplant.PlantLocation = objplant.PlantLocation;
                existingplant.PlantNumber = objplant.PlantNumber;
                existingplant.PlantEmail = objplant.PlantEmail;


                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}

