using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eh_che_couch.ProjectWork.Web.Controllers
{
    public class ControlPanelAPIController : ApiController
    {
        // GET: api/ControlPanelAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ControlPanelAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ControlPanelAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ControlPanelAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ControlPanelAPI/5
        public void Delete(int id)
        {
        }
    }
}
