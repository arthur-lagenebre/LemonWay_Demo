using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using log4net;
using log4net.Config;
using Newtonsoft.Json;

namespace ASP.NET_WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Demo : WebService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Demo));

        [WebMethod]
        public int Fibonacci(int n)
        {
            BasicConfigurator.Configure();

            log.InfoFormat("Fibonacci : {0}", n);

            if (n < 1 || n > 100)
            {
                log.Error("Out of range");

                return -1;
            }

            int a = 0;
            int b = 1;

            for (int i = 0; i < n; i++)
            {
                int temp = a;

                a = b;
                b = temp + b;
            }

            log.InfoFormat("Result : {0}", a);

            return a;
        }

        [WebMethod]
        public string XmlToJson(string xml)
        {
            log.InfoFormat("XmlToJson : {0}", xml);

            XmlDocument doc = new XmlDocument();

            try
            {
                doc.LoadXml(xml);
            }
            catch (Exception)
            {
                log.Error("Bad Xml format");

                return "Bad Xml format";
            }

            string json = JsonConvert.SerializeXmlNode(doc);

            log.InfoFormat("Json : {0}", json);

            return json;
        }
    }
}
