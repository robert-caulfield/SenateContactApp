using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SenateContactApp
{
    [XmlRoot("contact_information")]
    public class SenatorListContainer
    {

        private List<Senator> senatorList;

        [XmlElement("member", Namespace = "")]
        public List<Senator> SenatorList { get { return senatorList; } set { senatorList = value; } }
    }
}
