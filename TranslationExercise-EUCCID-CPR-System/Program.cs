using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Xml;

namespace TranslationExercise_EUCCID_CPR_System
{
  class Program
  {
    static void Main(string[] args)
    {
      // Exercise 5
      // EUCCID data to xml format.
      Euccid JohnDoe = new Euccid("John", "Doe", 851106000000, "Male", "49 Mystery Street", 73, "England", "London", "England", "England");
      JohnDoe.SaveToXML();

      // Exercise 5
      // Translate EUCCID data in xml file to a common data format.
      EuccidTranslator translator = new EuccidTranslator("EUCCID.xml");
      translator.SaveToCommonDataXML();

      // Exercise 6
      // EUCCID send as MQ
      Euccid JannaDoe = new Euccid();
      JannaDoe.Firstname = "Janna";
      JannaDoe.Familyname = "Doe";
      JannaDoe.EuccID = 881227000000;
      JannaDoe.Gender = "Female";
      JannaDoe.StreetNumberOfHouse = "48 Mystery Street";
      JannaDoe.Apartment = 73;
      JannaDoe.Country = "England";
      JannaDoe.City = "London";
      JannaDoe.BirthCountry = "England";
      JannaDoe.CurrentLivingInCountry = "England";

      XmlDocument JannaDoeXML = JannaDoe.ObjToXML;
      // run this application twice. In some reason it´s working on second time.
      if (MessageQueue.Exists(".\\Private$\\EUCCID"))
      {
        MessageQueue.Delete(".\\Private$\\EUCCID");
      }
      else
      {
        MessageQueue myeuccidqueue = new MessageQueue(".\\Private$\\EUCCID");
        MessageQueue.Create(".\\Private$\\EUCCID");
        Message mynewMessage = new Message();
        mynewMessage.Body = JannaDoeXML;
        myeuccidqueue.Send(mynewMessage, "EUCCID");
        Console.WriteLine("EUCCID messagequeue succesfully created");
      }
      // Send shared data as MQ
      if (MessageQueue.Exists(".\\Private$\\CommonData"))
      {
        MessageQueue.Delete(".\\Private$\\CommonData");
      }
      else
      {
        MessageQueue mycommondataqueue = new MessageQueue(".\\Private$\\CommonData");
        MessageQueue.Create(".\\Private$\\CommonData");
        EuccidTranslator DataTranslator = new EuccidTranslator(JannaDoeXML);
        XmlDocument DataTranslatorXML = DataTranslator.GetTranslatedDataXML;
        Message messageCommonData = new Message();
        messageCommonData.Body = DataTranslatorXML;
        mycommondataqueue.Send(messageCommonData, "CommonDataMessage");
        Console.WriteLine("Shared Data messagequeue succesfully created");
      }
      Console.ReadLine();
    }
  }
}