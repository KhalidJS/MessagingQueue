using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Messaging;

namespace CPR_Register
{
  class Program
  {
    static void Main(string[] args)
    {
      // load a common data xml
      // Exercise 5
      CPR cpr = new CPR();
      cpr.LoadCommonData("CommonData.xml");
      cpr.SaveAsCPRXml();

      // load a common data from MQ
      // Exercise 6
      if (MessageQueue.Exists(".\\Private$\\CommonData"))
      {
        
        MessageQueue myqueue = new MessageQueue(".\\Private$\\CommonData");
        myqueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(XmlDocument) });
        Message m = myqueue.Receive();
        XmlDocument doc = (XmlDocument)m.Body;
        // Test loaded data on console
        /*
         foreach (XmlNode node in doc.SelectNodes("CommonData"))
        {
          foreach (XmlNode nodeText in node)
          {
            Console.WriteLine(nodeText.InnerText);
          }
        }
         Console.ReadLine();
        */

        // Save the MQ data to xml file
        CPR cprCommonData = new CPR();
        cprCommonData.LoadCommonData(doc);
        cprCommonData.SaveCommonDataFromMQAsCPRXml();

        // print out the data to the console -test
        // important to clear messages from the queue and run the translation application then after run this application or it
        // will not print out anything to the console.
        cprCommonData.PrintOutDataFromSavedXML();
      }
      else
      {
        Console.WriteLine("The message commondata not found");
        Console.ReadLine();
      }
    }
  }
}
