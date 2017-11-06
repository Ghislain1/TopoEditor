using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopoEditor.Infrastructure.Models;
using TopoEditor.Output.Models;

namespace TopoEditor.Output.Services
{
    public interface IOutputService
    {
        /// <summary>
        /// Creates a <see cref="IOutputTextPane"/>. Returns an existing one if it's already been created.
        /// </summary>
        /// <param name="guid">Guid of text pane</param>
        /// <param name="name">Name shown in the UI</param>
        /// <param name="contentType">Content type or null</param>
        /// <returns></returns>
        IOutputTextPane Create(Guid guid, string name, IContentType contentType = null);

        /// <summary>
        /// Creates a <see cref="IOutputTextPane"/>. Returns an existing one if it's already been created.
        /// </summary>
        /// <param name="guid">Guid of text pane</param>
        /// <param name="name">Name shown in the UI</param>
        /// <param name="contentType">Content type</param>
        /// <returns></returns>
        IOutputTextPane Create(Guid guid, string name, string contentType);

        /// <summary>
        /// Returns a <see cref="IOutputTextPane"/>
        /// </summary>
        /// <param name="guid">Guid of text pane</param>
        /// <returns></returns>
        IOutputTextPane GetTextPane(Guid guid);

        /// <summary>
        /// Selects a <see cref="IOutputTextPane"/>
        /// </summary>
        /// <param name="guid">Guid of text pane</param>
        void Select(Guid guid);
    }
}