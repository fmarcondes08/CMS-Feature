using Abp.AutoMapper;
using FabricioAssignment.Authentication.External;

namespace FabricioAssignment.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
