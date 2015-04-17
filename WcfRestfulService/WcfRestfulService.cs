using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WcfRestfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WcfRestfulService : IWcfRestfulService
    {
         public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "data/{id}")]
        public Person GetData(string id)
        {
            // lookup person with the requested id 
            return new Person()
            {
                Id = Convert.ToInt32(id),
                Name = "Jesse yang"
            };
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetId/{id}")]
        public int GetId(string id)
        {
            // lookup person with the requested id 
            return int.Parse(id);
        }
    }
}
