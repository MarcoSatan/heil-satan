using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eh_che_couch.ProjectWork.DbConnection.ObjectModel
{
    public class FilterDocument
    {
        public Dictionary<string, List<string>> States { get; set; }

        public Dictionary<string, List<string>> Languages { get; set; }
    }
}
