using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.Facilities
{
    public class Facility : IFacilities
    {
        readonly PlantVisitDBContext dbContext;
        public Facility(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }
        public async Task<APIResponseModel> Add(FacilitiesModel objfac)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                var existingFacilities = new FacilitiesModel
                {
                    FacilitiesName = objfac.FacilitiesName,
                };

                dbContext.Facilities.Add(existingFacilities);
                await dbContext.SaveChangesAsync();
                response.Data= (int)objfac.FacilitiesId;
                response.Message = "record added successfully";
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong";
                response.Data = 0;
            }
            return response;
        }
        public async Task<FacilitiesModel> GetById(int id)
        {
            var facilities = await dbContext.Set<FacilitiesModel>().FindAsync(id);
            if (facilities == null)
            {
                throw new KeyNotFoundException($"Facilities with ID {id} not found.");
            }
            return facilities;
        }
        public async Task<bool> Update(FacilitiesModel objfac)
        {
            FacilitiesModel? existingfacility = await GetById((int)objfac.FacilitiesId);
            if (existingfacility != null)
            {
                existingfacility.FacilitiesName = objfac.FacilitiesName;


                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<APIResponseModel> GetAll()
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                response.Data= await dbContext.Facilities.ToListAsync();
                response.Message = "record fetched successfully";
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Message = "Something went wrong";
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<FacilitiesModel?> GetByIdAsync(int id)
        {
            return await dbContext.Facilities.FindAsync(id);
        }
        public async Task<List<PlantFacilityViewModel>> GetDetails()
        {
            return await dbContext.PlantFacilityViewModel.FromSqlRaw(@"SELECT p.PlantID, p.PlantName, f.FacilitiesId AS FacilityID, f.FacilitiesName 
                              FROM Plants p
                              INNER JOIN Mapping m ON p.PlantID = m.PlantID
                              INNER JOIN Facilities f ON m.FacilitiesID = f.FacilitiesId")
                .ToListAsync();
        }
    }
}
