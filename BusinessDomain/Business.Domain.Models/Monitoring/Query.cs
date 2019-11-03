using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessDomain.Business.Domain.Models.Monitoring
{
    public class Query
    {
        public Query()
        {
            //Parameters = new List<QueryParameters>();
            StatusAlert = new StatusAlert();
            StatusAlert.OrderAlert = 10;//greyAlert
        }

        public int IdQuery { get; set; }

        public int IdQueryConnector { get; set; }

        public string Name { get; set; }
        public string SqlQuery { get; set; }

        public int GreenValue { get; set; }

        public string GreenSign { get; set; }

        public int OrangeValue { get; set; }

        public string OrangeSign { get; set; }

        public int RedValue { get; set; }

        public string RedSign { get; set; }

        public string Description
        {
            get;
            set;
        }

        public bool IsTechnical { get; set; }

        public Connector QueryConnector { get; set; }

        //public List<QueryParameters> Parameters { get; set; }
        public ResultQuery ResultQuery { get; set; }

        //public List<QueryFilter> QueryFilters { get; set; }

        //public List<ResultFilter> ResultFilters { get; set; }

        public StatusAlert StatusAlert { get; set; }

        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
    }


}
