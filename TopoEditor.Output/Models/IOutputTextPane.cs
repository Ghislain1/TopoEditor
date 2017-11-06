using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopoEditor.Infrastructure.Models;

namespace TopoEditor.Output.Models
{
    public interface IOutputTextPane
    {
    }

    public interface IOutputWindowOptions
    {
        bool BraceMatching { get; set; }

        // BlockStructureLineKind BlockStructureLineKind { get; set; }
        bool CompressEmptyOrWhitespaceLines { get; set; }

        bool CompressNonLetterLines { get; set; }
        IContentType ContentType { get; }
        bool ConvertTabsToSpaces { get; set; }
        bool CutOrCopyBlankLineIfNoSelection { get; set; }
        bool DisplayUrlsAsHyperlinks { get; set; }
        bool EnableHighlightCurrentLine { get; set; }
        bool EnableMouseWheelZoom { get; set; }
        bool ForceClearTypeIfNeeded { get; set; }
        bool GlyphMargin { get; set; }
        bool HighlightRelatedKeywords { get; set; }
        bool HorizontalScrollBar { get; set; }
        int IndentSize { get; set; }
        bool LineNumberMargin { get; set; }
        bool LineSeparators { get; set; }
        bool ReferenceHighlighting { get; set; }
        bool RemoveExtraTextLineVerticalPixels { get; set; }
        bool SelectionMargin { get; set; }
        bool ShowBlockStructure { get; set; }
        bool ShowTimestamps { get; set; }
        int TabSize { get; set; }
        bool UseVirtualSpace { get; set; }
        bool VerticalScrollBar { get; set; }
        WordWrapStyles WordWrapStyle { get; set; }
        bool ZoomControl { get; set; }
        double ZoomLevel { get; set; }
    }
}