using Grand.Module.Api.DTOs.Customers;
using MediatR;

namespace Grand.Module.Api.Queries.Models.Customers;

public class GetCustomerByPhoneQuery : IRequest<CustomerDto>
{
    public string Phone { get; set; }
}