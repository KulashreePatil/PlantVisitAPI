using Azure;
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
        public async Task<FacilitiesModel> GetById(int? id)
        {
            var facilities = await dbContext.Set<FacilitiesModel>().FindAsync(id);
            if (facilities == null)
            {
                throw new KeyNotFoundException($"Facilities with ID {id} not found.");
            }
            return facilities;
        }
        public async Task<APIResponseModel> Update(FacilitiesModel objfac)
        { 
            APIResponseModel response = new APIResponseModel();
            try
            {
                FacilitiesModel? existingFacilities = await GetById(objfac.FacilitiesId);
                if (existingFacilities != null)
                {
                    existingFacilities.FacilitiesName = objfac.FacilitiesName;
                    response.Data = await dbContext.SaveChangesAsync();
                    response.Message = "record fetched successfully";
                    response.IsSuccess = true;

                }
            }
            catch (Exception e)
            {
                response.Data = null;
                response.Message = "Something went wrong";
                response.IsSuccess = false;

            }
            return response;
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
        
    }
}
