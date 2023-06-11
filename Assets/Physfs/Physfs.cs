
using UnityEngine;

namespace PhysfsUnity
{
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

        public static void Init()
        {
            Physfs_Dll.PHYSFS_init(null);
        }

        public static void DeInit()
        {
            Physfs_Dll.PHYSFS_deinit();
        }


        
        public static bool Mount(string path,string mountPoint,int appendToPath)
        {
            unsafe
            {
                int result = Physfs_Dll.PHYSFS_mount(path,mountPoint,appendToPath);

                // mount fail
                if (result == 0)
                {
                    Debug.LogError($"mount {path} fail, errorCode {(Physfs.PHYSFS_ErrorCode) Physfs_Dll.PHYSFS_getLastErrorCode()}" );
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Mount the compressed package in the compressed package
        /// </summary>
        /// <param name="root"></param>
        /// <param name="subArchive"></param>
        /// <param name="mountPoint"></param>
        /// <param name="appendToPath"></param>
        /// <returns></returns>
        public static bool MountArchiveInArchive(string root,string subArchive,string archive,string mountPoint,int appendToPath)
        {
            unsafe
            {
                int result =  Physfs_Dll.PHYSFS_mount(root,null,appendToPath);

                if (result == 0)
                {
                    Debug.LogError($"mount {root} fail, errorCode {(Physfs.PHYSFS_ErrorCode) Physfs_Dll.PHYSFS_getLastErrorCode()}" );
                    return false;
                }

                Physfs_Dll.PHYSFS_File* mainArchive = Physfs_Dll.PHYSFS_openRead(subArchive);
                if (mainArchive == null)
                {
                    Debug.LogError($"file {subArchive} open fail, errorCode {(Physfs.PHYSFS_ErrorCode) Physfs_Dll.PHYSFS_getLastErrorCode()}");   
                    return false;
                }
                result = Physfs_Dll.PHYSFS_mountHandle(mainArchive,archive,null,appendToPath);

                if (result == 0)
                {
                    Debug.LogError($"mount {subArchive} fail, errorCode {(Physfs.PHYSFS_ErrorCode) Physfs_Dll.PHYSFS_getLastErrorCode()}" );
                    return false;
                }

                return true;
            }
        }

        public static void Unmount(string path)
        {
            Physfs_Dll.PHYSFS_unmount(path);
        }

        

        public static bool ReadBytes(string assetPath,out byte[] bytes,out long fileLength)
        {
            unsafe
            {
                Physfs_Dll.PHYSFS_File* file = Physfs_Dll.PHYSFS_openRead(assetPath);

                if (file == null)
                {
                    bytes = new byte[0];
                    fileLength = 0;
                    Debug.LogError($"file {assetPath} open fail, errorCode {(Physfs.PHYSFS_ErrorCode) Physfs_Dll.PHYSFS_getLastErrorCode()}");   
                    return false;
                }
                
                fileLength = Physfs_Dll.PHYSFS_fileLength(file);
                bytes = new byte[fileLength];
                Physfs_Dll.PHYSFS_readBytes(file,bytes,(ulong)fileLength);
                Physfs_Dll.PHYSFS_close(file);
                return true;
            }
        }

    }

}