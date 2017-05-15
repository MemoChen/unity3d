using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {

    //定义一个时间长度
    public float duration = 1.0F;
    //定义一个红色（颜色自取）
    public Color colorRed = Color.red;
    //定义一个蓝色（颜色自取）
    public Color colorBlue = Color.blue;

    // Update is called once per frame
    void Update()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;

        //使用数学函数来实现闪光灯效果
        float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
        GetComponent<Light>().intensity = amplitude;
        float x = Mathf.PingPong(Time.time, duration) / duration;
        GetComponent<Light>().color = Color.Lerp(colorRed, colorBlue, x);
    }
}
