using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;
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

        public async Task<APIResponseModel> GetAll()
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                response.Data = await dbContext.Visit.ToListAsync();
                response.Message = "record fetched successfully";
                response.IsSuccess = true;
            }
            catch (Exception)
            {
                response.Data = null;
                response.Message = "Something went wrong";
                response.IsSuccess = false;
            }
            return response;
        }
            
        public async Task<VisitModel> GetByID(int id)
        {
            var visit = await dbContext.Set<VisitModel>().FindAsync(id);
            if (visit == null)
            {
                throw new KeyNotFoundException($"Visit with ID {id} not found.");
            }
            return visit;
        }

        public async Task<APIResponseModel> Add(VisitModel objvisit)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                var existingVisit = new VisitModel
                {
                    VisitTime = objvisit.VisitTime,
                    PlantID = objvisit.PlantID,
                    Capacity = objvisit.Capacity,
                };

                dbContext.Visit.Add(existingVisit);
                await dbContext.SaveChangesAsync();
                response.Data = (int)objvisit.VisitID;
                response.Message = "record added successfully";
                response.IsSuccess = true;
            }

            catch (Exception)
            {
                {
                    response.Data = null;
                    response.Message = "Something went wrong";
                    response.IsSuccess = false;
                }
            }
            return response;
        }
        public async Task<APIResponseModel> Update(VisitModel objvisit)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                VisitModel? existingvisit = await GetByID(objvisit.VisitID);
                if (existingvisit != null)
                {
                    existingvisit.PlantID = objvisit.PlantID;
                    existingvisit.Capacity = objvisit.Capacity;
                    existingvisit.VisitTime = objvisit.VisitTime;


                    await dbContext.SaveChangesAsync();
                    response.Data = (int)objvisit.VisitID;
                    response.Message = "record updated successfully";
                    response.IsSuccess = true;
                }
            }
            catch (Exception)
            {

                response.Data = null;
                response.Message = "Something went wrong";
                response.IsSuccess = false;
            }
            return response;

        }
    }
}

