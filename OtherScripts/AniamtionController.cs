//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;

//public enum PipeState
//{
//    Play,
//    Pause
//}
//public class AniamtionController : MonoBehaviour
//{

//    public Vuforia.DefaultTrackableEventHandler defaultTrackableEventHandler;
//    public Animation[] pipeAnimation;
//    public GameObject[] Pipe;
//    public PipeState pipeState;
//    public Text text01;
//    public Text text02;

//    void Update()
//    {
//        //if (defaultTrackableEventHandler.isRun)
//        //{
//        //    pipeState = PipeState.Play;
//        //}
//        //else
//        //{
//        //    pipeState = PipeState.Pause;
//        //}
//        switch (pipeState)
//        {
//            case PipeState.Play:
//                PlayState();
//                break;
//            case PipeState.Pause:
//                PauseState();
//                break;
//        }

//    }

//    private void PlayState()
//    {
//        if (pipeAnimation[0].enabled == false)
//        {
//            pipeAnimation[0].enabled = true;
//            pipeAnimation[0].Play();
//        }
//        if (!pipeAnimation[0].isPlaying)
//        {
//            StartCoroutine(WaitGo(Pipe[0], Pipe[1], pipeAnimation[1], 2f));
//        }
//    }
//    private void PauseState()
//    {
//        if(SceneManager.isPause)
//        {
//          for(int i=0;i<pipeAnimation.Length;i++)
//            {
//                if(pipeAnimation[i].isPlaying)
//                {
//                    pipeAnimation[i].Stop();
//                }
//            }
//        }
       
//    }

//    private IEnumerator WaitGo(GameObject pipeObj01, GameObject pipeObj02, Animation pipeAni, float time)
//    {
//        yield return new WaitForSeconds(time);
//        pipeObj01.SetActive(false);
//        pipeObj02.SetActive(true);
//        pipeAni.enabled = true;
//    }
//}
