using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestApp
{
    public class Component
    {
        private int m_ID;
        private string m_Name;
        private int m_Position;

        public int ID { get { return m_ID; } set { m_ID = value; } }
        public string Name { get { return m_Name; } set { m_Name = value; } }
        public int Position { get { return m_Position; } set { m_Position = value; } }
    }

    public class Router : Component
    {

    }

    public class Switch : Component
    {

    }

    public class UPS : Component
    {

    }
}
