﻿using System.Collections.Generic;
using Enterspeed.Source.Sdk.Api.Models;
using Enterspeed.Source.Sdk.Api.Models.Properties;

namespace Enterspeed.Source.SitecoreCms.V10.Models
{
    public class SitecoreRenderingEntity : IEnterspeedEntity
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string[] Redirects { get; set; } = new string[0];
        public string ParentId { get; set; }
        public IDictionary<string, IEnterspeedProperty> Properties { get; set; }
    }
}