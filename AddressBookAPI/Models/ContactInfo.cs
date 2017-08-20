using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookAPI.Models {
	public class ContactInfo {
		public string Id { get; set; }
		public string Title { get; set; }
		public string FirstName { get; set; }
		public string Surname { get; set; }
		public string Company { get; set; }
		public string Address01 { get; set; }
		public string Address02 { get; set; }
		public string Postcode { get; set; }
		public string Country { get; set; }
		public string HomePhone { get; set; }
		public string WorkPhone { get; set; }
		public string PersonalMobile { get; set; }
		public string WorkMobile { get; set; }
		public string PersonalEmail { get; set; }
		public string WorkEmail { get; set; }
	}
}
