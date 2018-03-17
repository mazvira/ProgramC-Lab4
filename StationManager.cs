
using System;
using System.IO;

namespace Lab4
{
    static class StationManager
    {
        public static Person CurrentPerson { get; set; }
        internal static readonly string WorkingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lab4");
    }
}
