using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTableExt;

namespace DrinksInfo;

internal class ConsoleVisualEngine
{
    public void ShowTable<T>(List<T> list, string title) where T : class
    {
        ConsoleTableBuilder
                 .From(list)
                 .WithColumn(title)
                 .WithFormat(ConsoleTableBuilderFormat.Alternative)
                 .ExportAndWriteLine(TableAligntment.Center);
    }
}
