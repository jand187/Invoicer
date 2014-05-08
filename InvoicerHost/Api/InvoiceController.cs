using System;
using System.Linq;
using System.Web.Http;

namespace InvoicerHost.Api
{
	public class InvoiceController : ApiController
	{
		public void Post(Invoice invoice)
		{
			throw new NotImplementedException();
		}
	}

	public class Invoice
	{
		public DateTime PeriodStart { get; set; }
		public DateTime PeriodEnd { get; set; }
		public decimal Hours { get; set; }
		public int InvoiceNumber { get; set; }
	}
}
