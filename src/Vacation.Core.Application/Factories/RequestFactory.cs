using Vacation.Core.Application.Dto;
using Vacation.Core.Application.Dto.Requests;
using Vacation.Core.Domain.Entities;

namespace Vacation.Core.Application.Factories;

public class RequestFactory
{
    public static Domain.Entities.Vacation CreateRequest(CreateVacationRequestDto dto)
    {
        return new Domain.Entities.Vacation();
    }
}