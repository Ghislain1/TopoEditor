namespace TopoEditor.Output.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public interface IOutputViewModel
    {
        bool CanClearAll { get; }
        bool CanCopy { get; }
        bool CanSaveText { get; }
        IInputElement FocusedElement { get; }
        OutputBufferViewModel SelectedOutputBufferVM { get; }

        bool ShowLineNumbers { get; set; }

        bool ShowTimestamps { get; set; }

        bool WordWrap { get; set; }

        double ZoomLevel { get; }

        bool CanSelectLog(int index);

        void ClearAll();

        void Copy();

        void SaveText();

        OutputBufferViewModel SelectLog(int index);
    }
}