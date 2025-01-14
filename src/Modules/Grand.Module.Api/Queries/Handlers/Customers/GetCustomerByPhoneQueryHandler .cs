using Grand.Module.Api.DTOs.Customers;
using Grand.Module.Api.Extensions;
using Grand.Module.Api.Queries.Models.Customers;
using Grand.Business.Core.Interfaces.Customers;
using MediatR;
using Grand.Domain.Customers;

namespace Grand.Module.Api.Queries.Handlers.Customers;

public class GetCustomerByPhoneQueryHandler : IRequestHandler<GetCustomerByPhoneQuery, CustomerDto>
{
    private readonly ICustomerService _customerService;

    public GetCustomerByPhoneQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<CustomerDto> Handle(GetCustomerByPhoneQuery request, CancellationToken cancellationToken)
    {
       
        return (await _customerService.GetCustomerByPhone(request.Phone)).ToModel();
    }
}