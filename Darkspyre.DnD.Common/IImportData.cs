using Darkspyre.DnD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Darkspyre.DnD.Interface
{
    public interface IImportData
    {
        Task<DataLibrary> ImportFile(FGDataType dataType, string dbPath, string definitionPath);
    }

    public enum FGDataType
    {
        Campaign,
        Module,        
        Extension,
    }
}
