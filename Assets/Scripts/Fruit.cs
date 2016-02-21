using UnityEngine;
using System.Collections;


public class Fruit : MonoBehaviour {
    
    public float speed;
	public int type;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate (0, - speed * Time.deltaTime, 0);

        if (transform.position.y < -7)
            Destroy(this.gameObject);
	}



}
