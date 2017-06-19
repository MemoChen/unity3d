//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class TargetManager : MonoBehaviour
//{
//    /// <summary>
//    /// 场景二中的管子
//    /// </summary>
//    public Transform linePipe;
//    /// <summary>
//    /// 场景一中的管子
//    /// </summary>
//    public Transform[] allPipe;
//    void Start()
//    {
      
//    }
//    private void Init()
//    {
//        #region 初始化，enable场景二中管子的meshrenderer
//        MeshRenderer[] pipeChildren = linePipe.GetComponentsInChildren<MeshRenderer>();
//        for (int i = 0; i < pipeChildren.Length; i++)
//        {
//            pipeChildren[i].enabled = false;
//        }
//        #endregion

//        #region 初始化，除U型管所有的管子的SkinnedMeshRenderer设为FALSE
//        for (int i = 1; i < allPipe.Length; i++)
//        {
//            SkinnedMeshRenderer[] UPipe = allPipe[i].GetComponentsInChildren<SkinnedMeshRenderer>();
//            for (int j = 0; j < UPipe.Length; j++)
//            {
//                UPipe[j].enabled = false;
//            }
//        }
//        #endregion
//    }
//    /// <summary>
//    /// 切换按钮一对应场景一
//    /// </summary>
//    public void SwitchBtn01()
//    {
//        //Init();
//    }
//    /// <summary>
//    /// 切换按钮二对应场景二
//    /// </summary>
//    public void SwitchBtn02()
//    {
//        #region 所有的管子的SkinnedMeshRenderer设为FALSE
//        for (int i = 0; i < allPipe.Length; i++)
//        {
//            SkinnedMeshRenderer[] UPipe = allPipe[i].GetComponentsInChildren<SkinnedMeshRenderer>();
//            for (int j = 0; j < UPipe.Length; j++)
//            {
//                UPipe[j].enabled = false;
//            }
//        }
//        #endregion

//        #region 场景二中管子的meshrenderer设为true
//        MeshRenderer[] pipeChildren = linePipe.GetComponentsInChildren<MeshRenderer>();
//        for (int i = 0; i < pipeChildren.Length; i++)
//        {
//            pipeChildren[i].enabled = true;
//        }
//        #endregion
//    }


//    //private void SameStart(Object[] obj,Transform[] trans)
//    //{

//    //    obj = trans[trans.Length-1].GetComponentsInChildren<Object>();
//    //    for(int i=0;i<obj.Length;i++)
//    //    {
//    //        Debug.LogError(obj[i]);
//    //    }
//    //}

//}
