using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eh_che_couch.ProjectWork.Web.Models
{
    public class FilterDocumentViewModels
    {
        public Dictionary<string, List<string>> States { get; set; }

        public Dictionary<string, List<string>> Languages { get; set; }
    }
}