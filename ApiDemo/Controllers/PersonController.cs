using ApiDemo.BAL;
using ApiDemo.DAL;
using ApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class PersonController : Controller
    {
        #region Get All Person
        [HttpGet]
        public IActionResult Get()
        {
            Person_BALBase Person_BALBase = new Person_BALBase();
            List<PersonModel> pm = Person_BALBase.API_Person_SelectAll();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

            if (pm.Count > 0 && pm != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", pm);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Get Person By ID
        [HttpGet("{PersonID}")]
        public IActionResult Get(int PersonID)
        {
            Person_BALBase Person_BALBase = new Person_BALBase();
            PersonModel pm = Person_BALBase.API_Person_SelectByPK(PersonID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();

            if (pm != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", pm);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        [HttpDelete("{PersonID}")]
        public IActionResult Delete(int PersonID)
        {
            Person_BALBase person_BAL = new Person_BALBase();
            var person = person_BAL.API_Person_Delete(PersonID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (person != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", person);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #region Insert
        [HttpPost]
        public IActionResult Post([FromForm] PersonModel personModel)
        {
            if (personModel == null)
            {
                return NotFound();
            }
            Person_BALBase personBALBase = new Person_BALBase();
            bool IsSuccess = personBALBase.API_Person_Insert(personModel);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Inserted");
                return NotFound(response);
            }

        }
        #endregion

        #region Update
        [HttpPut("{PersonID}")]
        public IActionResult Put(int PersonID, [FromForm] PersonModel personModel)
        {
            if (personModel == null)
            {
                return NotFound();
            }
            Person_BALBase personBALBase = new Person_BALBase();
            bool IsSuccess = personBALBase.API_Person_Update(PersonID, personModel);
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Updated");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Updated");
                return NotFound(response);
            }

        }
        #endregion
    }
}
