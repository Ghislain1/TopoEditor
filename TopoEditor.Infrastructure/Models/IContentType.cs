using System.Collections.Generic;

namespace TopoEditor.Infrastructure.Models
{
    /// <summary>
    /// // C:\Users\Zoe\.nuget\packages\Microsoft.VisualStudio.CoreUtility\15.0.26201\lib\net45\Microsoft.VisualStudio.CoreUtility.dll
    /// </summary>
    public interface IContentType
    {
        // Summary: Gets the set of all content types from which the current
        // Microsoft.VisualStudio.Utilities.IContentType is derived.
        //
        // Returns: The set of all content types from which the current
        // Microsoft.VisualStudio.Utilities.IContentType is derived. This value is never null, though
        // it may be the empty set.
        IEnumerable<IContentType> BaseTypes { get; }

        // Summary: Gets the display name of the content type.
        //
        // Returns: The display name of the content type.
        string DisplayName { get; }

        // Summary: Gets the name of the content type.
        //
        // Returns: The name of the content type.
        string TypeName { get; }

        // Summary: Determines whether this content type has the specified base content type.
        //
        // Parameters: type: The name of the base content type.
        //
        // Returns: true if this content type derives from the one specified by type, otherwise false.
        bool IsOfType(string type);
    }
}