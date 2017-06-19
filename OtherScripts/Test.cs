using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{

    public TrackableEventHandler trackableeventhandler;
    public Terrain myterrain;
    void Start()
    {

    }

    //void MyTest()
    //{
    //    UnityAction<BaseEventData> teststr = new UnityAction<BaseEventData>(CreateTest);
    //    EventTrigger.Entry onClick = new EventTrigger.Entry();
    //    onClick.eventID = EventTriggerType.PointerClick;
    //    onClick.callback.AddListener(teststr);
    //    onClick.callback.AddListener
        
    //} 
    void TTest()
    {
        UnityAction<BaseEventData> teststr = new UnityAction<BaseEventData>(CreateTest);
        EventTrigger.Entry onClick = new EventTrigger.Entry();
        onClick.eventID = EventTriggerType.PointerClick;
        onClick.callback.AddListener(teststr);
        //onClick.callback.AddListener();
    }
    void CreateTest(BaseEventData str)
    {
        Debug.Log(str);
    }  
    void Update()
    {
        if (trackableeventhandler.isRun)
        {
            myterrain.enabled = true;         
        }
        else
        {
            myterrain.enabled = false;
        }

    }
}
