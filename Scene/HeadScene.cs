using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HeadScene : MonoBehaviour
{

    /// <summary>
    /// 进入下一个场景
    /// </summary>

    public void GoNextScene()
    {
        if (Application.loadedLevelName != "Head")
        {
            //StartCoroutine(RunInit());
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
            return;
        }
    }
    /// <summary>
    /// 返回上一个场景
    /// </summary>
    public void ReturnLsatScene()
    {
        //StartCoroutine(Init());
        SceneManager.LoadSceneAsync(0);
    }
    /// <summary>
    /// 控制场景切换旋转与屏幕方向
    /// </summary>
    /// <returns></returns>
    private IEnumerator Init()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone && asyncOperation.progress < 0.1f)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            yield return null;
        }
        asyncOperation.allowSceneActivation = true;
    }

    private IEnumerator RunInit()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone && asyncOperation.progress < 0.1f)
        {
            Screen.orientation = ScreenOrientation.Portrait;
            yield return null;
        }
        asyncOperation.allowSceneActivation = true;
    }
}
