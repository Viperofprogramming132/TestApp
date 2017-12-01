using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Country
    {
        private List<Site> m_Sites = new List<Site>();
        private string m_CountryName;
        private byte m_CountryID;

        public List<Site> Sites { get { return m_Sites; } set { m_Sites = value; } }
        public string CountryName { get { return m_CountryName; } set { m_CountryName = value; } }
        public byte CountryID { get { return m_CountryID; } set { m_CountryID = value; } }

        /// <summary>
        /// Constructor for country
        /// </summary>
        public Country()
        {

        }


        /// <summary>
        /// Desconstuctor destory all veriables here for garbage collection
        /// </summary>
        ~Country()
        {
            m_CountryName = null;
            m_Sites = null;
        }
    }
}
