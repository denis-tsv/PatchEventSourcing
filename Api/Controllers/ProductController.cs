using Api.Dto;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPatch]
        public DomainEventDto[] Patch([FromBody] PatchProductDto dto)
        {
            var product = new Product(1, "name", "description");

            product.Patch(dto.Name, dto.Description);

            return product.Events.Select(x =>
            {
                if (x is NameChangedDomainEvent nameEvt) return new DomainEventDto { Value = nameEvt.Name, Name = nameof(NameChangedDomainEvent)};
                if (x is DescriptionChangedEvent descriptionEvt) return new DomainEventDto { Value = descriptionEvt.Description, Name = nameof(DescriptionChangedEvent) };
                throw new NotImplementedException();
            }).ToArray();
        }
    }
}