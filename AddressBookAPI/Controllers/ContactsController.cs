using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBookAPI.Data;
using AddressBookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookAPI.Controllers {
	[Produces("application/json")]
	[Route("api/Contacts")]
	public class ContactsController : Controller {
		private ApiContext context;

		public ContactsController(ApiContext context) { this.context = context; }

		[HttpGet]
		public ActionResult Get() {
			return Ok(context.Contacts);
		}

		[HttpGet("firstName/{firstName}")]
		public ActionResult SearchFirstName(string firstName) {
			var result = context.Contacts.Where(c => c.FirstName.Contains(firstName));

			return Ok(result);
		}

		[HttpGet("company/{company}")]
		public ActionResult SearchCompany(string company) {
			var result = context.Contacts.Where(c => c.Company.Contains(company));

			return Ok(result);
		}

		[HttpPost]
		public ActionResult Post([FromBody] ContactInfo contactInfo) {
			var dbContactInfo = context.Contacts.Add(contactInfo).Entity;
			context.SaveChanges();
			return Ok(dbContactInfo);
		}
	}
}