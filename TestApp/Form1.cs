using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Xml;

namespace TestApp
{
    public partial class Form1 : Form
    {
        private Controller control;
        public Form1()
        {

            InitializeComponent();
            if (File.Exists("Save.xml"))
            {
                CspParameters cspParams = new CspParameters();
                RSA rsaKey;
                cspParams.KeyContainerName = "0dR5VltLMliIW5OUkv24G+FnCtXidOwiRKK45DWFghJ+tndjmb9NbgS5petyZmGbfuHO5yNKMixyV1nh4F+cjpPqMfxp72yhdTvyr4QucNIQRCa12kBo7tLPmrkexW8LweLL3eeGdCfUKchDKbhr0JPu+q54sJ2rJSMqEc=";
                rsaKey = new RSACryptoServiceProvider(cspParams);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load("Save.xml");
                control = Decrypt(xmlDoc, rsaKey, "rsaKey");
            }
            else
            {
                control = Controller.Instance();
            }
            cmbCabinet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSite.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbCountry.Items.AddRange(control.Countries.ToArray());
        }



        private void cmbSite_MouseClick(object sender, MouseEventArgs e)
        {
            if(cmbCountry.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Country first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCabinet_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmbSite.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Site first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Controller Decrypt(XmlDocument Doc, RSA rsaKey, string KeyName)
        {
            // Check the arguments.  
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (KeyName == null)
                throw new ArgumentNullException("KeyName");

            // Create a new EncryptedXml object.
            EncryptedXml exml = new EncryptedXml(Doc);

            // Add a key-name mapping.
            // This method can only decrypt documents
            // that present the specified key name.
            exml.AddKeyNameMapping(KeyName, rsaKey);

            // Decrypt the element.
            exml.DecryptDocument();

            Doc.Save("Save.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(Controller));

            // Declare an object variable of the type to be deserialized.

            Stream reader = new FileStream("Save.xml", FileMode.Open);
            
            // Call the Deserialize method to restore the object's state.
            Controller c = (Controller) (serializer.Deserialize(reader));
            reader.Close();

            File.Delete("Save.xml");

            return c;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            control.Serialize();
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSite.Items.Clear();
            cmbSite.Items.AddRange(control.Countries[cmbCountry.SelectedIndex].Sites.ToArray());
        }

        private void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCabinet.Items.Clear();
            cmbCabinet.Items.AddRange(control.Countries[cmbCountry.SelectedIndex].Sites[cmbSite.SelectedIndex].Cabinets.ToArray());
        }
    }
}
