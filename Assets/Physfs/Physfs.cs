using System.Runtime.InteropServices;
using UnityEngine;

public class Physfs
{   
    public enum PHYSFS_ErrorCode
    {
        PHYSFS_ERR_OK,               /**< Success; no error.                    */
        PHYSFS_ERR_OTHER_ERROR,      /**< Error not otherwise covered here.     */
        PHYSFS_ERR_OUT_OF_MEMORY,    /**< Memory allocation failed.             */
        PHYSFS_ERR_NOT_INITIALIZED,  /**< PhysicsFS is not initialized.         */
        PHYSFS_ERR_IS_INITIALIZED,   /**< PhysicsFS is already initialized.     */
        PHYSFS_ERR_ARGV0_IS_NULL,    /**< Needed argv[0], but it is NULL.       */
        PHYSFS_ERR_UNSUPPORTED,      /**< Operation or feature unsupported.     */
        PHYSFS_ERR_PAST_EOF,         /**< Attempted to access past end of file. */
        PHYSFS_ERR_FILES_STILL_OPEN, /**< Files still open.                     */
        PHYSFS_ERR_INVALID_ARGUMENT, /**< Bad parameter passed to an function.  */
        PHYSFS_ERR_NOT_MOUNTED,      /**< Requested archive/dir not mounted.    */
        PHYSFS_ERR_NOT_FOUND,        /**< File (or whatever) not found.         */
        PHYSFS_ERR_SYMLINK_FORBIDDEN,/**< Symlink seen when not permitted.      */
        PHYSFS_ERR_NO_WRITE_DIR,     /**< No write dir has been specified.      */
        PHYSFS_ERR_OPEN_FOR_READING, /**< Wrote to a file opened for reading.   */
        PHYSFS_ERR_OPEN_FOR_WRITING, /**< Read from a file opened for writing.  */
        PHYSFS_ERR_NOT_A_FILE,       /**< Needed a file, got a directory (etc). */
        PHYSFS_ERR_READ_ONLY,        /**< Wrote to a read-only filesystem.      */
        PHYSFS_ERR_CORRUPT,          /**< Corrupted data encountered.           */
        PHYSFS_ERR_SYMLINK_LOOP,     /**< Infinite symbolic link loop.          */
        PHYSFS_ERR_IO,               /**< i/o error (hardware failure, etc).    */
        PHYSFS_ERR_PERMISSION,       /**< Permission denied.                    */
        PHYSFS_ERR_NO_SPACE,         /**< No space (disk full, over quota, etc) */
        PHYSFS_ERR_BAD_FILENAME,     /**< Filename is bogus/insecure.           */
        PHYSFS_ERR_BUSY,             /**< Tried to modify a file the OS needs.  */
        PHYSFS_ERR_DIR_NOT_EMPTY,    /**< Tried to delete dir with files in it. */
        PHYSFS_ERR_OS_ERROR,         /**< Unspecified OS-level error.           */
        PHYSFS_ERR_DUPLICATE,        /**< Duplicate entry.                      */
        PHYSFS_ERR_BAD_PASSWORD,     /**< Bad password.                         */
        PHYSFS_ERR_APP_CALLBACK      /**< Application callback reported error.  */
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct PHYSFS_File 
    {
        public System.IntPtr opaque;
    }

    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public static extern int PHYSFS_init(string args);

    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public static extern int PHYSFS_deinit();


    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public static extern int PHYSFS_mount(string newDir, string mountPoint, int appendToPath);

    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public static unsafe extern int PHYSFS_mountHandle(PHYSFS_File *file,string newDir, string mountPoint, int appendToPath);
    
    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public static extern int PHYSFS_unmount(string dirPath);

    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public static extern int PHYSFS_getLastErrorCode();

    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public unsafe static extern PHYSFS_File* PHYSFS_openRead(string filepath);
    
    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public unsafe static extern int PHYSFS_close(PHYSFS_File* handle);


    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public unsafe static extern long PHYSFS_read(PHYSFS_File* handle, byte[] buffer,uint objSize,uint objCount);

    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public unsafe static extern long PHYSFS_readBytes(PHYSFS_File* handle, byte[] buffer, ulong len);

    #if (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
        [DllImport ("__Internal")]
    #else
        [DllImport ("physfs")]
    #endif
        public unsafe  static extern long PHYSFS_fileLength(PHYSFS_File* handle);
}
