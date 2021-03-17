﻿using System;
using Sitecore.Data.Items;
using Sitecore.Globalization;

namespace Enterspeed.Source.SitecoreCms.V9.Services
{
    public interface IContentIdentityService
    {
        string GetId(Item item);
        string GetId(Guid itemId, Language language);
    }
}