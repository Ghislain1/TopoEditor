using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditor.Infrastructure.Interfaces
{
    public interface ITextViewOptionsGroup
    {
        /// <summary>
        /// Raised when an option has changed
        /// </summary>
        event EventHandler<TextViewOptionChangedEventArgs> TextViewOptionChanged;

        /// <summary>
        /// Gets all text views in this group
        /// </summary>
        IEnumerable<IWpfTextView> TextViews { get; }

        /// <summary>
        /// Gets the current value
        /// </summary>
        /// <param name="contentType">Content type, eg. <see cref="ContentTypes.CSharpRoslyn"/></param>
        /// <param name="optionId">Option name</param>
        /// <returns></returns>
        object GetOptionValue(string contentType, string optionId);

        /// <summary>
        /// Gets the current value
        /// </summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="contentType">Content type, eg. <see cref="ContentTypes.CSharpRoslyn"/></param>
        /// <param name="option">Option</param>
        /// <returns></returns>
        T GetOptionValue<T>(string contentType, EditorOptionKey<T> option);

        /// <summary>
        /// Returns true if the option is shared by all text views in this group
        /// </summary>
        /// <param name="contentType">Content type, eg. <see cref="ContentTypes.CSharpRoslyn"/></param>
        /// <param name="optionId">Option name</param>
        /// <returns></returns>
        bool HasOption(string contentType, string optionId);

        /// <summary>
        /// Returns true if the option is shared by all text views in this group
        /// </summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="contentType">Content type, eg. <see cref="ContentTypes.CSharpRoslyn"/></param>
        /// <param name="option">Option</param>
        /// <returns></returns>
        bool HasOption<T>(string contentType, EditorOptionKey<T> option);

        /// <summary>
        /// Writes a new value
        /// </summary>
        /// <param name="contentType">Content type, eg. <see cref="ContentTypes.CSharpRoslyn"/></param>
        /// <param name="optionId">Option name</param>
        /// <param name="value">New value</param>
        void SetOptionValue(string contentType, string optionId, object value);

        /// <summary>
        /// Writes a new value
        /// </summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="contentType">Content type, eg. <see cref="ContentTypes.CSharpRoslyn"/></param>
        /// <param name="option">Option</param>
        /// <param name="value">New value</param>
        void SetOptionValue<T>(string contentType, EditorOptionKey<T> option, T value);
    }
}