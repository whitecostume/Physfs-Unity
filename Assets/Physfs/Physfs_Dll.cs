using System.Runtime.InteropServices;


namespace PhysfsUnity
{

    public class Physfs_Dll
    {
#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        private const string DLL_NAME = "__Internal";
#else
        private const string DLL_NAME = "physfs";
#endif


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct PHYSFS_File
        {
            public System.IntPtr opaque;
        }

        [DllImport(DLL_NAME)]
        public static extern int PHYSFS_init(string args);

        /**
            return  non-zero if library is initialized, zero if library is not.
        */
        [DllImport(DLL_NAME)]
        public static extern int PHYSFS_isInit();

        [DllImport(DLL_NAME)]
        public static extern int PHYSFS_deinit();

        [DllImport(DLL_NAME)]
        public static extern int PHYSFS_mount(string newDir, string mountPoint, int appendToPath);

        [DllImport(DLL_NAME)]
        public static extern int PHYSFS_mountOffset(string newDir, string mountPoint, int appendToPath, ulong offset, long fileLength);

        [DllImport(DLL_NAME)]
        public static unsafe extern int PHYSFS_mountHandle(PHYSFS_File* file, string newDir, string mountPoint, int appendToPath);

        /// <summary>
        /// offset in bytes from start of file.
        /// </summary>
        /// <param name="handle">handle returned from PHYSFS_open*().</param>
        /// <returns>offset in bytes from start of file. -1 if error occurred.Use PHYSFS_getLastErrorCode() to obtain the specific error.</returns>
        [DllImport(DLL_NAME)]
        public static unsafe extern long PHYSFS_tell(PHYSFS_File* handle);


        [DllImport(DLL_NAME)]
        public unsafe static extern int PHYSFS_seek(PHYSFS_File* handle, ulong pos);

        [DllImport(DLL_NAME)]
        public static extern int PHYSFS_unmount(string dirPath);

        [DllImport(DLL_NAME)]
        public static extern int PHYSFS_getLastErrorCode();

        [DllImport(DLL_NAME)]
        public unsafe static extern PHYSFS_File* PHYSFS_openRead(string filepath);



        [DllImport(DLL_NAME)]
        public unsafe static extern int PHYSFS_close(PHYSFS_File* handle);


        [DllImport(DLL_NAME)]
        public unsafe static extern long PHYSFS_read(PHYSFS_File* handle, byte[] buffer, uint objSize, uint objCount);

        [DllImport(DLL_NAME)]
        public unsafe static extern long PHYSFS_readBytes(PHYSFS_File* handle, byte[] buffer, ulong len);

        [DllImport(DLL_NAME)]
        public unsafe static extern long PHYSFS_fileLength(PHYSFS_File* handle);

        [DllImport(DLL_NAME)]
        public unsafe static extern long PHYSFS_calRealFileOffset(string filename, out string filebuffer);
    }
}
