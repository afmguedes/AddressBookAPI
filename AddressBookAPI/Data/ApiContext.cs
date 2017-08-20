using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressBookAPI.Models;
using Microsoft.EntityFrameworkCore;
using Contact = Microsoft.Azure.KeyVault.Models.Contact;

namespace AddressBookAPI.Data {
	public class ApiContext : DbContext {
		public ApiContext(DbContextOptions options) : base(options) { }

		public DbSet<ContactInfo> Contacts { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
