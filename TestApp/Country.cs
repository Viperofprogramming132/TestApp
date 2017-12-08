using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestApp
{
    public class Country
    {
        private List<Site> m_Sites = new List<Site>();
        private string m_CountryName;
        private byte m_CountryID;

        [XmlElement("CountryName")]
        public string CountryName { get { return m_CountryName; } set { m_CountryName = value; } }
        [XmlElement("CountryID")]
        public byte CountryID { get { return m_CountryID; } set { m_CountryID = value; } }
        public List<Site> Sites { get { return m_Sites; } set { m_Sites = value; } }


        /// <summary>
        /// Constructor for country
        /// </summary>
        public Country()
        {
            for (int i = 0; i < 50; i++)
            {
                m_Sites.Add(new Site() { ID = (byte)i, Name = i.ToString() });
            }
        }


        /// <summary>
        /// Desconstuctor destory all veriables here for garbage collection
        /// </summary>
        ~Country()
        {
            m_CountryName = null;
            m_Sites = null;
        }

        public override string ToString()
        {
            return m_CountryName;
        }
    }
}
