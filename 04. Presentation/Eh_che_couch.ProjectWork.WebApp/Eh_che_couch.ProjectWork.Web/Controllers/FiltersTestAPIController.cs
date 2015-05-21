using Eh_che_couch.ProjectWork.DbConnection;
using Eh_che_couch.ProjectWork.DbConnection.ObjectModel;
using Eh_che_couch.ProjectWork.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eh_che_couch.ProjectWork.Web.Controllers
{
    public class FiltersTestAPIController : ApiController
    {
        // GET: api/FiltersTestAPI
        public FilterDocumentViewModels Get()
        {
            DataAccess da = new DataAccess();
            FilterDocument dataAccessResult = da.GetCompleteFilterDocument();
            FilterDocumentViewModels resultAPI = new FilterDocumentViewModels();
            resultAPI.States = new Dictionary<string, List<string>>();
            resultAPI.Languages = new Dictionary<string, List<string>>();
            foreach (string key in dataAccessResult.States.Keys)
            {
                resultAPI.States.Add(key, new List<string>());
                foreach (string value in dataAccessResult.States[key])
                {
                    resultAPI.States[key].Add(value);
                }
            }
            foreach (string key in dataAccessResult.Languages.Keys)
            {
                resultAPI.Languages.Add(key, new List<string>());
                foreach (string value in dataAccessResult.Languages[key])
                {
                    resultAPI.Languages[key].Add(value);
                }
            }
            return resultAPI;
        }

        // GET: api/FiltersTestAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FiltersTestAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FiltersTestAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FiltersTestAPI/5
        public void Delete(int id)
        {
        }
    }
}
