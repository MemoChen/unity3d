using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ItemController : MonoBehaviour {

    private Text labText;
    public void setItem(string str)
    {
        labText = transform.GetComponentInChildren<Text>();
        labText.text = str;
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
