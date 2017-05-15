///
///鼠标控制旋转方向
///键盘控制移动
///

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Vector3 lastlMouse = new Vector3(Screen.width / 2, Screen.height / 2);//屏幕中间而不是在顶端
    float playerSens = .25f;//鼠标输入控制旋转的灵敏度
    float mainSpeed = 10f;//正常速度
    float shiftAdd = 25f;//按住shift的最低速度
    float maxShift = 100f;//按住shift的最大速度
    float totalRun = 1.0f;

    void Start()
    {
        transform.localEulerAngles = Vector3.zero;
    }


    void Update()
    {
        //鼠标输入
        lastlMouse = Input.mousePosition - lastlMouse;
        lastlMouse = new Vector3(-lastlMouse.y * playerSens, lastlMouse.x * playerSens, 0);
        lastlMouse = new Vector3(transform.eulerAngles.x + lastlMouse.x, transform.eulerAngles.y+lastlMouse.y, 0);
        transform.eulerAngles = lastlMouse;
        lastlMouse = Input.mousePosition;

        //键盘命令
        Vector3 pos = getDirection();
        if(Input.GetKey(KeyCode.LeftShift))
        {
            totalRun += Time.deltaTime;
            pos = pos * totalRun * shiftAdd;
            pos.x = Mathf.Clamp(pos.x,-maxShift,maxShift);
            pos.y = Mathf.Clamp(pos.y,-maxShift,maxShift);
            pos.z = Mathf.Clamp(pos.z,-maxShift,maxShift);
        }
        else
        {
            totalRun = Mathf.Clamp(totalRun*0.5f,1f,1000f);
            pos = pos * mainSpeed;
        }
        pos = pos * Time.deltaTime;
        Vector3 newPosition = transform.position;
        //if (Input.GetKey(KeyCode.V))//控制只在z,x轴移动
        //{
        //    transform.Translate(pos);
        //    newPosition.x = transform.position.x;
        //    newPosition.z = transform.position.z;
        //    transform.position = newPosition;
        //}
        //else
        //{
            transform.Translate(pos);
        //}

    }
    private Vector3 getDirection()
    {
        Vector3 pos_Velocity = new Vector3();
        if(Input.GetKey(KeyCode.W))
        {
            pos_Velocity += new Vector3(0,0,1);
        }
        if(Input.GetKey(KeyCode.S))
        {
            pos_Velocity += new Vector3(0,0,-1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            pos_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos_Velocity += new Vector3(1, 0, 0);
        }
        return pos_Velocity;
    }
}
