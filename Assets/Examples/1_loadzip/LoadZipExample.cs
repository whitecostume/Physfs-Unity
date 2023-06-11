using UnityEngine;
using UnityEngine.UI;
using PhysfsUnity;

public class LoadZipExample : MonoBehaviour
{
    public Text text;
    


    private int _handler;
    
    void Start()
    {
     
       
        Physfs.Init();

            
        #if UNITY_ANDROID && !UNITY_EDITOR
            // Android端是一个apk文件，所以先mount apk，然后查到对于的zip，再用 mountHandle 去mount
            string path = Application.streamingAssetsPath.Replace("!/assets","").Replace("jar:file:///","");
            
            if (!Physfs.MountArchiveInArchive(path,"assets/test.zip","test.zip",null,0))
            {
                return;
            }
            
        #else
            string path = Application.streamingAssetsPath + "/test.zip";
            if (!Physfs.Mount(path,null,0))
                return;
        #endif

            byte[] readByte;
            long fileLength;
            if(!Physfs.ReadBytes("test.txt",out readByte,out fileLength))
                return;

            string content = System.Text.Encoding.Default.GetString(readByte);
            
            if (text)
            {
                text.text = content;
            }

            Physfs.Unmount(path);
        

    }

    void OnDestroy()
    {
       Physfs.DeInit();
    }
}
