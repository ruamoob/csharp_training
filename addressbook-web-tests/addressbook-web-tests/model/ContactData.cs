using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{      
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;
        private string middlename = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3="";
        private string homepage= "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";
        private string allPhones;
        private string allEmails;
        private string allDetailContacts;

        public ContactData(string firstname, string lastname)
        {
            //this.firstname = firstname;
            //this.lastname = lastname;
            FirstName = firstname;
            LastName = lastname;
        }
        public ContactData(string firstname, string lastname, string adress, string nickName)
        {
            //this.firstname = firstname;
            //this.lastname = lastname;
            FirstName = firstname; 
            LastName = lastname;
            Address = adress;
            NickName = nickName;
        }
                 
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(null, other))
            {
                return true;
            }

            return LastName == other.LastName && FirstName == other.FirstName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {           
            return FirstName + " " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Object.ReferenceEquals(FirstName, other.FirstName))
            {
                return LastName.CompareTo(other.LastName);
            }
            return FirstName.CompareTo(other.FirstName);
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Id { get; set; } 

        public string MiddleName {get { return middlename; } set { middlename = value;} }
        public string NickName { get { return nickname; } set { nickname = value; } }       
        public string Title {get {return title; } set { title = value;} }
        public string Company { get { return company; } set { company = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Home { get { return home; } set { home = value; } }
        public string Mobile { get { return mobile; } set { mobile = value; } }
        public string Work { get { return work; } set { work = value; } }
        public string Fax { get { return fax; } set { fax = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Email2 { get { return email2; } set { email2 = value; } }
        public string Email3 { get { return email3; } set { email3 = value; } }
        public string Homepage { get { return homepage; } set { homepage = value; } }
        public string Bday { get { return bday; } set { bday = value; } }
        public string Bmonth { get { return bmonth; } set { bmonth = value; } }
        public string Byear { get { return byear; } set { byear = value; } }
        public string Aday { get { return aday; } set {aday = value; } }
        public string Amonth { get { return amonth; } set { amonth = value; } }
        public string Ayear { get { return ayear; } set { ayear = value; }  }
        public string Address2 { get { return address2; } set { address2 = value; } }
        public string Phone2 { get { return phone2; } set { phone2 = value; } }
        public string Notes { get { return notes; } set { notes = value; } }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)+CleanUp(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

      
      public string AllDetailContacts
        {
            get
            {
                if (allDetailContacts != null)
                {
                    return allDetailContacts;
                }
                else
                {
                    string bb;
                    string aa;
                    if (Byear != null)
                    { bb = Convert.ToString(DateTime.Now.Year - Convert.ToInt32(Byear)); } else { bb = ""; };
                    if (Ayear != null)
                    { aa = Convert.ToString(DateTime.Now.Year - Convert.ToInt32(Ayear)); } else { aa = ""; };

                    return (CleanUp2(FirstName) + CleanUp2(MiddleName) + CleanUp2(LastName) +
                        CleanUp2(NickName) + CleanUp2(Title) + CleanUp2(Company) +
                        CleanUp2(Address) + CleanUp2(Home) + CleanUp2(Mobile) + CleanUp2(Work) + CleanUp2(Fax) +
                        CleanUp2(Email) + CleanUp2(Email2) + CleanUp2(Email3) +
                        CleanUp2(Homepage) + CleanUp2(Bday) + "." + CleanUp2(Bmonth) 
                        + CleanUp2(Byear) + bb  + CleanUp2(Aday) + "." + CleanUp2(Amonth) + CleanUp2(Ayear) 
                        + aa + CleanUp2(Address2) + CleanUp2(Notes)).Trim();
                }
            }
            set
            {
                allDetailContacts = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
        }

        private string CleanUp2(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
           // return text.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
           return Regex.Replace(text, "[ ()-]", "");
        }
    }
}
