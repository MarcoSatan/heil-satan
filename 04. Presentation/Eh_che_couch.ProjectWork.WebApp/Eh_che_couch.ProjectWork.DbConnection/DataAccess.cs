using MyCouch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Eh_che_couch.ProjectWork.DbConnection.ObjectModel;

namespace Eh_che_couch.ProjectWork.DbConnection
{
    public class DataAccess
    {
        /// <summary>
        /// Establishes connection to a Couch database via MyCouchUriBuilder.
        /// </summary>
        /// <returns>Instance of MyCouchClient class</returns>
        public MyCouchClient EstablishConnection()
        {
            var uriBuilder = new MyCouchUriBuilder("http://localhost:5984/")
                .SetDbName("twitter_analyzed_data")
                .SetBasicCredentials("Nicola", "couch");
            return new MyCouchClient(uriBuilder.Build());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearMonth">
        /// A string that has to match a document ID in CouchDB.
        /// In this case it has to be formatted "yyyy-m" (e.g. "2015-5")
        /// </param>
        /// <returns>
        /// Instance of SingleMonthDocument class, containing the statistical rankings for all specified
        /// languages in all specified countries.
        /// </returns>
        public SingleMonthDocument GetCompleteMonthDocument(string yearMonth)
        {
            using (MyCouchClient c = EstablishConnection())
            {
                var getDocumentResponse = c.Documents.GetAsync(yearMonth);
                try
                {
                    SingleMonthDocument test =
                        JsonConvert.DeserializeObject<SingleMonthDocument>
                        (getDocumentResponse.Result.Content);
                    return test;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Instance of FilterDocument class, containing all filters applied to the scripts doing gathering,
        /// cleaning and analyzing
        /// </returns>
        public FilterDocument GetCompleteFilterDocument()
        {
            using (MyCouchClient c = EstablishConnection())
            {
                var getDocumentResponse = c.Documents.GetAsync("filterDoc");
                try
                {
                    FilterDocument test =
                        JsonConvert.DeserializeObject<FilterDocument>
                        (getDocumentResponse.Result.Content);
                    return test;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
        }
    }
}
