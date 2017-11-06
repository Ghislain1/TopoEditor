using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopoEditor.Output.Services
{
    public interface ITextViewOptionsGroupService
    {
        /// <summary>
        /// Gets a group
        /// </summary>
        /// <param name="name">Group name, eg. <see cref="PredefinedTextViewGroupNames.CodeEditor"/></param>
        /// <returns></returns>
        ITextViewOptionsGroup GetGroup(string name);
    }
}