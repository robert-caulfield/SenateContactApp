using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SenateContactApp
{
    public class Senator
    {
        #region Private Variables
        private string fullMember;
        private string firstName;
        private string lastName;
        private string party;
        private string state;
        private string address;
        private string phone;
        private string email;
        private string website;
        private string classNumeral;
        private string bioGuideID;
        #endregion

        #region Properties
        [XmlElement("member_full")]
        public string FullMember { get { return fullMember; } set { fullMember = value; } }

        [XmlElement("last_name")]
        public string LastName { get { return lastName; } set { lastName = value; } }

        [XmlElement("first_name")]
        public string FirstName { get { return firstName; } set { firstName = value; } }

        [XmlElement("party")]
        public string Party { get { return party; } set { party = value; } }

        [XmlElement("state")]
        public string State { get { return state; } set { state = value; } }

        [XmlElement("address")]
        public string Address { get { return address; } set { address = value; } }

        [XmlElement("phone")]
        public string Phone { get { return phone; } set { phone = value; } }

        [XmlElement("email")]
        public string Email { get { return email; } set { email = value; } }

        [XmlElement("website")]
        public string Website { get { return website; } set { website = value; } }

        [XmlElement("class")]
        public string ClassNumeral { get { return classNumeral; } set { classNumeral = value; } }

        [XmlElement("bioguide_id")]
        public string BioGuideID { get { return bioGuideID; } set { bioGuideID = value; } }

        #region Read Only

        public string PartyFull {
            get { 
                switch (party)
                {
                    case "R":
                        return "Republican";
                    case "D":
                        return "Democrat";
                    case "I":
                        return "Independent";
                    default:
                        return party;
                };
            } 
        }

        public string NameFull
        {
            get
            {
                return firstName + " " + lastName;
            }
        }

        #endregion

        #endregion

    }
}
