///
///利用POST方式通信
///
///

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonPostTest : MonoBehaviour {

    private string url = "http://www.lxway.com/922295882.htm";

    private IEnumerator Start()
    {
        WWWForm form = new WWWForm();
        form.AddField("userid","ABC");
        form.AddField("pwd","***");
        WWW getData = new WWW(url);
        yield return getData;
        if(getData.error!=null)
        {
            Debug.Log(getData.error);
        }
        else
        {
            Debug.Log(getData.text);
        }
    }
}
