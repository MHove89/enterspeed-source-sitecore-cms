﻿using Enterspeed.Source.SitecoreCms.V10.Data.Models;

namespace Enterspeed.Source.SitecoreCms.V10.Handlers
{
    public interface IEnterspeedJobHandler
    {
        bool CanHandle(EnterspeedJob job);
        void Handle(EnterspeedJob job);
    }
}