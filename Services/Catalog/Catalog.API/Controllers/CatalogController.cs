using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{

	public class CatalogController : ApiController
	{
		private readonly IMediator _mediator;
		public CatalogController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		[Route("[action]/{id}", Name = "GetProductById")]
		[ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<ProductResponse>> GetProductById(string id)
		{
			var query = new GetProductByIdQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
