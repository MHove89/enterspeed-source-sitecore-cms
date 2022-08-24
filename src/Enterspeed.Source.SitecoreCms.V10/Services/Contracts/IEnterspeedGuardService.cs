using Sitecore.Data.Items;

namespace Enterspeed.Source.SitecoreCms.V10.Services.Contracts
{
    public interface IEnterspeedGuardService
    {
        bool CanIngest(Item item, string culture);
    }
}