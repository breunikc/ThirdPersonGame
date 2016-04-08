using UnityEngine;
using System.Collections;

public class SpinLights : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        // rotate the light
        transform.Rotate(Vector3.up, 270 * Time.deltaTime, Space.World);
    }

}
