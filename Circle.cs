using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {

    public GameObject circlePrefab;

    public int changeAngle = 0;

    private int count;

    private float angle = 0;
    public float r = 5;

	void Update () {

        count = 360 / changeAngle;

        for (int i=0;i<count;i++)
        {
            Vector3 center = circlePrefab.transform.position;
            GameObject cube = (GameObject)Instantiate(circlePrefab);
            float hudu = (angle / 180) * Mathf.PI;
            float xx = center.x + r * Mathf.Cos(hudu);
            float yy = center.y + r * Mathf.Sin(hudu);
            cube.transform.position = new Vector3(xx, yy, 0);
            cube.transform.LookAt(center);
            angle += changeAngle;
        }
       
    }
}
