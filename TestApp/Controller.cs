using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TestApp
{
    public class Controller
    {
        List<Country> m_Countries = new List<Country>();

        CspParameters cspParams = new CspParameters();
        RSA rsaKey;

        [XmlElement("Country")]
        public List<Country> Countries { get { return m_Countries; } set { m_Countries = value; } }
        private static Controller instance;
        private Controller()
        {
            cspParams.KeyContainerName = "0dR5VltLMliIW5OUkv24G+FnCtXidOwiRKK45DWFghJ+tndjmb9NbgS5petyZmGbfuHO5yNKMixyV1nh4F+cjpPqMfxp72yhdTvyr4QucNIQRCa12kBo7tLPmrkexW8LweLL3eeGdCfUKchDKbhr0JPu+q54sJ2rJSMqEc=";
            rsaKey = new RSACryptoServiceProvider(cspParams);
            for (int i = 0; i < 100; i++)
            {
                m_Countries.Add(new Country { CountryID = (byte)i, CountryName = i.ToString() });
            }
        }

        public static Controller Instance()
        {
            if(instance == null)
            {
                instance = new Controller();
            }
            return instance;
        }

        public void Serialize()
        {
            /*XmlSerializer serial = new XmlSerializer(typeof(Controller));
            using (TextWriter writer = new StreamWriter("Save.xml"))
            {
                serial.Serialize(writer, instance);
            }*/

            XmlSerializer ser = new XmlSerializer(typeof(Controller));

            XmlDocument xmlDoc = null;

            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, this);

                memStm.Position = 0;

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                using (XmlReader xtr = XmlReader.Create(memStm, settings))
                {
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(xtr);
                }
            }


            Debug.WriteLine(rsaKey.ToXmlString(true));
            try
            {
                // Encrypt the "creditcard" element.
                Encrypt(xmlDoc, "Controller", "rsaKey");

                // Inspect the EncryptedKey element.
                //InspectElement(xmlDoc);

                // Decrypt the "creditcard" element.
                //Decrypt(xmlDoc, "rsaKey");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            xmlDoc.Save("Save.xml");
        }

        public void Encrypt(XmlDocument Doc, string ElementToEncrypt, string KeyName)
        {
            // Check the arguments.  
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (ElementToEncrypt == null)
                throw new ArgumentNullException("ElementToEncrypt");

            ////////////////////////////////////////////////
            // Find the specified element in the XmlDocument
            // object and create a new XmlElemnt object.
            ////////////////////////////////////////////////

            XmlElement elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;

            // Throw an XmlException if the element was not found.
            if (elementToEncrypt == null)
            {
                throw new XmlException("The specified element was not found");

            }

            //////////////////////////////////////////////////
            // Create a new instance of the EncryptedXml class 
            // and use it to encrypt the XmlElement with the 
            // a new random symmetric key.
            //////////////////////////////////////////////////

            // Create a 256 bit Rijndael key.
            RijndaelManaged sessionKey = new RijndaelManaged();
            sessionKey.KeySize = 256;

            EncryptedXml eXml = new EncryptedXml();

            byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);

            ////////////////////////////////////////////////
            // Construct an EncryptedData object and populate
            // it with the desired encryption information.
            ////////////////////////////////////////////////


            EncryptedData edElement = new EncryptedData();
            edElement.Type = EncryptedXml.XmlEncElementUrl;

            // Create an EncryptionMethod element so that the 
            // receiver knows which algorithm to use for decryption.

            edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);

            // Encrypt the session key and add it to an EncryptedKey element.
            EncryptedKey ek = new EncryptedKey();

            byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, rsaKey, false);

            ek.CipherData = new CipherData(encryptedKey);

            ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);

            // Set the KeyInfo element to specify the
            // name of the RSA key.

            // Create a new KeyInfo element.
            edElement.KeyInfo = new KeyInfo();

            // Create a new KeyInfoName element.
            KeyInfoName kin = new KeyInfoName();

            // Specify a name for the key.
            kin.Value = KeyName;

            // Add the KeyInfoName element to the 
            // EncryptedKey object.
            ek.KeyInfo.AddClause(kin);

            // Add the encrypted key to the 
            // EncryptedData object.

            edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));

            // Add the encrypted element data to the 
            // EncryptedData object.
            edElement.CipherData.CipherValue = encryptedElement;

            ////////////////////////////////////////////////////
            // Replace the element from the original XmlDocument
            // object with the EncryptedData element.
            ////////////////////////////////////////////////////

            EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);

        }
    }
}
