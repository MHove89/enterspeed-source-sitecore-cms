using Enterspeed.Source.SitecoreCms.V10.Models.Configuration;
using Sitecore.Data.Items;

namespace Enterspeed.Source.SitecoreCms.V10.Services.Contracts
{
    public interface IEnterspeedUrlService
    {
        string GetItemUrl(Item item, EnterspeedSiteInfo siteInfo, bool enableLanguageEmbedding = false);

        string GetMediaUrl(MediaItem mediaItem, EnterspeedSiteInfo siteInfo);
    }
}