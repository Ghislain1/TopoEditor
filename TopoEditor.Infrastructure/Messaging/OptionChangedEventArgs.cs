using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditor.Infrastructure.Messaging
{
    public sealed class OptionChangedEventArgs : EventArgs
    {
        public OptionChangedEventArgs(string contentType, string optionId)
        {
            ContentType = contentType ?? throw new ArgumentNullException(nameof(contentType));
            OptionId = optionId ?? throw new ArgumentNullException(nameof(optionId));
        }

        /// <summary>
        /// Content type
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// Option id, eg. <see cref="Microsoft.VisualStudio.Text.Editor.DefaultTextViewOptions.WordWrapStyleName"/>
        /// </summary>
        public string OptionId { get; }
    }
}