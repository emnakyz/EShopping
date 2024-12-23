using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypeResponse>>
{
	private readonly ITypesRepository _typesRepository;
	public GetAllTypesHandler(ITypesRepository typesRepository)
	{
		_typesRepository = typesRepository;
	}
	public async Task<IList<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
	{
		var typesList = await _typesRepository.GetAllTypes();
		var typesResponseList = ProductMapper.Mapper.Map<IList<TypeResponse>>(typesList);
		return typesResponseList;
	}
}
