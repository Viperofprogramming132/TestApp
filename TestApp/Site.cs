using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestApp
{
    public class Site
    {
        private int m_ID;
        private string m_Name;
        private List<Cabinet> m_Cabinets = new List<Cabinet>();

        [XmlElement("SiteID")]
        public int ID { get { return m_ID; } set { m_ID = value; } }
        [XmlElement("SiteName")]
        public string Name { get { return m_Name; } set { m_Name = value; } }
        public List<Cabinet> Cabinets { get { return m_Cabinets; } set { m_Cabinets = value; } }

        public Site()
        {
            for (int i = 0; i < 10; i++)
            {
                m_Cabinets.Add(new Cabinet() { ID = (byte)i, Name = i.ToString() });
            }
        }
        public override string ToString()
        {
            return m_Name;
        }
    }
}
