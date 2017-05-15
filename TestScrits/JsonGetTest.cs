///
///尝试GET方式通信
///

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonGetTest : MonoBehaviour {

    private string url = "http://www.lxway.com/922295882.htm";
    private IEnumerator Start()
    {
        Debug.LogError("test");
        WWW getData = new WWW(url);
        yield return getData;
        if(getData.error!=null)
        {
            Debug.LogError(getData.error);
        }
        else
        {
            Debug.LogError(getData.text);
        }
    }
}
