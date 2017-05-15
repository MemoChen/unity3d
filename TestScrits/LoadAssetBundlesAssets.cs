///
///AssetBundle打包之资源打包
///功能：加载物体
///

using System.Collections;
using UnityEngine;

public class LoadAssetBundlesAssets : MonoBehaviour {

    private string url;
    private string assetName;
    //public string weburl;
    private void Start()
    {
        url = "file://" + Application.dataPath + "AssetBundles/test.assetbundle";

        assetName = "test";
        StartCoroutine(Download());
    }

    IEnumerator Download()
    {
        WWW www = new WWW(url);
        yield return www;
        if(www.error!=null)
        {
            Debug.LogError("download failed");
        }
        else
        {
            AssetBundle bundle = www.assetBundle;

            //加载的是预设体的名字，不是打包的assetbundle的名字
            Object obj = bundle.LoadAsset(assetName);
            Instantiate(obj, Vector3.zero, Quaternion.identity);
            bundle.Unload(false);
            Debug.LogError("load successful");
        }
        //中断正在加载过程中的www
        www.Dispose();
    }
}
