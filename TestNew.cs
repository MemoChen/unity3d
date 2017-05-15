using UnityEngine;
using System.Collections;

public class TestNew : MonoBehaviour {

    public GameObject obj;
    public WheelCollider objwheel;
	void Start () {
        if(objwheel.enabled==false)
        {
            //obj.AddComponent<Rigidbody>();
            obj.SetActive(true);
        }
      
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
