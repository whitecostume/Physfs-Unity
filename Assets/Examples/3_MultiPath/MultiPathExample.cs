using UnityEngine;
using UnityEngine.UI;
using PhysfsUnity;

public class MultiPathExample : MonoBehaviour
{
    public Text text;

    void MountPath(string dirPath,int appendToPath)
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
        string path = Application.streamingAssetsPath.Replace("!/assets","").Replace("jar:file:///","");
        
        if (!Physfs.Mount(path, null, appendToPath))
            return;

        string rmainZip;
        long mainZipOffset = Physfs.CalRealFileOffset($"assets/{dirPath}",out rmainZip);
        long mainZipLength = mainZipOffset > 0 ? Physfs.ReadFileLength($"assets/{dirPath}") : -1;
        if (!Physfs.MountOffset(path,null,appendToPath,(ulong)mainZipOffset,mainZipLength))
            return;
    #else
        string path = $"{Application.streamingAssetsPath}/{dirPath}";
        if (!Physfs.Mount(path,null,appendToPath))
            return;
    #endif

    }

    // Start is called before the first frame update
    void Start()
    {
     
       
        Physfs.Init();

        MountPath("test.zip",0);
        MountPath("multi/A",1);
        MountPath("multi/B",1);

        byte[] readByte;
        long fileLength;
        if(!Physfs.ReadBytes("test.txt",out readByte,out fileLength))
            return;

        string content = System.Text.Encoding.Default.GetString(readByte);

        if(!Physfs.ReadBytes("A.txt",out readByte,out fileLength))
            return;

        content += "\n";
        content += System.Text.Encoding.Default.GetString(readByte);

        if(!Physfs.ReadBytes("B.txt",out readByte,out fileLength))
            return;

        content += "\n";
        content += System.Text.Encoding.Default.GetString(readByte);
        
        if (text)
        {
            text.text = content;
        }
    }

    void OnDestroy()
    {
       Physfs.DeInit();
    }
}
