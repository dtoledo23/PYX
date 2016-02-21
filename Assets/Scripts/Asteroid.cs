using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    float speedY = -5.0f;
    float speedX;

	void Start () {
        speedX = Random.Range(-2, 2);
        transform.Rotate(new Vector3(0, 0, Mathf.Atan2(speedY, speedX)));
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(speedX * Time.deltaTime, speedY * Time.deltaTime));

        if (transform.position.y <= -5)
            Destroy(this.gameObject);
	}
}
