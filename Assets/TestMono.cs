using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMono : MonoBehaviour
{
    public Text text;
   

    private int _handler;
    
    void Start()
    {
        
        unsafe
        {
            _handler =  Physfs.PHYSFS_init(null);
            
        #if UNITY_ANDROID && ! UNITY_EDITOR
            // Android端是一个apk文件，所以先mount apk，然后查到对于的zip，再用 mountHandle 去mount
            string path = Application.streamingAssetsPath.Replace("!/assets","").Replace("jar:file:///","");
            int mountResult =  Physfs.PHYSFS_mount(path,null,0);

            if (mountResult == 0)
            {
                Debug.LogError("mount " + path + " fail " + (Physfs.PHYSFS_ErrorCode) Physfs.PHYSFS_getLastErrorCode());
                return;
            }

            Physfs.PHYSFS_File* mainZip = Physfs.PHYSFS_openRead("assets/test.zip");
            mountResult = Physfs.PHYSFS_mountHandle(mainZip,"test.zip",null,0);

             if (mountResult == 0)
            {
                Debug.LogError("mount test.zip " + " fail " + (Physfs.PHYSFS_ErrorCode) Physfs.PHYSFS_getLastErrorCode());
                return;
            }

        #else
            string path = Application.streamingAssetsPath + "/test.zip";
            int mountResult =  Physfs.PHYSFS_mount(path,null,0);
            if (mountResult == 0)
            {
                Debug.LogError("mount " + path + " fail " + (Physfs.PHYSFS_ErrorCode) Physfs.PHYSFS_getLastErrorCode());
                return;
            }
        #endif


            Physfs.PHYSFS_File* file = Physfs.PHYSFS_openRead("test.txt");

            if (file == null)
            {
                Debug.LogError("file open fail : test.txt");   
            }
            else
            {
                 long fileLength = Physfs.PHYSFS_fileLength(file);

                Debug.Log("fileLength " + fileLength);
                
                byte[] readByte = new byte[fileLength];
                Physfs.PHYSFS_readBytes(file,readByte,100);

                string content = System.Text.Encoding.Default.GetString(readByte);
            

                Debug.Log("content " + content);
                if (text)
                {
                    text.text = content;
                }

                Physfs.PHYSFS_close(file);
            }

           

            Physfs.PHYSFS_unmount(path);
        }

    }

    void OnDestroy()
    {
       Physfs.PHYSFS_deinit();
    }
}
