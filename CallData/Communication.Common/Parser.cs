using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using CallData.Models;
using Sax.Net;
using Sax.Net.Helpers;

namespace Communication.Common
{
    public class Parser
    {
        /// <summary>
        /// Class that implements SaxHandler functionality
        /// </summary>
        private class SaxHandler : DefaultHandler
        {
            public SaxHandler()
            {
                _bills = new List<Bill>();
            }

            /// <summary>
            /// List of parsed bills
            /// </summary>
            private List<Bill> _bills;

            /// <summary>
            /// Id of current bill
            /// </summary>
            private int _currentId;

            /// <summary>
            /// content of current node
            /// </summary>
            private string _currentNodeContent;

            /// <summary>
            /// Title of current bill
            /// </summary>
            private string _currentTitle;

            /// <summary>
            /// returns copy of parsed bills
            /// </summary>
            public List<Bill> Bills
            {
                get { return new List<Bill>(_bills); }
            }

            // Called when Sax finds start of some element. Gets id of a bill
            public override void StartElement(string uri, string localName, string qName, IAttributes atts)
            {
                switch (qName)
                {
                    case "bill":
                        _currentId = int.Parse(atts.GetValue("id"));
                        break;
                }
            }

            // Called when Sax founds closing tag. Creates new bill and adds it to list
            public override void EndElement(string uri, string localName, string qName)
            {
                switch (qName)
                {
                    case "bill":
                        _bills.Add(new Bill() { Id = _currentId, Name = _currentTitle });
                        break;
                    case "title":
                        _currentTitle = _currentNodeContent;
                        break;
                }
            }

            //Called when sax reads content beetween tags
            public override void Characters(char[] ch, int start, int length)
            {
                _currentNodeContent = new string(ch, start, length).Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IXmlReader _xmlReader;

        public Parser()
        {
            _xmlReader = XmlReaderFactory.Current.CreateXmlReader();
        }

        /// <summary>
        ///     Parses file with Linq to xml
        /// </summary>
        /// <param name="pathToFile">uri to file with xml</param>
        /// <returns>IEnumarable of bills</returns>
        public IEnumerable<Bill> ParseWithDom(string pathToFile)
        {
            XDocument doc = XDocument.Load(pathToFile);
            var bills = doc.Element("bills")
                .Elements("bill")
                .Select(bill => new Bill() { Id = int.Parse(bill.Attribute("id").Value), Name = bill.Element("title").Value });

            return bills;
        }

        /// <summary>
        ///     Parses file with a help of SAX.NET
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <returns>IEnumarable of bills (List) works slowly</returns>
        public IEnumerable<Bill> ParseWithSax(string pathToFile)
        {
            var handler = new SaxHandler();
            _xmlReader.ContentHandler = handler;
            _xmlReader.ErrorHandler = handler;

            using (var file = new StreamReader(pathToFile))
            {
                _xmlReader.Parse(new InputSource(file));
            }

            return handler.Bills;
        }
    }
}
