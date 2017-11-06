namespace TopoEditor.Infrastructure.Interfaces
{
    using Telerik.Windows.Controls.Docking;

    public interface IEditorOperationsFactoryService
    {
    }

    public interface ILogEditorProvider
    {
    }

    public interface IMenuService
    {
    }

    public interface IPaneModel
    {
        DockState Position { get; }
    }

    public interface IPickSaveFilename
    {
        string GetFilename(string v1, string v2, string tEXTFILES_FILTER);
    }

    public interface IToolWindow
    {
    }
}