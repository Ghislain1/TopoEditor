using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditor.Infrastructure.Messaging
{
    public class MarketPricesUpdatedEvent : PubSubEvent<IDictionary<string, decimal>>
    {
    }

    /// <summary>
    /// Text view option changed event args
    /// </summary>
    public sealed class TextViewOptionChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="contentType">Content type</param>
        /// <param name="optionId">Option id, eg. <see cref="DefaultTextViewOptions.WordWrapStyleName"/></param>
        public TextViewOptionChangedEventArgs(string contentType, string optionId)
        {
            ContentType = contentType ?? throw new ArgumentNullException(nameof(contentType));
            OptionId = optionId ?? throw new ArgumentNullException(nameof(optionId));
        }

        /// <summary>
        /// Content type
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// Option id, eg. <see cref="DefaultTextViewOptions.WordWrapStyleName"/>
        /// </summary>
        public string OptionId { get; }
    }
}