using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Windows.Forms;

internal class LibraryResolver
{
    static LibraryResolver()
    {
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
    }
    
    private static readonly Dictionary<string, string> DllMap = new()
    {
        { "libX11", "libX11.so.6" },
        { "libXcursor", "libXcursor.so.1" },
        { "libglib-2.0.so", "libglib-2.0.so.0" },
        { "libgobject-2.0.so", "libgobject-2.0.so.0" },
        { "libgobject-2.0", "libgobject-2.0.so.0" },
        { "libgdk-x11-2.0.so", "libgdk-x11-2.0.so.0" },
        { "libgdk-x11-2.0", "libgdk-x11-2.0.so.0" },
        { "libgtk-x11-2.0.so", "libgtk-x11-2.0.so.0" },
        { "libgtk-x11-2.0", "libgtk-x11-2.0.so.0" },
        { "libgdk_pixbuf-2.0.so", "libgdk_pixbuf-2.0.so.0" },
        { "libgdk_pixbuf-2.0", "libgdk_pixbuf-2.0.so.0" }
    };

    private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (NativeLibrary.TryLoad(libraryName, assembly, searchPath, out var handle))
            return handle;
        if (DllMap.TryGetValue(libraryName, out var value))
            return NativeLibrary.TryLoad(value, assembly, searchPath, out handle) ? handle : IntPtr.Zero;
        return IntPtr.Zero;
    }

    internal static void EnsureRegistered()
    {
        
    }
}
