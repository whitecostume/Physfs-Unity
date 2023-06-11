using System.Runtime.InteropServices;


namespace PhysfsUnity
{

    public class Physfs_Dll
    {
        

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct PHYSFS_File
        {
            public System.IntPtr opaque;
        }

#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public static extern int PHYSFS_init(string args);

#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public static extern int PHYSFS_deinit();

        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDir"></param>
        /// <param name="mountPoint"></param>
        /// <param name="appendToPath"></param>
        /// <returns>nonzero if added to path, zero on failure (bogus archive, dir
        /// *missing, etc). Use PHYSFS_getLastErrorCode() to obtain
        ///*the specific error.</returns>
#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public static extern int PHYSFS_mount(string newDir, string mountPoint, int appendToPath);

#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public static unsafe extern int PHYSFS_mountHandle(PHYSFS_File* file, string newDir, string mountPoint, int appendToPath);
        

        /// <summary>
        /// offset in bytes from start of file.
        /// </summary>
        /// <param name="handle">handle returned from PHYSFS_open*().</param>
        /// <returns>offset in bytes from start of file. -1 if error occurred.Use PHYSFS_getLastErrorCode() to obtain the specific error.</returns>
#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public static unsafe extern long  PHYSFS_tell(PHYSFS_File* handle);
        
        
#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public unsafe static extern int PHYSFS_seek(PHYSFS_File* handle,ulong pos);


#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
            [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public static extern int PHYSFS_unmount(string dirPath);

#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public static extern int PHYSFS_getLastErrorCode();

#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public unsafe static extern PHYSFS_File* PHYSFS_openRead(string filepath);

        

#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public unsafe static extern int PHYSFS_close(PHYSFS_File* handle);


#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public unsafe static extern long PHYSFS_read(PHYSFS_File* handle, byte[] buffer, uint objSize, uint objCount);

#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public unsafe static extern long PHYSFS_readBytes(PHYSFS_File* handle, byte[] buffer, ulong len);

#if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
            [DllImport ("__Internal")]
#else
        [DllImport("physfs")]
#endif
        public unsafe static extern long PHYSFS_fileLength(PHYSFS_File* handle);
    }
}
