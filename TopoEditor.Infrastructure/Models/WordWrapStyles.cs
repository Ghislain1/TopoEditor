using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditor.Infrastructure.Models
{
    /// <summary>
    /// // C:\Users\Zoe\.nuget\packages\Microsoft.VisualStudio.Text.UI\15.0.26201\lib\net45\Microsoft.VisualStudio.Text.UI.dll
    /// </summary>
    [Flags]
    public enum WordWrapStyles
    {
        // Summary: Word wrap is disabled.
        None = 0,

        // Summary: Word wrap is enabled.
        WordWrap = 1,

        // Summary: If word wrap is enabled, use visible glyphs.
        VisibleGlyphs = 2,

        // Summary: If word wrap is enabled, use auto-indent.
        AutoIndent = 4
    }
}