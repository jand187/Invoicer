using System;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web.Http;
using Pechkin;

namespace InvoicerHost.Api
{
	public class InvoiceController : ApiController
	{
		public string Get()
		{
			var config = new GlobalConfig();
			config.SetMargins(0, 0, 100, 0);
			config.SetOutputDpi(300);
			config.SetPaperSize(PaperKind.A4);

			var converter = Factory.Create(config);
			var contents = File.ReadAllText(@"C:\Users\janand\Documents\GitHub\Invoicer\InvoicerHost\invoice.html");
			var pdfBytes = converter.Convert(contents);

			using (var writer = new BinaryWriter(new FileStream(@"C:\Users\janand\Documents\test.pdf", FileMode.Create)))
			{
				writer.Write(pdfBytes);
			}

			return "yeah!";
		}

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
