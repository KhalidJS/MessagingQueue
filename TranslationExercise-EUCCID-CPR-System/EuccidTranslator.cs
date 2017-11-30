using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace TranslationExercise_EUCCID_CPR_System
{
  public class EuccidTranslator
  {
    Dictionary<string, string> DicXml;
    public EuccidTranslator(string xmlfile)
    {
      DicXml = new Dictionary<string, string>();
      XmlDocument xmldoc = new XmlDocument();
      try
      {
        xmldoc.Load(xmlfile);

        foreach (XmlNode node in xmldoc.SelectNodes("EUCCID"))
        {
          // take out information that can be used by CPR - application.
          DicXml.Add("Firstname",node["Firstname"].InnerText);
          DicXml.Add("Family",node["Family"].InnerText);
          DicXml.Add("EUCCID",node["EUCCID"].InnerText);
          DicXml.Add("Gender",node["Gender"].InnerText);
          DicXml.Add("Address", node["StreetNumberofhouse"].InnerText);
          DicXml.Add("City",node["City"].InnerText);
        }
      }
      catch (FileNotFoundException fex)
      {
        Console.WriteLine(fex.Message);
        Console.ReadLine();
      }
    }

    public EuccidTranslator(XmlDocument doc)
    {
      DicXml = new Dictionary<string, string>();
      try
      {
        foreach (XmlNode node in doc.SelectNodes("EUCCID"))
        {
          DicXml.Add("Firstname", node["Firstname"].InnerText);
          DicXml.Add("Family", node["Family"].InnerText);
          DicXml.Add("EUCCID", node["EUCCID"].InnerText);
          DicXml.Add("Gender", node["Gender"].InnerText);
          DicXml.Add("Address", node["StreetNumberofhouse"].InnerText);
          DicXml.Add("City", node["City"].InnerText);
        }
      }
      catch (FileNotFoundException fex)
      {
        Console.WriteLine(fex.Message);
        Console.ReadLine();
      }
    }

    public XmlDocument GetTranslatedDataXML
    {
      get
      {
        XmlDocument doc = new XmlDocument();

        XmlNode rootNode = doc.CreateElement("CommonData");
        doc.AppendChild(rootNode);

        XmlNode nodeFirstname = doc.CreateElement("Firstname");
        nodeFirstname.InnerText = DicXml["Firstname"];
        rootNode.AppendChild(nodeFirstname);

        XmlNode nodeFamily = doc.CreateElement("Family");
        nodeFamily.InnerText = DicXml["Family"];
        rootNode.AppendChild(nodeFamily);

        XmlNode nodeEuccid = doc.CreateElement("EUCCID");
        nodeEuccid.InnerText = DicXml["EUCCID"];
        rootNode.AppendChild(nodeEuccid);

        XmlNode nodeGender = doc.CreateElement("Gender");
        nodeGender.InnerText = DicXml["Gender"];
        rootNode.AppendChild(nodeGender);

        XmlNode nodeAddress = doc.CreateElement("Address");
        nodeAddress.InnerText = DicXml["Address"];
        rootNode.AppendChild(nodeAddress);

        XmlNode nodeCity = doc.CreateElement("City");
        nodeCity.InnerText = DicXml["City"];
        rootNode.AppendChild(nodeCity);
        return doc;
      }
    }

    public void SaveToCommonDataXML()
    {
      XmlDocument doc = new XmlDocument();

      XmlNode rootNode = doc.CreateElement("CommonData");
      doc.AppendChild(rootNode);

      XmlNode nodeFirstname = doc.CreateElement("Firstname");
      nodeFirstname.InnerText = DicXml["Firstname"];
      rootNode.AppendChild(nodeFirstname);

      XmlNode nodeFamily = doc.CreateElement("Family");
      nodeFamily.InnerText = DicXml["Family"];
      rootNode.AppendChild(nodeFamily);

      XmlNode nodeEuccid = doc.CreateElement("EUCCID");
      nodeEuccid.InnerText = DicXml["EUCCID"];
      rootNode.AppendChild(nodeEuccid);

      XmlNode nodeGender = doc.CreateElement("Gender");
      nodeGender.InnerText = DicXml["Gender"];
      rootNode.AppendChild(nodeGender);

      XmlNode nodeAddress = doc.CreateElement("Address");
      nodeAddress.InnerText = DicXml["Address"];
      rootNode.AppendChild(nodeAddress);

      XmlNode nodeCity = doc.CreateElement("City");
      nodeCity.InnerText = DicXml["City"];
      rootNode.AppendChild(nodeCity);
      doc.Save("CommonData.xml");
    }
  }
}