using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using static BusinessDomain.Business.Domain.Models.Monitoring.Connector;

namespace BusinessDomain.Business.Domain.Models.Monitoring
{
    public class ResultQuery
    {
        private readonly TypeConnectorQuery _typeConnector;

        public ResultQuery(TypeConnectorQuery typeConnector)
        {
            _typeConnector = typeConnector;
        }

        public DataTable ListResultatSql { get; set; }

        public int NbElement
        {
            get
            {
                switch (_typeConnector)
                {
                    case TypeConnectorQuery.sql:

                        if (ListResultatSql != null)
                        {
                            return ListResultatSql.AsEnumerable().Count();
                        }
                        break;

                }

                return 0;
            }
        }

        public string GetResultQuery()
        {
            string result = "";
            switch (_typeConnector)
            {
                case TypeConnectorQuery.sql:
 
                    return FormatDataTable();
            }
            return result;


        }

        public string FormatDataTable()
        {
            StringBuilder MyStringBuilder = new StringBuilder("<table class=\"ResultQuery\">");
            MyStringBuilder.Append("<thead><tr>");
            foreach (DataColumn column in ListResultatSql.Columns)
            {
                MyStringBuilder.Append("<th class=\"headerResultQuery\">" + column.ColumnName + " </th> ");

            }

            MyStringBuilder.Append("</tr></thead><tbody>");

            foreach (DataRow row in ListResultatSql.Rows)
            {
                MyStringBuilder.Append("<tr>");
                foreach (DataColumn column in ListResultatSql.Columns)
                {
                    MyStringBuilder.Append("<td>" + FormatValue(row[column]) + " </td> ");
                }

                MyStringBuilder.Append("</tr>");
            }
            MyStringBuilder.Append("</tbody></table>");
            return MyStringBuilder.ToString();

        }

        private string FormatValue(object value)
        {
            string valueString = value.ToString();
            double valueDouble;

            if (valueString.IndexOf(',') >= 1 && double.TryParse(valueString, out valueDouble))
            {
                return valueDouble.ToString("0.00");
            }


            return valueString;
        }
    }
}
