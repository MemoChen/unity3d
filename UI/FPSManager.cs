using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class FPSManager : MonoBehaviour
{
    private Text textField;
    private float fps = 0;

    void Awake()
    {
        textField = GetComponent<Text>();
    }

    void LateUpdate()
    {
        string text = null;
        float interp = Time.deltaTime / (0.5f + Time.deltaTime);
        float currentFPS = 1.0f / Time.deltaTime;
        fps = Mathf.Lerp(fps, currentFPS, interp);
        text += "FPS:" + Mathf.RoundToInt(fps);
        textField.text = text;
    }
}
