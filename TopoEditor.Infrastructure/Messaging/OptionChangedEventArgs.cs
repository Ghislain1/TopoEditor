using System;

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