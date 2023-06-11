using UnityEngine;
using UnityEngine.UI;
using PhysfsUnity;


/// <summary>
/// Load the assetbundle in the compressed package
/// </summary>
public class LoadAbInZipExample : MonoBehaviour
{

    public Text text;

    void Start()
    {


        Physfs.Init();

#if UNITY_ANDROID && !UNITY_EDITOR
            // Android端是一个apk文件，所以先mount apk，然后查到对于的zip，再用 mountHandle 去mount
            string path = Application.streamingAssetsPath.Replace("!/assets","").Replace("jar:file:///","");
            
            if (!Physfs.MountArchiveInArchive(path,"assets/assetbundle_example.zip","assetbundle_example.zip",null,0))
            {
                return;
            }
            
#else
        string path = Application.streamingAssetsPath + "/assetbundle_example.zip";
        if (!Physfs.Mount(path, null, 0))
            return;
#endif
        var bundlePath = "assetbundle_example.ab";

        long fileOffset = Physfs.Tell("assetbundle_example.ab");
       
        if (fileOffset == -1)
            return;

        Debug.LogError("fileOffset " + fileOffset);

        AssetBundle ab = AssetBundle.LoadFromFile(bundlePath, 0, (ulong)fileOffset);
        if (ab == null)
            return;

        var textAsset = ab.LoadAsset<TextAsset>("textasset");

        if (text)
        {
            text.text = textAsset.text;
        }

        ab.Unload(true);

        Physfs.Unmount(path);
    }

    void OnDestroy()
    {
        Physfs.DeInit();
    }
}
