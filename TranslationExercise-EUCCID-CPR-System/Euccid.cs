using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TranslationExercise_EUCCID_CPR_System
{
  public class Euccid
  {
    private string firstname;
    private string familyname;
    private long euccid;
    private string gender;
    private string streetnumberofhouse;
    private int apartment;
    private string country;
    private string city;
    private string birthcountry;
    private string currentlivingincountry;

    public Euccid()
    {

    }

    public Euccid(string firstname, string familyname, long euccid, string gender, string streetnumberofhouse, int apartment, string country, string city, string birthcountry, string currentlivingincountry)
    {
      this.firstname = firstname;
      this.familyname = familyname;
      this.euccid = euccid;
      this.gender = gender;
      this.streetnumberofhouse = streetnumberofhouse;
      this.apartment = apartment;
      this.country = country;
      this.city = city;
      this.birthcountry = birthcountry;
      this.currentlivingincountry = currentlivingincountry;
    }
    public string Firstname { set { firstname = value; } get { return firstname; } }
    public string Familyname { set { familyname = value; } get { return familyname; } }
    public long EuccID { set { euccid = value; } get { return euccid; } }
    public string Gender { set { gender = value; } get { return gender; } }
    public string StreetNumberOfHouse { set { streetnumberofhouse = value; } get { return streetnumberofhouse; } }
    public int Apartment { set { apartment = value; } get { return apartment; } }
    public string Country { set { country = value; } get { return country; } }
    public string City { set { city = value; } get { return city; } }
    public string BirthCountry { set { birthcountry = value; } get { return birthcountry; } }
    public string CurrentLivingInCountry { set { currentlivingincountry = value; } get { return currentlivingincountry; } }

    public void SaveToXML()
    {
      XmlDocument euccidxml = new XmlDocument();

      XmlNode root = euccidxml.CreateElement("EUCCID");
      euccidxml.AppendChild(root);

      XmlNode nodeFirstname = euccidxml.CreateElement("Firstname");
      nodeFirstname.InnerText = firstname;
      root.AppendChild(nodeFirstname);

      XmlNode nodeFamily = euccidxml.CreateElement("Family");
      nodeFamily.InnerText = familyname;
      root.AppendChild(nodeFamily);

      XmlNode nodeEUCCID = euccidxml.CreateElement("EUCCID");
      nodeEUCCID.InnerText = "" + euccid;
      root.AppendChild(nodeEUCCID);

      XmlNode nodeGender = euccidxml.CreateElement("Gender");
      nodeGender.InnerText = gender;
      root.AppendChild(nodeGender);

      XmlNode nodeStreetNumberOfHouse = euccidxml.CreateElement("StreetNumberofhouse");
      nodeStreetNumberOfHouse.InnerText = streetnumberofhouse;
      root.AppendChild(nodeStreetNumberOfHouse);

      XmlNode nodeApartment = euccidxml.CreateElement("Apartment");
      nodeApartment.InnerText = "" + apartment;
      root.AppendChild(nodeApartment);

      XmlNode nodeCountry = euccidxml.CreateElement("Country");
      nodeCountry.InnerText = country;
      root.AppendChild(nodeCountry);

      XmlNode nodeCity = euccidxml.CreateElement("City");
      nodeCity.InnerText = city;
      root.AppendChild(nodeCity);

      XmlNode nodeBirthCountry = euccidxml.CreateElement("BirthCountry");
      nodeBirthCountry.InnerText = birthcountry;
      root.AppendChild(nodeBirthCountry);

      XmlNode nodeCurrentLivingCountry = euccidxml.CreateElement("CurrentLivingCountry");
      nodeCurrentLivingCountry.InnerText = currentlivingincountry;
      root.AppendChild(nodeCurrentLivingCountry);


      euccidxml.Save("EUCCID.xml");
    }
    public XmlDocument ObjToXML
    {
      get
      {
        XmlDocument euccidxml = new XmlDocument();

        XmlNode root = euccidxml.CreateElement("EUCCID");
        euccidxml.AppendChild(root);

        XmlNode nodeFirstname = euccidxml.CreateElement("Firstname");
        nodeFirstname.InnerText = Firstname;
        root.AppendChild(nodeFirstname);

        XmlNode nodeFamily = euccidxml.CreateElement("Family");
        nodeFamily.InnerText = Familyname;
        root.AppendChild(nodeFamily);

        XmlNode nodeEUCCID = euccidxml.CreateElement("EUCCID");
        nodeEUCCID.InnerText = "" + EuccID;
        root.AppendChild(nodeEUCCID);

        XmlNode nodeGender = euccidxml.CreateElement("Gender");
        nodeGender.InnerText = Gender;
        root.AppendChild(nodeGender);

        XmlNode nodeStreetNumberOfHouse = euccidxml.CreateElement("StreetNumberofhouse");
        nodeStreetNumberOfHouse.InnerText = StreetNumberOfHouse;
        root.AppendChild(nodeStreetNumberOfHouse);

        XmlNode nodeApartment = euccidxml.CreateElement("Apartment");
        nodeApartment.InnerText = "" + Apartment;
        root.AppendChild(nodeApartment);

        XmlNode nodeCountry = euccidxml.CreateElement("Country");
        nodeCountry.InnerText = Country;
        root.AppendChild(nodeCountry);

        XmlNode nodeCity = euccidxml.CreateElement("City");
        nodeCity.InnerText = City;
        root.AppendChild(nodeCity);

        XmlNode nodeBirthCountry = euccidxml.CreateElement("BirthCountry");
        nodeBirthCountry.InnerText = BirthCountry;
        root.AppendChild(nodeBirthCountry);

        XmlNode nodeCurrentLivingCountry = euccidxml.CreateElement("CurrentLivingCountry");
        nodeCurrentLivingCountry.InnerText = CurrentLivingInCountry;
        root.AppendChild(nodeCurrentLivingCountry);
        return euccidxml;
      }
    }
  }
}