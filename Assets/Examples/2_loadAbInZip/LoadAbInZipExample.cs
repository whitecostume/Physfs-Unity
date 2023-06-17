using UnityEngine;
using UnityEngine.UI;
using PhysfsUnity;


/// <summary>
/// Load the assetbundle in the compressed package
/// </summary>
public class LoadAbInZipExample : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Text text;

    void Start()
    {


        Physfs.Init();

#if UNITY_ANDROID && !UNITY_EDITOR
            // Android端是一个apk文件，所以先mount apk，然后查到对于的zip，再用 mountHandle 去mount
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

        string path = Application.streamingAssetsPath + "/assetbundle_example.zip";
        if (!Physfs.Mount(path, null, 0))
            return;
#endif
        var bundlePath = "assetbundle_example.ab";

        string rfileName;
        long fileOffset = Physfs.CalRealFileOffset(bundlePath,out rfileName);
       
        if (fileOffset == -1)
            return;

        Debug.LogWarning("fileOffset " + fileOffset);
        Debug.LogWarning("rfileName " + rfileName);

        AssetBundle ab = AssetBundle.LoadFromFile(rfileName, 0, (ulong)fileOffset);
        if (ab == null)
            return;

        var textAsset = ab.LoadAsset<TextAsset>("testasset");

        if (text && textAsset)
        {
            text.text = textAsset.text;
        }

        var spriteSun = ab.LoadAsset<Sprite>("sun");
        if (spriteRenderer && spriteSun)
        {
            spriteRenderer.sprite = spriteSun;
        }

        // ab.Unload(true);

        Physfs.Unmount(path);
    }

    void OnDestroy()
    {
        Physfs.DeInit();
    }
}
