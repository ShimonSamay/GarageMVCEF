using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Garage.Models;

namespace Garage.Controllers
{
    public class CarController : ApiController
    {
        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=GarageDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
         GarageDB_Context garageDB = new GarageDB_Context(stringConnection);
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(garageDB.Cars.ToList());
            }
            catch(SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);  
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }
            

        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(garageDB.Cars.First(car => car.Id == id));
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }

        }

       
        public IHttpActionResult Post([FromBody]Car value)
        {
            try
            {
                garageDB.Cars.Add(value);
                garageDB.SaveChanges();
                return Ok(garageDB.Cars.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }

      
        public IHttpActionResult Put(int id, [FromBody] Car value)
        {
            try
            {
                Car someCar = garageDB.Cars.First(car => car.Id == id);
                someCar.Id = value.Id;
                someCar.OwnersName = value.OwnersName;
                someCar.FixedStatus = value.FixedStatus;
                someCar.CarNumber = value.CarNumber;
                garageDB.SaveChanges();
                return Ok(garageDB.Cars.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }

      
        public IHttpActionResult Delete(int id)
        {
            try
            {
                garageDB.Cars.Remove(garageDB.Cars.First(car => car.Id == id));
                garageDB.SaveChanges();
                return Ok(garageDB.Cars.ToList());
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }
    }
}
