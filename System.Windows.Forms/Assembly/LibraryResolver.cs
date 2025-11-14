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

    public static readonly Dictionary<string, string> DllMap = new()
    {
        { "libX11", "libX11.so.6" },
        { "libXcursor", "libXcursor.so.1" },
        { "libglib-2.0", "libglib-2.0.so.0" },
        { "libgobject-2.0.so", "libgobject-2.0.so.0" },
        { "libgobject-2.0", "libgobject-2.0.so.0" },
        { "libgdk-x11-2.0.so", "libgdk-x11-2.0.so.0" },
        { "libgdk-x11-2.0", "libgdk-x11-2.0.so.0" },
        { "libgtk-x11-2.0.so", "libgtk-x11-2.0.so.0" },
        { "libgtk-x11-2.0", "libgtk-x11-2.0.so.0" },
        { "libgdk_pixbuf-2.0.so", "libgdk_pixbuf-2.0.so.0" },
        { "libgdk_pixbuf-2.0", "libgdk_pixbuf-2.0.so.0" },
        { "libXinerama", "libXinerama.so.1" },
        { "librsvg-2", "librsvg-2.so.2" },
        { "libXext", "libXext.so.6"}
    };

    private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (NativeLibrary.TryLoad(libraryName, assembly, searchPath, out var handle))
            return handle;
        if (DllMap.TryGetValue(libraryName, out var value))
        {
            if (NativeLibrary.TryLoad(value, assembly, searchPath, out handle))
                 return handle;
        }

        if (MonoLibraryResolver.UserDllImportResolver == null)
        {
            return IntPtr.Zero;
        }

        var result = MonoLibraryResolver.UserDllImportResolver(libraryName, assembly, searchPath);
        if (result != IntPtr.Zero)
        {
            return result;
        }
        return IntPtr.Zero;
    }

    internal static void EnsureRegistered()
    {

    }
}

public static class MonoLibraryResolver
{
    /// <summary>
    /// Provides a dictionary mapping library names to their actual file names for the  runtime.
    /// It's additinal names.
    /// It is used to resolve library names to their actual file names when loading native libraries.
    /// </summary>
    public static IDictionary<string, string> DllResolverMap => LibraryResolver.DllMap;

    public static DllImportResolver? UserDllImportResolver { get; set; }
}


