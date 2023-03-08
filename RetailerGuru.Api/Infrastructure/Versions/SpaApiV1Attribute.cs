using Microsoft.AspNetCore.Mvc;

namespace BillCreator.Api.Infrastructure.Versions
{
    public sealed class SpaApiV1Attribute : ApiVersionAttribute
    {
        public SpaApiV1Attribute() : base(new ApiVersion(1, 0, "spa"))
        {

        }
    }
}
