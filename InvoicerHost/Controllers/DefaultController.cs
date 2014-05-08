using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace InvoicerHost.Controllers
{
	public class DefaultController : ApiController
	{
		public HtmlActionResult Get(string view)
		{
			return new HtmlActionResult(view);
		}
	}

	public class HtmlActionResult : IHttpActionResult
	{
		private readonly string viewDirectory = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
		private readonly string view;
		private readonly MediaTypeHeaderValue mediaTypeHeader;

		public HtmlActionResult(string viewName)
		{
			if (viewName.EndsWith(".css"))
				mediaTypeHeader = new MediaTypeHeaderValue("text/css");
			else
				mediaTypeHeader = new MediaTypeHeaderValue("text/html");

			view = LoadView(viewName);
		}

		public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			var response = new HttpResponseMessage(HttpStatusCode.OK);
			response.Content = new StringContent(view);
			response.Content.Headers.ContentType = mediaTypeHeader;

			return Task.FromResult(response);
		}

		private string LoadView(string name)
		{
			var view = File.ReadAllText(Path.Combine(viewDirectory, name));
			return view;
		}
	}
}