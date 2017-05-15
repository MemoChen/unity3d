//using UnityEngine;
//using System.Collections;

//public enum GameState
//{
//    Play,
//    Pause
//}

//public enum GameSceneState
//{
//    Left,
//    Right
//}

//public class UIManager : MonoBehaviour
//{

//    private GameState gameState;
//    private GameSceneState gameSceneState;

//    #region 两个父节点
//    public GameObject leftScene;
//    public GameObject rightScene;
//    #endregion

//    #region 动态加载
//    private GameObject[] tempTarget=new GameObject[5];
//    private GameObject tempPipe;
//    private GameObject tempU01;
//    private GameObject tempS01;
//    private GameObject tempS03;
//    private GameObject tempKnot;
//    #endregion


//    /// <summary>
//    /// 初始化场景条件
//    /// </summary>
//    private bool isInit = false;
//    /// <summary>
//    /// 动画播放结束才能出发场景二按钮的条件
//    /// </summary>
//    private bool isEnd = false;

//    private bool isRight = false;
//    private bool isU01 = false;
//    private bool isS01 = false;
//    private bool isS03 = false;

//    #region 场景按钮控制
//    public void LeftBtnSwitch()
//    {
//        if(isEnd)
//        {
//            gameSceneState = GameSceneState.Left;
//        }
//    }
//    public void RightBtnSwitch()
//    {
//        if(isEnd)
//        {
//            gameSceneState = GameSceneState.Right;
//        }
//    }
//    #endregion

//    void Start()
//    {
//        StartCoroutine(LoadTemp(isU01,tempU01,"Prefabs/U01"));
//    }

//    void Update()
//    {
//        if (Vuforia.DefaultTrackableEventHandler.isRun)
//        {
//            gameState = GameState.Play;
//        }
//        else
//        {
//            gameState = GameState.Pause;
//        }
//        switch (gameState)
//        {
//            case GameState.Pause:
//                PauseGame();
//                break;
//            case GameState.Play:
//                PlayGame();
//                break;
//        }
//        switch (gameSceneState)
//        {
//            case GameSceneState.Left:
//                break;
//            case GameSceneState.Right:
//                break;
//        }
//    }

//    private void PlayGame()
//    {
//        if (!isInit)
//        {
//            //默认场景一
//            gameSceneState = GameSceneState.Left;
//            isInit = true;
//        }
//        if (gameSceneState == GameSceneState.Left)
//        {
//            //根据纪录动画继续播放
//        }
//        else
//        {

//        }

//    }
//    private void PauseGame()
//    {
//        if (gameSceneState == GameSceneState.Left)
//        {
//            //纪录当前动画
//        }
//    }

//    private void PlayLeftScene()
//    {
//        if(isU01)
//        {
//            if(!tempU01.GetComponent<Animator>().enabled)
//                tempU01.GetComponent<Animator>().enabled = true;
//            AnimatorStateInfo stateInfo = tempU01.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
//            if(stateInfo.normalizedTime>=0.5f)
//            {
//                StartCoroutine(LoadTemp(isS01,tempS01,"Prefabs/S01",2.5f));              
//            }
//        }
//        if(isS01)
//        {
//            if(tempS01!=null)
//            {
//                tempS01.SetActive(true);
//            }
//            Destroy(tempU01);
//        }
//    }
//    private void PlayRightScene()
//    {


//    }

//    private IEnumerator LoadTemp(bool isBegin,GameObject obj,string path)
//    {
//        if(!isBegin)
//        {
//            ResourceRequest temp = Resources.LoadAsync(path);
//            obj = Instantiate(temp.asset) as GameObject;
//            obj.transform.SetParent(leftScene.transform);
//            obj.transform.position = leftScene.transform.position;
//            obj.GetComponent<Animator>().enabled = false;
//            yield return temp;
//            isBegin = true;
//        }
//    }
//    private IEnumerator LoadTemp(bool isBegin, GameObject obj, string path,float time)
//    {
//        if (!isBegin)
//        {
//            ResourceRequest temp = Resources.LoadAsync(path);
//            obj = Instantiate(temp.asset) as GameObject;
//            obj.transform.SetParent(leftScene.transform);
//            obj.transform.position = leftScene.transform.position;
//            obj.SetActive(false);
//            obj.GetComponent<Animator>().enabled = false;
//            yield return new WaitForSeconds(time);
//            //obj.SetActive(true);
//            obj.GetComponent<Animator>().enabled = true;
//            isBegin = true;
//        }
//    }
//}
