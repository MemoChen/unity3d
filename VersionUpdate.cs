///
///版本更新
///API"https://app.edoctor.cn/api/v1/plist?identifier=" + CurrentAppIdentifier + "&version=" + CurrentAppVersion
///


using UnityEngine;
using System.Collections;
using LitJson;

public class VersionUpdate :MonoBehaviour
{
    public GameObject obj;
    /// <summary>
    /// 当前版本号
    /// </summary>
    private string bundleVersion = null;
    /// <summary>
    /// web端版本号
    /// </summary>
    string version = null;
    /// <summary>
    /// 获取API路径
    /// </summary>
    private string path = "https://app.edoctor.cn//api/v1/plist?identifier=cn.edoctor.mobile.android.ardemo&version=1";
    /// <summary>
    /// 控制检测，当检测成功关闭检测
    /// </summary>
    private bool isUpdate = false;
    /// <summary>
    /// 转化成double类型进行版本比较
    /// </summary>
    double num1, num2;
    /// <summary>
    /// 
    /// </summary>
    string file_url=null;

    void Awake()
    {
        bundleVersion = Application.version;
        isUpdate = true;      
    }

    /// <summary>
    /// 检测方法
    /// </summary>
    /// <returns></returns>
    private IEnumerator Start()
    {
        WWW www = new WWW(path);
        yield return www;
        if (www.error != null)
        {
            Debug.LogError(www.error);
            yield break;
        }

        //返回数据{"status":true,"error_msg":"","info":"","version":"1.12",
        //"file_url":"https:\/\/app.edoctor.cn\/appdownload?id=6125"}
        if (string.IsNullOrEmpty(www.text))
        {
            yield break;
        }
        //解析json
        JsonData jsdata = JsonMapper.ToObject(www.text);
        //bool status = (bool)jsdata["status"];
        //string error_msg = (string)jsdata["error_msg"];
        //string info = (string)jsdata["info"];
        version = (string)jsdata["version"];
        file_url = (string)jsdata["file_url"];
    }
    /// <summary>
    /// 下载按钮
    /// </summary>
    public void DownloadBtn()
    {
#if UNITY_ANDROID
        if(file_url!=null)
        {
            Application.OpenURL(file_url);
        }      
#endif
    }

    public void CloseWindow()
    {
        obj.SetActive(false);
    }

    void Update()
    {
        if (isUpdate)
        {
            num1 = double.Parse(bundleVersion);
            if (version != null)
            {
                num2 = double.Parse(version);
                if (num1 - num2 < 0)
                {
                    isUpdate = false;
                    obj.SetActive(true);
                }
            }
        }      
    }
}
