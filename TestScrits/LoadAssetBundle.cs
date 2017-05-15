///
///AssetBundle打包之Scene场景打包
///功能：加载物体
///


using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAssetBundle : MonoBehaviour
{

    private string url;
    private string assetName;
    private void Start()
    {
        //下载压缩包，写出具体的名字
        url = "file://" + Application.dataPath + "Scene.unity3d";

        //unity预制体名字，即被打包的场景名字叫 “game”
        assetName = "game";
        StartCoroutine(DownLoad());
    }

    IEnumerator DownLoad()
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.error != null)
        {
            Debug.Log("download fail");
        }
        else
        {
            AssetBundle bundle = www.assetBundle;
            SceneManager.LoadScene(assetName);
            print("切换场景");
            bundle.Unload(false);
            // AssetBundle.Unload(false)，释放AssetBundle文件内存镜像，不销毁Load创建的Assets对象  
            // AssetBundle.Unload(true)，释放AssetBundle文件内存镜像同时销毁所有已经Load的Assets内存镜像  
        }
        //中断正在加载过程中的WWW
        www.Dispose();
    }
}
