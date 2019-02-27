﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RoastedMarketplace.Infrastructure.ViewEngines
{
    public interface IViewAccountant
    {
        string GetThemeViewPath(string viewName);

        IList<string> GetSearchLocations();

        string RenderView(ViewContext viewContext);

        string RenderView(string viewName, string originalViewPath, string area, object parameters = null);

        CachedView GetView(string viewName, string requestedPath, string area, object parameters = null);

        string GetLayoutPath(string layoutName);

        Dictionary<string, object> GetCompiledViews(bool splitted = false, string area = null);

        Dictionary<string, object> CompileAllViews(string controller = null, string area = null, bool splitted = false);
    }
}