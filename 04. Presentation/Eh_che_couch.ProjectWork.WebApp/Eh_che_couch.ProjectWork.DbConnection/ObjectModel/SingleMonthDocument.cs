using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eh_che_couch.ProjectWork.DbConnection.ObjectModel
{
    public class SingleMonthDocument
    {
        public Dictionary<string, Dictionary<string, decimal>> Analysis { get; set; }
    }
}
