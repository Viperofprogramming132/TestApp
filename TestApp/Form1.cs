using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TestApp
{
    public partial class Form1 : Form
    {
        List<Country> countries = new List<Country>();
        public Form1()
        {
            InitializeComponent();

            Country country = new Country();

            country.CountryID = 1;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string countryName = countryTextBox.Text;
            countries.Add(new Country());
            countries[countries.Count - 1].CountryName = countryName;


        }

      
    }
}
