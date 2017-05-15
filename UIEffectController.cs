using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIEffectController : MonoBehaviour {

    /// <summary>
    /// 汽车动画
    /// </summary>
    public Animator jeepAnimator;
    /// <summary>
    /// ui动画
    /// </summary>
    public Animator uiAnimator;
    /// <summary>
    /// 主相机
    /// </summary>
    public Camera arCamera;
    /// <summary>
    /// 图片目标
    /// </summary>
    public GameObject imageTarget;
    /// <summary>
    /// ui相机
    /// </summary>
    public Camera uiCamera;
    /// <summary>
    /// ui滑动条
    /// </summary>
    public Scrollbar scrollBar;
    /// <summary>
    /// grid对象
    /// </summary>
    public GameObject panelGrid;
    /// <summary>
    /// 邀请函首页
    /// </summary>
    public GameObject invitationSprite;
    /// <summary>
    /// 邀请函Apla值
    /// </summary>
    private float addAlpa = 0f;
    /// <summary>
    /// 开始运行条件
    /// </summary>
    private bool isBegin = false;
    /// <summary>
    /// 特效条件
    /// </summary>
    private bool isFlash = false;
    /// <summary>
    /// Apla值开始增加条件
    /// </summary>
    private bool isBeginAdd = false;
    /// <summary>
    /// 上升旋转时间
    /// </summary>
    private float time = 0;

	void Start () {
        invitationSprite.GetComponent<SpriteRenderer>().material.color = new Color(1f,1f,1f,0f);       
        uiCamera.enabled = false;
    }

	void Update () {     
     
        if(!isBegin)
        {
            if (jeepAnimator.enabled == false)
            {
                isFlash = true;
                isBegin = true;
            }
        }

        if (isFlash)
        {
            arCamera.gameObject.GetComponent<CameraFilterPack_AAA_WaterDrop>().enabled = true;
            arCamera.gameObject.GetComponent<CameraFilterPack_Vision_Crystal>().enabled = true;
            if(arCamera.gameObject.GetComponent<CameraFilterPack_Vision_Crystal>().TimeX>=5.0f)
            {
                arCamera.gameObject.GetComponent<CameraFilterPack_AAA_WaterDrop>().enabled = false;
                arCamera.gameObject.GetComponent<CameraFilterPack_Vision_Crystal>().enabled = false;
                isBeginAdd = true;
                isFlash = false;
            }
        }  
        //if(isBeginAdd)
        //{
        //    addAlpa += 0.0025f;
        //    if (addAlpa <=1.0f)
        //    {
        //        invitationSprite.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, addAlpa);
        //    }
        //    else
        //    {
        //        uiAnimator.SetTrigger("isUI");
        //        AnimatorStateInfo stateInfo = uiAnimator.GetCurrentAnimatorStateInfo(0);
        //        if (stateInfo.normalizedTime >= 1.0f)
        //        {
        //            time += Time.deltaTime;
        //            if(time>=1.0f)
        //            {
        //                if(uiAnimator.gameObject.transform.localPosition.y<=0.5f)
        //                {
                           
        //                    uiAnimator.gameObject.transform.Translate(Vector3.up * Time.deltaTime * 0.1f, Space.World);
                            
        //                }
        //                uiAnimator.gameObject.transform.Rotate(Vector3.up * Time.deltaTime * 50f, Space.World);
        //                //if(uiAnimator.gameObject.transform.localPosition.y>0.5f)
        //                //{
        //                    //StartCoroutine(WaitGo(3.5f));
        //                //}
        //            }
        //        }
        //    }

        //}
            //GetInvitationAlpa(isBeginAdd);
	}
    //private IEnumerator WaitGo(float timer)
    //{
    //    yield return new WaitForSeconds(timer);
    //    SwitchCamera();
    //}

    //private void SwitchCamera()
    //{
    //    arCamera.enabled = false;
    //    imageTarget.SetActive(false);
    //    uiCamera.enabled = true;
    //    panelGrid.SetActive(true);
    //    scrollBar.value = 0f;
    //}
    //private void GetInvitationAlpa( bool GoBegin)
    //{
    //    if(GoBegin)
    //    {
    //        //time += Time.deltaTime;
    //        addAlpa += 0.0025f;
    //        if (addAlpa < 1.0f)
    //        {
    //            invitationSprite.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, addAlpa);
    //        }
    //        else
    //        {
    //            uiAnimator.SetTrigger("isUI");
    //        }

    //        AnimatorStateInfo stateInfo = uiAnimator.GetCurrentAnimatorStateInfo(0);
    //        if(stateInfo.normalizedTime>=1.0f)
    //        {
    //            isBeginAdd = false;
    //        }
    //    }          
    //}
}
