namespace TopoEditor.Output.Services
{
    using Microsoft.VisualStudio.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Resources;
    using TopoEditor.Infrastructure.Messaging;
    using TopoEditor.Infrastructure.Models;
    using TopoEditor.Output.Models;

    public class OutputWindowOptionsService : IOutputWindowOptionsService
    {
        //public OutputWindowOptionsService(ITextViewOptionsGroupService textViewOptionsGroupService, IContentTypeRegistryService contentTypeRegistryService)
        //{
        //    var group = textViewOptionsGroupService.GetGroup(PredefinedTextViewGroupNames.OutputWindow);
        //    group.TextViewOptionChanged += TextViewOptionsGroup_TextViewOptionChanged;
        //    Default = new OutputWindowOptions(group, contentTypeRegistryService.GetContentType(ContentTypes.Any));
        //}

        //public event EventHandler<OptionChangedEventArgs> OptionChanged;

        //public IOutputWindowOptions Default { get; }
        //Action<object, object> IOutputWindowOptionsService.OptionChanged { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //private void TextViewOptionsGroup_TextViewOptionChanged(object sender, TextViewOptionChangedEventArgs e) =>
        //    OptionChanged?.Invoke(this, new OptionChangedEventArgs(e.ContentType, e.OptionId));
    }
}