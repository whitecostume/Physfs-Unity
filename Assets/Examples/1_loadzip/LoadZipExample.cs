using UnityEngine;
using UnityEngine.UI;
using PhysfsUnity;

/// <summary>
/// Load a txt file in the compressed package
/// </summary>
public class LoadZipExample : MonoBehaviour
{
    public Text text;

    void Start()
    {
     
       
        Physfs.Init();

            
        #if UNITY_ANDROID && !UNITY_EDITOR
            string path = Application.streamingAssetsPath.Replace("!/assets","").Replace("jar:file:///","");
            
            if (!Physfs.Mount(path, null, 0))
                return;

            string rmainZip;
            long mainZipOffset = Physfs.CalRealFileOffset("assets/assetbundle_example.zip",out rmainZip);
            long mainZipLength = Physfs.ReadFileLength("assets/assetbundle_example.zip");
            Physfs.Unmount(path);
            if (!Physfs.MountOffset(path,null,0,(ulong)mainZipOffset,mainZipLength))
                return;
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
