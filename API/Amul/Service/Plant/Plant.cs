using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;
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

        public async Task<APIResponseModel> GetAll(string? searchTerm)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                IQueryable<PlantModel> query = dbContext.Plant;
                

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(p => p.PlantName.Contains(searchTerm));
                }

                response.Data = await query.ToListAsync();
                response.Message = "Records fetched successfully";
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


        public async Task<PlantModel> GetByID(int id)
        {
            var plant = await dbContext.Set<PlantModel>().FindAsync(id);
            if (plant == null)
            {
                throw new KeyNotFoundException($"Plant with ID {id} not found.");
            }
            return plant; 
        }


        public async Task<APIResponseModel> Add(PlantModel objplant)
        {
           APIResponseModel response = new APIResponseModel();

            try
            {
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
                response.Data = (int)objplant.PlantID;
                response.Message = "record added successfully";
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

        public async Task<APIResponseModel> Update(PlantModel objplant)
        {
            APIResponseModel response = new APIResponseModel();

            try
            {
                
                PlantModel? existingplant = await GetByID(objplant.PlantID);
                if (existingplant != null)
                {
                    existingplant.PlantName = objplant.PlantName;
                    existingplant.PlantDescription = objplant.PlantDescription;
                    existingplant.PlantLocation = objplant.PlantLocation;
                    existingplant.PlantNumber = objplant.PlantNumber;
                    existingplant.PlantEmail = objplant.PlantEmail;


                    response.Data = await dbContext.SaveChangesAsync();
                    response.Message = "record fetched successfully";
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
        public async Task<APIResponseModel> GetFacilityList()
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                var lstdata = await dbContext.PlantFacilityViewModel.FromSqlRaw(@" 
                 SELECT 
                 pl.PlantName,
                 CAST(pl.PlantDescription AS NVARCHAR(MAX)) AS PlantDescription, 
                 pl.PlantLocation,
                 pl.PlantNumber,
                 pl.PlantEmail,
                 STRING_AGG(f.FacilitiesName, ', ') AS FacilitiesNames 
                 FROM PlantList pl
                 LEFT JOIN PFMapping pf ON pl.PlantID = pf.PlantID
                 LEFT JOIN Facilities f ON pf.FacilitiesID = f.FacilitiesID
                 GROUP BY 
                 pl.PlantID, 
                 pl.PlantName, 
                 CAST(pl.PlantDescription AS NVARCHAR(MAX)), 
                 pl.PlantLocation, 
                 pl.PlantNumber, 
                 pl.PlantEmail").ToListAsync();
                
                 response.Data = lstdata;
                 response.Message = "Record fetched successfully";
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


    }
}

