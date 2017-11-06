using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditor.Output.Services
{
    public interface IOutputServiceSettings
    {
    }

    public class OutputServiceSettingsImpl : IOutputServiceSettings
    {
        public Guid SelectedGuid { get; internal set; }
    }
}