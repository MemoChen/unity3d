///
///朝单一方向缩放物体
///position.z=A;
///scale.z=2*A;
///

using UnityEngine;
using System.Collections;

public class ScaleController : MonoBehaviour
{

    float time = 0;
    float index = 0;
    void Update()
    {
        time += Time.deltaTime;
        if (time < 3.5f && time > 1.5f)
        {
            transform.localScale = new Vector3(0.7f, 0.75f, -2 * time);
            transform.localPosition = new Vector3(0, 0, -time);
            index = time;
        }
        if (time > 3.5f)
        {
            index -= Time.deltaTime;
            transform.localScale = new Vector3(0.7f, 0.75f, -2 * index);
            transform.localPosition = new Vector3(0, 0, -index);
        }
        if (time > 6f)
        {
            time = 0;
        }


    }
}
