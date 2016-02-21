using UnityEngine;
using System.Collections;

public class GameConf : MonoBehaviour {

	// Use this for initialization
	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
    Vector3 original = new Vector3(0.06f, 6.13f, 0f);

    void Start () {

        StartCoroutine (InstancingKeys());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	IEnumerator InstancingKeys(){
		while(true){
			yield return new WaitForSeconds (3f);
            GameObject key;
            int fruit = Random.Range (1, 4);
			switch(fruit){
			case 1:
				key = (GameObject) Instantiate (prefab1);
                key.transform.position = original;
				break;
			case 2:
                key = (GameObject)Instantiate(prefab2);
                key.transform.position = original;
                break;
			case 3:
                key = (GameObject)Instantiate(prefab3);
                key.transform.position = original;
                break;
			}
		}
	}
}
