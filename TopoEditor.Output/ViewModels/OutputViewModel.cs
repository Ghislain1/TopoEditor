namespace TopoEditor.Output.ViewModels
{
    using Microsoft.Practices.Unity;
    using Prism.Commands;
    using Prism.Mvvm;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using TopoEditor.Infrastructure.Interfaces;
    using TopoEditor.Infrastructure.Models;
    using TopoEditor.Output.Models;
    using TopoEditor.Output.Services;

    public class OutputViewModel : BindableBase, IOutputViewModel
    {
        private static readonly string TEXTFILES_FILTER = string.Format("{1} (*.txt)|*.txt|{0} (*.*)|*.*", "dnSpy_Resources.AllFiles", "dnSpy_Resources.TextFiles");
        private readonly IUnityContainer container;
        private readonly IEditorOperationsFactoryService editorOperationsFactoryService;
        private readonly ILogEditorProvider logEditorProvider;
        private readonly IMenuService menuService;
        private readonly ObservableCollection<OutputBufferViewModel> outputBuffers;
        private readonly IOutputServiceListener outputServiceListeners;
        private readonly OutputServiceSettingsImpl outputServiceSettingsImpl;
        private readonly IOutputWindowOptionsService outputWindowOptionsService;
        private readonly IPickSaveFilename pickSaveFilename;
        private Guid prevSelectedGuid;
        private OutputBufferViewModel selectedOutputBufferVM;

        public OutputViewModel(OutputServiceSettingsImpl outputServiceSettingsImpl, IUnityContainer container)
        {
            this.container = container;
            // this.outputWindowOptionsService =
            // this.container.Resolve<IOutputWindowOptionsService>();
            // outputWindowOptionsService.OptionChanged += OutputWindowOptionsService_OptionChanged;
            // this.editorOperationsFactoryService =
            // this.container.Resolve<IEditorOperationsFactoryService>(); this.logEditorProvider =
            // this.container.Resolve<ILogEditorProvider>(); this.outputServiceSettingsImpl =
            // outputServiceSettingsImpl; prevSelectedGuid = outputServiceSettingsImpl.SelectedGuid;
            this.pickSaveFilename = this.container.Resolve<IPickSaveFilename>();
            this.menuService = this.container.Resolve<IMenuService>();
            outputBuffers = new ObservableCollection<OutputBufferViewModel>();
            outputBuffers.CollectionChanged += OutputBuffers_CollectionChanged;
            outputServiceListeners = this.container.Resolve<IOutputServiceListener>();

            // var listeners = outputServiceListeners.OrderBy(a => a.Metadata.Order).ToArray();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Send, new Action(() =>
            {
                //foreach (var lazy in outputServiceListeners)
                //{
                //    //var l = lazy.Value;
                //    //(l as IOutputServiceListener2)?.Initialize(this);
                //}
            }));
        }

        public bool CanClearAll => SelectedOutputBufferVM != null;
        public bool CanCopy => SelectedOutputBufferVM?.CanCopy == true;
        public bool CanSaveText => SelectedOutputBufferVM != null;
        public ICommand ClearAllCommand => new DelegateCommand(() => ClearAll(), () => CanClearAll);
        public IInputElement FocusedElement => SelectedOutputBufferVM?.FocusedElement;
        public bool HasOutputWindows => SelectedOutputBufferVM != null;
        public ObservableCollection<OutputBufferViewModel> OutputBuffers => outputBuffers;
        public ICommand SaveCommand => new DelegateCommand(() => SaveText(), () => CanSaveText);

        //public string ClearAllToolTip => ToolTipHelper.AddKeyboardShortcut(dnSpy_Resources.Output_ClearAll_ToolTip, dnSpy_Resources.ShortCutKeyCtrlL);
        //public string SaveToolTip => ToolTipHelper.AddKeyboardShortcut(dnSpy_Resources.Output_Save_ToolTip, dnSpy_Resources.ShortCutKeyCtrlS);
        //public string WordWrapToolTip => ToolTipHelper.AddKeyboardShortcut(dnSpy_Resources.Output_WordWrap_ToolTip, dnSpy_Resources.ShortCutKeyCtrlECtrlW);

        public OutputBufferViewModel SelectedOutputBufferVM
        {
            get { return selectedOutputBufferVM; }
            set
            {
                if (selectedOutputBufferVM != value)
                {
                    selectedOutputBufferVM = value;
                    // outputServiceSettingsImpl.SelectedGuid = value?.Guid ?? Guid.Empty;
                    OnPropertyChanged(nameof(SelectedOutputBufferVM));
                    OnPropertyChanged(nameof(TextEditorUIObject));
                    OnPropertyChanged(nameof(FocusedElement));
                    OnPropertyChanged(nameof(HasOutputWindows));
                }
            }
        }

        public bool ShowLineNumbers
        {
            get { return outputWindowOptionsService.Default.LineNumberMargin; }
            set { outputWindowOptionsService.Default.LineNumberMargin = value; }
        }

        public bool ShowTimestamps
        {
            get { return outputWindowOptionsService.Default.ShowTimestamps; }
            set { outputWindowOptionsService.Default.ShowTimestamps = value; }
        }

        public object TextEditorUIObject => SelectedOutputBufferVM?.TextEditorUIObject;

        public bool WordWrap
        {
            get
            {
                return (outputWindowOptionsService.Default.WordWrapStyle & WordWrapStyles.WordWrap) != 0;
            }
            set
            {
                if (WordWrap != value)
                {
                    if (value)
                        outputWindowOptionsService.Default.WordWrapStyle |= WordWrapStyles.WordWrap;
                    else
                        outputWindowOptionsService.Default.WordWrapStyle &= ~WordWrapStyles.WordWrap;
                }
            }
        }

        public double ZoomLevel => SelectedOutputBufferVM?.ZoomLevel ?? 100;

        public bool CanSelectLog(int index) => (uint)index < (uint)OutputBuffers.Count;

        public void ClearAll()
        {
            if (!CanClearAll)
                return;
            SelectedOutputBufferVM?.Clear();
        }

        public void Copy() => SelectedOutputBufferVM?.Copy();

        //public IOutputTextPane Create(Guid guid, string name, string contentType) =>
        //    Create(guid, name, (object)contentType);

        //public IOutputTextPane Create(Guid guid, string name, IContentType contentType) =>
        //    Create(guid, name, (object)contentType);

        //public IOutputTextPane Find(Guid guid) => OutputBuffers.FirstOrDefault(a => a.Guid == guid);

        //public IOutputTextPane GetTextPane(Guid guid) => Find(guid) ?? new NotPresentOutputWriter(this, guid);

        public void SaveText()
        {
            if (!CanSaveText)
                return;
            var vm = SelectedOutputBufferVM;
            var filename = pickSaveFilename.GetFilename(GetFilename(vm), "txt", TEXTFILES_FILTER);
            if (filename == null)
                return;
            try
            {
                File.WriteAllText(filename, vm.GetText(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                // MsgBox.Instance.Show(ex);
            }
        }

        public void Select(Guid guid)
        {
            var vm = OutputBuffers.FirstOrDefault(a => a.Guid == guid);
            Debug.Assert(vm != null);
            if (vm != null)
                SelectedOutputBufferVM = vm;
        }

        public OutputBufferViewModel SelectLog(int index)
        {
            if (!CanSelectLog(index))
                return null;
            SelectedOutputBufferVM = OutputBuffers[index];
            return SelectedOutputBufferVM;
        }

        //private IOutputTextPane Create(Guid guid, string name, object contentTypeObj)
        //{
        //    if (name == null)
        //        throw new ArgumentNullException(nameof(name));

        // var vm = OutputBuffers.FirstOrDefault(a => a.Guid == guid); Debug.Assert(vm == null ||
        // vm.Name == name); if (vm != null) return vm;

        // var logEditorOptions = new LogEditorOptions { MenuGuid = new
        // Guid(MenuConstants.GUIDOBJ_LOG_TEXTEDITORCONTROL_GUID), ContentType = contentTypeObj as
        // IContentType, ContentTypeString = contentTypeObj as string, CreateGuidObjects = args =>
        // CreateGuidObjects(args), };
        // logEditorOptions.ExtraRoles.Add(PredefinedDsTextViewRoles.OutputTextPane); var logEditor =
        // logEditorProvider.Create(logEditorOptions);
        // logEditor.TextView.Options.SetOptionValue(DefaultWpfViewOptions.AppearanceCategory, AppearanceCategoryConstants.OutputWindow);

        // // Prevent toolwindow's ctx menu from showing up when right-clicking in the left margin
        // menuService.InitializeContextMenu(logEditor.TextViewHost.HostControl, Guid.NewGuid());

        // vm = new OutputBufferVM(editorOperationsFactoryService, guid, name, logEditor); int index
        // = GetSortedInsertIndex(vm); OutputBuffers.Insert(index, vm); while (index <
        // OutputBuffers.Count) OutputBuffers[index].Index = index++;

        //    OutputTextPaneUtils.AddInstance(vm, logEditor.TextView);
        //    return vm;
        //}

        //private IEnumerable<GuidObject> CreateGuidObjects(GuidObjectsProviderArgs args)
        //{
        //    yield return new GuidObject(MenuConstants.GUIDOBJ_OUTPUT_SERVICE_GUID, this);
        //    if (SelectedOutputBufferVM is IOutputTextPane vm)
        //        yield return new GuidObject(MenuConstants.GUIDOBJ_ACTIVE_OUTPUT_TEXTPANE_GUID, vm);
        //}

        private string GetFilename(OutputBufferViewModel vm)
        {
            // Same as VS2015
            var s = vm.Name.Replace(" ", string.Empty);
            return " dnSpy_Resources.Window_Output" + " - " + s + ".txt";
        }

        private int GetSortedInsertIndex(OutputBufferViewModel vm)
        {
            for (int i = 0; i < OutputBuffers.Count; i++)
            {
                if (StringComparer.InvariantCultureIgnoreCase.Compare(vm.Name, OutputBuffers[i].Name) < 0)
                    return i;
            }
            return OutputBuffers.Count;
        }

        private void OutputBuffers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (SelectedOutputBufferVM == null)
                SelectedOutputBufferVM = OutputBuffers.FirstOrDefault();

            if (e.NewItems != null)
            {
                foreach (OutputBufferViewModel vm in e.NewItems)
                {
                    if (vm.Guid == prevSelectedGuid && prevSelectedGuid != Guid.Empty)
                    {
                        SelectedOutputBufferVM = vm;
                        prevSelectedGuid = Guid.Empty;
                        break;
                    }
                }
            }
        }

        private void OutputWindowOptionsService_OptionChanged(object sender, object e)
        {
            //if (e.OptionId == DefaultTextViewOptions.WordWrapStyleName)
            //    OnPropertyChanged(nameof(WordWrap));
        }
    }
}