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
    public class OverviewAPIController : ApiController
    {
        // GET: api/OverviewAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OverviewAPI/2015-01
        public IEnumerable<MonthlyBestLanguageViewModels> GetBestLanguageForMonth(string id)
        {
            DataAccess da = new DataAccess();
            SingleMonthDocument dataAccessResult = da.GetCompleteMonthDocument(id);
            List<MonthlyBestLanguageViewModels> resultAPI = new List<MonthlyBestLanguageViewModels>();
            foreach(string key in dataAccessResult.Analysis.Keys)
            {
                MonthlyBestLanguageViewModels bestLanguageForCountry = new MonthlyBestLanguageViewModels();
                bestLanguageForCountry.CountryCode = key.ToLower();
                decimal max = 0m;
                foreach (KeyValuePair<string, decimal> dicLanguage in dataAccessResult.Analysis[key])
                    if (dicLanguage.Value > max)
                    {
                        max = dicLanguage.Value;
                        bestLanguageForCountry.Language = dicLanguage.Key;
                    }
                bestLanguageForCountry.Ranking = max;
                resultAPI.Add(bestLanguageForCountry);
            }
            return resultAPI;
        }

        /*
        // POST: api/OverviewAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OverviewAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OverviewAPI/5
        public void Delete(int id)
        {
        }
         */
    }
}