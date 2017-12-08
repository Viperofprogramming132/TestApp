﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestApp
{
    public class Cabinet
    {
        private int m_ID;
        private string m_Name;
        List<Component> m_Components = new List<Component>();

        [XmlElement("CabinetID")]
        public int ID { get { return m_ID; } set { m_ID = value; } }
        [XmlElement("CabinetName")]
        public string Name { get { return m_Name; } set { m_Name = value; } }
        public List<Component> Components { get { return m_Components; } set { m_Components = value; } }

        public override string ToString()
        {
            return m_Name;
        }
    }
}
