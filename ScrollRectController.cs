using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectController : MonoBehaviour {

    public Scrollbar bar;
    private ScrollRect scrollRect;
    private GameObject item;
    private GameObject grid;
	// Use this for initialization
	void Start () {
        scrollRect = transform.GetComponent<ScrollRect>();
        item = transform.FindChild("item").gameObject;
        grid = transform.FindChild("grid").gameObject;
        AddItem();
	}

    public void OnEndDrag(PointerEventData eventData)
    {
        if (bar.value <= 0)
        {
            AddItem();
        }
    }
	
    void AddItem()
    {
        for(int i=0;i<5; i++)
        {
            GameObject newItem=AddChild(item,grid);
            newItem.SetActive(true);
            string str = string.Format("第{0}项时间为{1}", i, System.DateTime.Now);
            newItem.GetComponent<ItemController>().setItem(str);
        }
    }

    public static GameObject AddChild(GameObject obj,GameObject parent)
    {
        if(obj==null || parent==null)
        {
            return null;
        }
        GameObject inst = GameObject.Instantiate(obj) as GameObject;
        inst.transform.SetParent(parent.transform, false);
        inst.transform.localPosition = Vector3.zero;
        inst.transform.localScale = Vector3.one;
        return inst;
    }
}
