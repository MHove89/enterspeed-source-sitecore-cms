﻿using System;
using Enterspeed.Source.Sdk.Api.Models.Properties;
using Enterspeed.Source.SitecoreCms.V9.Models.Configuration;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace Enterspeed.Source.SitecoreCms.V9.Services.DataProperties.DefaultFieldConverters
{
    public class DefaultSingleLineTextFieldValueConverter : IEnterspeedFieldValueConverter
    {
        public bool CanConvert(Field field)
        {
            return field != null &&
                (field.TypeKey.Equals("text", StringComparison.OrdinalIgnoreCase) ||
                    field.TypeKey.Equals("single-line text", StringComparison.OrdinalIgnoreCase));
        }

        public IEnterspeedProperty Convert(Item item, Field field, EnterspeedSiteInfo siteInfo)
        {
            string value = FieldRenderer.Render(item, field.Name);

            return new StringEnterspeedProperty(field.Name, value);
        }
    }
}