using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TopoEditor.Output.ViewModels
{
    public class OutputBufferViewModel
    {
        public bool CanCopy { get; internal set; }
        public IInputElement FocusedElement { get; internal set; }
        public object TextEditorUIObject { get; internal set; }
        public int ZoomLevel { get; internal set; }
        public Guid Guid { get; internal set; }
        public string Name { get; internal set; }

        internal void Clear()
        {
            throw new NotImplementedException();
        }

        internal void Copy()
        {
            throw new NotImplementedException();
        }

        internal string GetText()
        {
            throw new NotImplementedException();
        }
    }
}