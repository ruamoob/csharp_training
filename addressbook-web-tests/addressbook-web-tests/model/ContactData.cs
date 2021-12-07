using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
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
        private string email3 = "";
        private string homepage = "";
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
        public ContactData()
        {

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
            //return FirstName + " " + LastName;
            return "First name=" + FirstName + "\nLast name=" + LastName + "\nMiddlename=" + MiddleName + "\nNotes=" + Notes + "\nAddress=" + Address + "\nHomePhone=" + Home
                + "\nMobilePhone=" + Mobile + "\nWorkPhone=" + Work + "\nFax" + Fax;
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

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
               // return (from c in db.Contacts.Where(x=>x.Deprecated=="0000-00-00 00:00:00")  select c).ToList();
                return (from c in db.Contacts select c).ToList();
            }
        }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }
        [Column(Name = "middlename")]
        public string MiddleName { get { return middlename; } set { middlename = value; } }
        [Column(Name = "nickname")]
        public string NickName { get { return nickname; } set { nickname = value; } }
        [Column(Name = "title")]
        public string Title { get { return title; } set { title = value; } }
        [Column(Name = "company")]
        public string Company { get { return company; } set { company = value; } }
        [Column(Name = "address")]
        public string Address { get { return address; } set { address = value; } }
        [Column(Name = "home")]
        public string Home { get { return home; } set { home = value; } }
        [Column(Name = "mobile")]
        public string Mobile { get { return mobile; } set { mobile = value; } }
        [Column(Name = "work")]
        public string Work { get { return work; } set { work = value; } }
        [Column(Name = "fax")]
        public string Fax { get { return fax; } set { fax = value; } }
        [Column(Name = "email")]
        public string Email { get { return email; } set { email = value; } }
        [Column(Name = "email2")]
        public string Email2 { get { return email2; } set { email2 = value; } }
        [Column(Name = "email3")]
        public string Email3 { get { return email3; } set { email3 = value; } }
        public string Homepage { get { return homepage; } set { homepage = value; } }
        public string Bday { get { return bday; } set { bday = value; } }
        public string Bmonth { get { return bmonth; } set { bmonth = value; } }
        public string Byear { get { return byear; } set { byear = value; } }
        public string Aday { get { return aday; } set { aday = value; } }
        public string Amonth { get { return amonth; } set { amonth = value; } }
        public string Ayear { get { return ayear; } set { ayear = value; } }
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
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Phone2)).Trim();
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
                    string blok1;
                    string blok1_1;
                    string blok2;
                    string blok3;
                    string blok4;
                    string blok5;
                    string blok6;
                    string blok7;
                    string rn;

                      blok1 = FIODetails(FirstName) + FIODetails(MiddleName) + FIODetails(LastName);
                      blok1_1 = CompDetails(NickName) + CompDetails(Title) + CompDetails(Company) + CompDetails(Address);
                      blok2 = PhonesDetails(Home) + PhonesDetails(Mobile) + PhonesDetails(Work) + PhonesDetails(Fax);
                      blok3 = EmailDetails(Email) + EmailDetails(Email2) + EmailDetails(Email3) + EmailDetails(Homepage);
                      blok4 = DataDetails(Bday) + DataDetails(Bmonth) + DataDetails(Byear) + 
                              DataDetails(Aday) + DataDetails(Amonth) + DataDetails(Ayear);
                      blok5 = ElementDetails(Address2);
                      blok6 = PhonesDetails(Phone2);
                      blok7 = ElementDetails(Notes);
                      if ((blok1 != "") && (blok1_1 != "blok1_1")) { rn = "\r\n"; } else { rn = ""; };
   
                    return (blok1 + rn+ blok1_1 + RnRn(blok2) + blok2 + RnRn(blok3) + blok3 + RnRn(blok4) + blok4 + RnRn(blok5) + blok5 +
                    RnRn(blok6) + blok6 + RnRn(blok7) + blok7);
                
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
            }
            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
        }

        string ElementDetails(string element)
        {
            if (element == null || element == "")
            {
                return "";
            }
            if (element == Notes)
            {
                return element;
            }
            else
            {
                return element + "\r\n";
            }
        }

        string RnRn(string element)
        {
            if (element == "")
            {
                return "";
            }
            return "\r\n\r\n";
        }


        string EmailDetails(string element)
        {
            if (element == null || element == "")
            {
                return "";
            }
            else
            {
                if (element == Email || element == Email2 || element == Email3 || element == Homepage)
                {
                    if (element == Homepage)
                    {
                        return "Homepage:\r\n" + element + "\r\n";
                    }
                }
                return element + "\r\n";
            }
        }

        string DataDetails(string element)
        {
            if (element == null || element == "" || element == "-" || element == "0")
            {
                return "";
            }
            else
            {
                string bb = "";
                string aa = "";
                if (element == Bday || element == Aday || element == Bmonth || element == Amonth || element == Byear || element == Ayear)
                {
                    if (element == Bday)
                    {
                        return "Birthday " + element + ". ";
                    }

                    if (element == Bmonth)
                    {
                        return element + " ";
                    }

                    if (element == Byear)
                    {                   
                        bb = Convert.ToString(DateTime.Now.Year - Convert.ToInt32(Byear));                      
                        return element + " (" + bb + ")" + "\r\n";
                    }

                    if (element == Aday)
                    {
                        return "Anniversary " + element + ". ";
                    }

                    if (element == Amonth)
                    {
                        return element + " ";
                    }

                    if (element == Ayear)
                    {
                        aa = Convert.ToString(DateTime.Now.Year - Convert.ToInt32(Ayear)); 
                        return element + " (" + aa + ")" + "\r\n";
                    }
                
                }
                return element + "\r\n";
            }
        }

        string FIODetails(string element)
        {
            if (element == null || element == "")
            {
                return "";
            }
            else
            {
                if ((MiddleName!="" || FirstName!="") && (element == LastName))
                {
                    return  " "+ element;
                }
                if ( FirstName != "" && element == MiddleName)
                {
                    return " " + element;
                }
            }
            return element;
        }

        string CompDetails(string element)
        {
            if (element == null || element == "")
            {
                return "";
            }
            else
            {

                if ((Title != "" || Company != "" || Address != "") && (element == NickName))
                {
                    return element + "\r\n";
                }
                if ((Company != "" || Address != "") && (element == Title))
                {
                    return element + "\r\n";
                }
                if (( Address != "") && (element == Company))
                {
                    return element + "\r\n";
                }

            }
            return element;
        }


        string PhonesDetails(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                if (phone == home || phone == mobile || phone == fax || phone == work || phone == phone2)
                {

                    if (phone == mobile)
                    {
                        if (work != "" || fax != "")
                        {
                            return "M: " + phone + "\r\n";
                        }
                        else
                        {
                            return "M: " + phone;
                        }
                    }

                    if (phone == work)
                    {
                        if (fax != "")
                        {
                            return "W: " + phone + "\r\n";
                        }
                        else
                        {
                            return "W: " + phone;
                        }
                    }

                    if (phone == fax)
                    {
                        return "F: " + phone;
                    }

                    if (phone == phone2)
                    {
                        return "P: " + phone;
                    }
                } 
            }
            return "\r\n";
        }
    }
}
    

