using System;
using System.Collections.Generic;
using TopoEditor.Infrastructure.Interfaces;
using TopoEditor.Infrastructure.Models;

namespace TopoEditor.Ribbon
{
    public interface IToolWindowProvider
    {
        /// <summary>
        /// Gets the tool windows it can create
        /// </summary>
        IEnumerable<ToolWindowInfo> ToolWindowInfos { get; }

        /// <summary>
        /// Creates a <see cref="IToolWindow"/> instance or returns a cached instance if it's already
        /// been created. Returns null if someone else should create it.
        /// </summary>
        /// <param name="guid">Guid, see <see cref="ToolWindowContent.Guid"/></param>
        /// <returns></returns>
		IToolWindow GetOrCreate(Guid guid);
    }
}