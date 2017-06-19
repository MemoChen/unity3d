using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class logData {
    public string output = "";
    public string stack = "";
    public static logData Init(string o,string s)
    {
        logData log = new logData();
        log.output = o;
        log.stack = s;
        return log;
    }
    public void Show()
    {
        GUILayout.Label(output);
        GUILayout.Label(stack);
    }
}


/// 手机调试脚本  
/// 本脚本挂在一个空对象或转换场景时不删除的对象即可  
/// 错误和异常输出日记路径 Application.persistentDataPath  
/// </summary> 
public class ShowDebugInPhone : MonoBehaviour {

    List<logData> logDatas = new List<logData>(); //log链表
    List<logData> errorDatas = new List<logData>(); //错误异常链表
    List<logData> waringDatas = new List<logData>(); //警告链表

    static List<string> mWriteTxt = new List<string>();
    Vector2 uiLog;
    Vector2 uiError;
    Vector2 uiWarining;
    bool open = false;
    bool showLog = false;
    bool showError = false;
    bool showWarning = false;
    private string outpath;

    private void Start()
    {
        //Application.persistentDataPath Unity中只有这个路径是既可以读也可以写的。  
        //Debug.Log(Application.persistentDataPath); 
        outpath = Application.persistentDataPath + "/outLog.txt";
        if (System.IO.File.Exists(outpath))
            File.Delete(outpath);
        DontDestroyOnLoad(gameObject);   
    }

    private void OnEnable()
    {
        //Application.RegisterLogCallback(HangleLog);
        Application.logMessageReceived += HangleLog;
    }
    private void OnDisable()
    {
        //当对象超出范围，删除回调。 
        //Application.RegisterLogCallback(null);
        Application.logMessageReceived-=null;
    }
    private void HangleLog(string logString,string stackTrace,LogType type)
    {
        switch (type)
        {
            case LogType.Log:
                logDatas.Add(logData.Init(logString, stackTrace));
                break;
            case LogType.Error:
            case LogType.Exception:
                errorDatas.Add(logData.Init(logString,stackTrace));
                mWriteTxt.Add(logString);
                mWriteTxt.Add(stackTrace);
                break;
            case LogType.Warning:
                waringDatas.Add(logData.Init(logString,stackTrace));
                break;
        }
    }

    private void Update()
    {
        if (errorDatas.Count > 0)
        {
            string[] temp = mWriteTxt.ToArray();
            foreach (string t in temp)
            {
                using (StreamWriter writer = new StreamWriter(outpath, true, Encoding.UTF8))
                {
                    writer.WriteLine(t);
                }
                mWriteTxt.Remove(t);
            }
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(">>Open", GUILayout.Height(150), GUILayout.Width(150)))
            open = !open;
        if (open)
        {
            if (GUILayout.Button("清理", GUILayout.Height(150), GUILayout.Width(150)))
            {
                logDatas = new List<logData>();
                errorDatas = new List<logData>();
                waringDatas = new List<logData>();
            }
            if (GUILayout.Button("显示log日志："+showLog,GUILayout.Height(150),GUILayout.Width(200)))
            {
                showLog = !showLog;
                if (open == true)
                    open = !open;
            }
            if (GUILayout.Button("显示error日志:"+showError,GUILayout.Height(150),GUILayout.Width(200)))
            {
                showError = !showError;
                if (open == true)
                    open = !open;
            }
            if(GUILayout.Button("显示warning日志："+showWarning,GUILayout.Height(150),GUILayout.Width(200)))
            {
                showWarning = !showWarning;
                if (open == true)
                    open = !open;
            }
            GUILayout.EndHorizontal();
        }
        if(showLog)
        {
            GUI.color = Color.white;
            uiLog = GUILayout.BeginScrollView(uiLog);
            foreach (var va in logDatas)
            {
                va.Show();
            }
            GUILayout.EndScrollView();
        }
        if(showError)
        {
            GUI.color = Color.red;
            uiError = GUILayout.BeginScrollView(uiError);
            foreach (var va in errorDatas)
            {
                va.Show();
            }
            GUILayout.EndScrollView();
        }
        if(showWarning)
        {
            GUI.color = Color.yellow;
            uiWarining = GUILayout.BeginScrollView(uiWarining);
            foreach (var va in waringDatas)
            {
                va.Show();
            }
            GUILayout.EndScrollView();
        }
    }
}
