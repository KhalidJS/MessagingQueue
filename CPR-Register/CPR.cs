using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace CPR_Register
{
  public class CPR
  {
    private string firstname;
    private string surname;
    private int cprnumber;
    private string address1;
    private string address2;
    private int postalcode;
    private string city;
    private string martialstatus;
    private int spousecprnumber;
    private int childrenscprnumber;
    private int parentscprnumber;
    private int doctorcvrnumber;
    private Dictionary<string, string> diccpr;

    public CPR()
    {
      diccpr = new Dictionary<string, string>();
    }
    public CPR(string firstname,
    string surname,
     int cprnumber,
     string address1,
     string address2,
     int postalcode,
    string city,
     string martialstatus,
     int spousecprnumber,
     int childrenscprnumber,
    int parentscprnumber,
     int doctorcvrnumber)
    {
      this.firstname = firstname;
      this.surname = surname;
      this.cprnumber = cprnumber;
      this.address1 = address1;
      this.address2 = address2;
      this.postalcode = postalcode;
      this.city = city;
      this.martialstatus = martialstatus;
      this.spousecprnumber = spousecprnumber;
      this.childrenscprnumber = childrenscprnumber;
      this.parentscprnumber = parentscprnumber;
      this.doctorcvrnumber = doctorcvrnumber;
    }

    public void LoadCommonData(string commonDataXMLFile)
    {
      XmlDocument doc = new XmlDocument();
      try
      {
        doc.Load(commonDataXMLFile);

        foreach (XmlNode node in doc.SelectNodes("CommonData"))
        {
          diccpr.Add("Firstname", node["Firstname"].InnerText);
          diccpr.Add("Surname", node["Family"].InnerText);
          diccpr.Add("EUCCID", node["EUCCID"].InnerText);
          diccpr.Add("Gender", node["Gender"].InnerText);
          diccpr.Add("Address", node["Address"].InnerText);
          diccpr.Add("City", node["City"].InnerText);
        }
      }
      catch (FileNotFoundException fex)
      {
        Console.WriteLine(fex.Message);
      }
    }
    public void LoadCommonData(XmlDocument doc)
    {
      try
      {
        foreach (XmlNode node in doc.SelectNodes("CommonData"))
        {
          diccpr.Add("Firstname", node["Firstname"].InnerText);
          diccpr.Add("Surname", node["Family"].InnerText);
          diccpr.Add("EUCCID", node["EUCCID"].InnerText);
          diccpr.Add("Gender", node["Gender"].InnerText);
          diccpr.Add("Address", node["Address"].InnerText);
          diccpr.Add("City", node["City"].InnerText);
        }
      }
      catch (FileNotFoundException fex)
      {
        Console.WriteLine(fex.Message);
      }
    }
    public void SaveAsCPRXml()
    {
      XmlDocument cprxml = new XmlDocument();
      XmlNode rootNode = cprxml.CreateElement("CPR");
      cprxml.AppendChild(rootNode);

      XmlNode nodefirstname = cprxml.CreateElement("Firstname");
      nodefirstname.InnerText = diccpr["Firstname"];
      rootNode.AppendChild(nodefirstname);

      XmlNode nodesurname = cprxml.CreateElement("Surname");
      nodesurname.InnerText = diccpr["Surname"];
      rootNode.AppendChild(nodesurname);

      // the last 4 digit gets a odd number if gender is male even if it´s female
      XmlNode nodecprnumber = cprxml.CreateElement("CPRNumber");
      if (diccpr["Gender"] == "Male")
      {
        nodecprnumber.InnerText = diccpr["EUCCID"].Substring(0, 6) + "XXXX"; // male digit
      }
      else
      {
        nodecprnumber.InnerText = diccpr["EUCCID"].Substring(0, 6) + "XXXX"; // female digit
      }

      rootNode.AppendChild(nodecprnumber);

      XmlNode nodeaddress1 = cprxml.CreateElement("Address1");
      nodeaddress1.InnerText = diccpr["Address"];
      rootNode.AppendChild(nodeaddress1);

      XmlNode nodeaddress2 = cprxml.CreateElement("Address2");
      nodeaddress2.InnerText = "";
      rootNode.AppendChild(nodeaddress2);

      XmlNode nodepostalcode = cprxml.CreateElement("PostalCode");
      nodepostalcode.InnerText = "";
      rootNode.AppendChild(nodepostalcode);

      XmlNode nodecity = cprxml.CreateElement("City");
      nodecity.InnerText = diccpr["City"];
      rootNode.AppendChild(nodecity);

      XmlNode nodemartialstatus = cprxml.CreateElement("MartialStatus");
      nodemartialstatus.InnerText = "";
      rootNode.AppendChild(nodemartialstatus);

      XmlNode nodespousecprnumber = cprxml.CreateElement("SpouseCPRNumber");
      nodespousecprnumber.InnerText = "";
      rootNode.AppendChild(nodespousecprnumber);

      XmlNode nodechildrenscprnumber = cprxml.CreateElement("ChildrensCPRNumber");
      nodechildrenscprnumber.InnerText = "";
      rootNode.AppendChild(nodechildrenscprnumber);

      XmlNode nodeparentscprnumber = cprxml.CreateElement("ParentsCPRNumber");
      nodeparentscprnumber.InnerText = "";
      rootNode.AppendChild(nodeparentscprnumber);

      XmlNode nodedoctorcvrnumber = cprxml.CreateElement("DoctorCVRNumber");
      nodedoctorcvrnumber.InnerText = "";
      rootNode.AppendChild(nodedoctorcvrnumber);

      cprxml.Save("CPR.xml");
    }

    public void SaveCommonDataFromMQAsCPRXml()
    {
      XmlDocument cprxml = new XmlDocument();
      XmlNode rootNode = cprxml.CreateElement("CPR");
      cprxml.AppendChild(rootNode);

      XmlNode nodefirstname = cprxml.CreateElement("Firstname");
      nodefirstname.InnerText = diccpr["Firstname"];
      rootNode.AppendChild(nodefirstname);

      XmlNode nodesurname = cprxml.CreateElement("Surname");
      nodesurname.InnerText = diccpr["Surname"];
      rootNode.AppendChild(nodesurname);

      // the last 4 digit gets a odd number if gender is male even if it´s female
      XmlNode nodecprnumber = cprxml.CreateElement("CPRNumber");
      if (diccpr["Gender"] == "Male")
      {
        nodecprnumber.InnerText = diccpr["EUCCID"].Substring(0, 6) + "XXXX"; // male digit
      }
      else
      {
        nodecprnumber.InnerText = diccpr["EUCCID"].Substring(0, 6) + "XXXX"; // female digit
      }

      rootNode.AppendChild(nodecprnumber);

      XmlNode nodeaddress1 = cprxml.CreateElement("Address1");
      nodeaddress1.InnerText = diccpr["Address"];
      rootNode.AppendChild(nodeaddress1);

      XmlNode nodeaddress2 = cprxml.CreateElement("Address2");
      nodeaddress2.InnerText = "";
      rootNode.AppendChild(nodeaddress2);

      XmlNode nodepostalcode = cprxml.CreateElement("PostalCode");
      nodepostalcode.InnerText = "";
      rootNode.AppendChild(nodepostalcode);

      XmlNode nodecity = cprxml.CreateElement("City");
      nodecity.InnerText = diccpr["City"];
      rootNode.AppendChild(nodecity);

      XmlNode nodemartialstatus = cprxml.CreateElement("MartialStatus");
      nodemartialstatus.InnerText = "";
      rootNode.AppendChild(nodemartialstatus);

      XmlNode nodespousecprnumber = cprxml.CreateElement("SpouseCPRNumber");
      nodespousecprnumber.InnerText = "";
      rootNode.AppendChild(nodespousecprnumber);

      XmlNode nodechildrenscprnumber = cprxml.CreateElement("ChildrensCPRNumber");
      nodechildrenscprnumber.InnerText = "";
      rootNode.AppendChild(nodechildrenscprnumber);

      XmlNode nodeparentscprnumber = cprxml.CreateElement("ParentsCPRNumber");
      nodeparentscprnumber.InnerText = "";
      rootNode.AppendChild(nodeparentscprnumber);

      XmlNode nodedoctorcvrnumber = cprxml.CreateElement("DoctorCVRNumber");
      nodedoctorcvrnumber.InnerText = "";
      rootNode.AppendChild(nodedoctorcvrnumber);
      
      cprxml.Save("MQCPR.xml");
      Console.WriteLine("CPR data successfully saved as xml-file");
    }


    public void SaveCPRXML()
    {
      XmlDocument cprxml = new XmlDocument();
      XmlNode rootNode = cprxml.CreateElement("CPR");
      cprxml.AppendChild(rootNode);

      XmlNode nodefirstname = cprxml.CreateElement("Firstname");
      nodefirstname.InnerText = Firstname;
      rootNode.AppendChild(nodefirstname);

      XmlNode nodesurname = cprxml.CreateElement("Surname");
      nodesurname.InnerText = Surname;
      rootNode.AppendChild(nodesurname);

      XmlNode nodecprnumber = cprxml.CreateElement("CPRNumber");
      nodecprnumber.InnerText = "" + Cprnumber;
      rootNode.AppendChild(nodecprnumber);

      XmlNode nodeaddress1 = cprxml.CreateElement("Address1");
      nodeaddress1.InnerText = Address1;
      rootNode.AppendChild(nodeaddress1);

      XmlNode nodeaddress2 = cprxml.CreateElement("Address2");
      nodeaddress2.InnerText = Address2;
      rootNode.AppendChild(nodeaddress2);

      XmlNode nodepostalcode = cprxml.CreateElement("PostalCode");
      nodepostalcode.InnerText = "" + PostalCode;
      rootNode.AppendChild(nodepostalcode);

      XmlNode nodecity = cprxml.CreateElement("City");
      nodecity.InnerText = City;
      rootNode.AppendChild(nodecity);

      XmlNode nodemartialstatus = cprxml.CreateElement("MartialStatus");
      nodemartialstatus.InnerText = MartialStatus;
      rootNode.AppendChild(nodemartialstatus);

      XmlNode nodespousecprnumber = cprxml.CreateElement("SpouseCPRNumber");
      nodespousecprnumber.InnerText = "" + SpouseCprNumber;
      rootNode.AppendChild(nodespousecprnumber);

      XmlNode nodechildrenscprnumber = cprxml.CreateElement("ChildrensCPRNumber");
      nodechildrenscprnumber.InnerText = "" + ChildrensCprNumber;
      rootNode.AppendChild(nodechildrenscprnumber);

      XmlNode nodeparentscprnumber = cprxml.CreateElement("ParentsCPRNumber");
      nodeparentscprnumber.InnerText = "" + ParentsCprNumber;
      rootNode.AppendChild(nodeparentscprnumber);

      XmlNode nodedoctorcvrnumber = cprxml.CreateElement("DoctorCVRNumber");
      nodedoctorcvrnumber.InnerText = "" + DoctorCVRNumber;
      rootNode.AppendChild(nodedoctorcvrnumber);

      cprxml.Save("CPR.xml");
    }

    public string Firstname { set { firstname = value; } get { return firstname; } }
    public string Surname { set { surname = value; } get { return surname; } }
    public int Cprnumber { set { cprnumber = value; } get { return cprnumber; } }
    public string Address1 { set { address1 = value; } get { return address1; } }
    public string Address2 { set { address2 = value; } get { return address2; } }
    public int PostalCode { set { postalcode = value; } get { return postalcode; } }
    public string City { set { city = value; } get { return city; } }
    public string MartialStatus { set { martialstatus = value; } get { return martialstatus; } }
    public int SpouseCprNumber { set { spousecprnumber = value; } get { return spousecprnumber; } }
    public int ChildrensCprNumber { set { childrenscprnumber = value; } get { return childrenscprnumber; } }
    public int ParentsCprNumber { set { parentscprnumber = value; } get { return parentscprnumber; } }
    public int DoctorCVRNumber { set { doctorcvrnumber = value; } get { return doctorcvrnumber; } }

    public  void PrintOutDataFromSavedXML()
    {
      try
      {
        XmlDocument doc = new XmlDocument();
        doc.Load("MQCPR.xml");

        foreach (XmlNode node in doc.SelectNodes("CPR"))
        {
          foreach (XmlNode nodeText in node)
          {
            Console.WriteLine(nodeText.InnerText);
          }
        }
        Console.ReadLine();
      }
      catch (FileNotFoundException fex)
      {
        Console.WriteLine(fex.Message);
        Console.ReadLine();
      }
    }
  }
}