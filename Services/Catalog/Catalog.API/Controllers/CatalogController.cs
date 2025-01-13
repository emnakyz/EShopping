using Catalog.Application.Commands;
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

		[HttpGet]
		[Route("[action]/{productName}", Name = "GetProductByProductName")]
		[ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IList<ProductResponse>>> GetProductByProductName(string productName)
		{
			var query = new GetProductByNameQuery(productName);
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet]
		[Route("GetAllProducts")]
		[ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts()
		{
			var query = new GetAllProductsQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet]
		[Route("GetAllBrands")]
		[ProducesResponseType(typeof(IList<BrandResponse>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IList<BrandResponse>>> GetAllBrands()
		{
			var query = new GetAllBrandsQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet]
		[Route("GetAllTypes")]
		[ProducesResponseType(typeof(IList<TypeResponse>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IList<TypeResponse>>> GetAllTypes()
		{
			var query = new GetAllTypesQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet]
		[Route("[action]/{brand}", Name = "GetProductsByBrandName")]
		[ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<IList<ProductResponse>>> GetProductsByBrandName(string brand)
		{
			var query = new GetProductByBrandQuery(brand);
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpPost]
		[Route("CreateProduct")]
		[ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
		public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand createProductCommand)
		{
			var result = await _mediator.Send(createProductCommand);
			return Ok(result);
		}

		[HttpPut]
		[Route("UpdateProduct")]
		[ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
		{
			var result = await _mediator.Send(updateProductCommand);
			return Ok(result);
		}

		[HttpDelete]
		[Route("{id}", Name = "DeleteProduct")]
		[ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			var query = new DeleteProductByIdQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
