using UnityEngine;
using System.Diagnostics;

public class Download : MonoBehaviour {

    //PC端打开网页
    //public static Process C;

	public void DownloadBtn()
    {
        //CallWeb();
#if UNITY_ANDROID
        Application.OpenURL("https://app.edoctor.cn//appdownload?id=6138");//地址获取应解析JSON获取动态地址
#endif
#if UNITY_IPHONE
         Application.OpenURL("itms - services://?action=download-manifest&url=https://app.edoctor.cn/plist?id=6132");
#endif

    }
    //PC端打开网页
    //void CallWeb () {
    //       C = System.Diagnostics.Process.Start("https://app.edoctor.cn/detailapps?appid=6125");	
    //}
}
