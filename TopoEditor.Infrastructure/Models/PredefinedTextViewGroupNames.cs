using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditor.Infrastructure.Models
{
    /// <summary>
    /// Text view group names
    /// </summary>
    public static class PredefinedTextViewGroupNames
    {
        /// <summary>
        /// Code editor group
        /// </summary>
        public const string CodeEditor = nameof(CodeEditor);

        /// <summary>
        /// Text viewer group
        /// </summary>
        public const string DocumentViewer = nameof(DocumentViewer);

        /// <summary>
        /// Output window group
        /// </summary>
        public const string OutputWindow = nameof(OutputWindow);

        /// <summary>
        /// REPL group
        /// </summary>
        public const string REPL = nameof(REPL);
    }
}