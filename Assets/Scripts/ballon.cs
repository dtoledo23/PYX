using UnityEngine;
using System.Collections;

public class ballon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, Mathf.Cos(Time.time)*0.01f, 0);
	}

    //onDest
}
