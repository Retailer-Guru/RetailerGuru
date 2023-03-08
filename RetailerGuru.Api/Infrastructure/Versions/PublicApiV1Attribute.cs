using Microsoft.AspNetCore.Mvc;

namespace BillCreator.Api.Infrastructure.Versions
{
    public sealed class PublicApiV1Attribute : ApiVersionAttribute
    {
        public PublicApiV1Attribute() : base(new ApiVersion(1, 0, "public"))
        {

        }
    }
}
