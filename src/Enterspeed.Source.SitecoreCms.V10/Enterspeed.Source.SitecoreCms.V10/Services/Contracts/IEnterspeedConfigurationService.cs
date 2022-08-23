using System.Collections.Generic;
using Enterspeed.Source.SitecoreCms.V10.Models.Configuration;

namespace Enterspeed.Source.SitecoreCms.V10.Services.Contracts
{
    public interface IEnterspeedConfigurationService
    {
        List<EnterspeedSitecoreConfiguration> GetConfigurations();
    }
}