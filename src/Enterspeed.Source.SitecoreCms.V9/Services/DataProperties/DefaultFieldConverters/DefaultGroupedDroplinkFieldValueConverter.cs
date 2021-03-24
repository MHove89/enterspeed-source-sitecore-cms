﻿using System;
using System.Collections.Generic;
using Enterspeed.Source.Sdk.Api.Models.Properties;
using Enterspeed.Source.SitecoreCms.V9.Models.Configuration;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Enterspeed.Source.SitecoreCms.V9.Services.DataProperties.DefaultFieldConverters
{
    public class DefaultGroupedDroplinkFieldValueConverter : IEnterspeedFieldValueConverter
    {
        private readonly IEnterspeedIdentityService _enterspeedIdentityService;

        public DefaultGroupedDroplinkFieldValueConverter(
            IEnterspeedIdentityService enterspeedIdentityService)
        {
            _enterspeedIdentityService = enterspeedIdentityService;
        }

        public bool CanConvert(Field field)
        {
            return field != null && field.TypeKey.Equals("grouped droplink", StringComparison.OrdinalIgnoreCase);
        }

        public IEnterspeedProperty Convert(Item item, Field field, EnterspeedSiteInfo siteInfo, List<IEnterspeedFieldValueConverter> fieldValueConverters)
        {
            ReferenceField referenceField = field;
            if (referenceField?.TargetItem == null)
            {
                return null;
            }

            return new StringEnterspeedProperty(field.Name, _enterspeedIdentityService.GetId(referenceField.TargetItem));
        }
    }
}