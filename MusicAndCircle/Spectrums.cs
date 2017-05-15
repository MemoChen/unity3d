///
///频谱
///
///频谱的形状
///
/// 频谱的颜色
/// 
/// 
///

using UnityEngine;
using System.Collections;

public class Spectrums : MonoBehaviour {

    /// <summary>
    /// 预制
    /// </summary>
    public GameObject prefab;
    /// <summary>
    /// 生成CUBE的数量
    /// </summary>
    public int numberOfObjects = 20;
    /// <summary>
    /// 圆的半径
    /// </summary>
    public float radius = 5f;
    public GameObject[] cubes;

    /// <summary>
    /// 变化的颜色
    /// </summary>
    Color[] color = { Color.red, Color.yellow, Color.white, Color.gray, Color.green, Color.cyan, Color.black, Color.blue, Color.grey, Color.magenta };
    /// <summary>
    /// 初始化开始颜色的随机值
    /// </summary>
    int index;

    bool isSet = false;

    void Start () {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 1, Mathf.Sin(angle)) * radius;
            Instantiate(Resources.Load("Musiccube/Cube"), pos, Quaternion.identity);
        }
        cubes = GameObject.FindGameObjectsWithTag("cubes");
        for (int i = 0; i < numberOfObjects; i++)
        {
            cubes[i].transform.SetParent(gameObject.transform);
            isSet = true;
        }
	}

    private void RandomNumber()
    {
        index = Random.Range(0, 10);//开始的颜色随机值
    }

    float time = 0;
    float timer = 0;

    void Update () {
        time += Time.deltaTime;
        timer += Time.deltaTime;
        if (time > 5.0f)
        {
            RandomNumber();
            time = 0;
        }
        if (isSet==true)
        {
            gameObject.transform.position = new Vector3(0, 0.84f, 2.3f);
            isSet = false;
        }
        float[] spectrum = AudioListener.GetSpectrumData(1024,0,FFTWindow.BlackmanHarris);
        for (int i = 0; i < numberOfObjects; i++)
        {
            if(timer<5.0f)
            {
                gameObject.transform.RotateAround(new Vector3(0,0.4732f,1.194f),Vector3.up,spectrum[i]*2.5f);            
            }
            else
            {
                gameObject.transform.RotateAround(new Vector3(0, 0.4732f, 1.194f), Vector3.up, -spectrum[i] * 2.5f);
                if((int)timer==10)
                {
                    timer = 0;
                }
            }

            Vector3 previousScale = cubes[i].transform.localScale;
            previousScale.y = spectrum[i] * 10;
            cubes[i].transform.localScale = previousScale;

            int number;
            if (i < numberOfObjects / 3)
            {
                number = Random.Range(0, 10);
                cubes[i].GetComponent<MeshRenderer>().material.color = Color.Lerp(color[index], color[number], spectrum[i] * 50);
            }
            else if (i < numberOfObjects / 3 * 2)
            {
                number = Random.Range(0, 10);
                cubes[i].GetComponent<MeshRenderer>().material.color = Color.Lerp(color[index], color[number], spectrum[i] * 50);
            }
            else
            {
                number = Random.Range(0, 10);
                cubes[i].GetComponent<MeshRenderer>().material.color = Color.Lerp(color[index], color[number], spectrum[i] * 50);
            }
        }
	}
}
