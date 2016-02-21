using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    static int points;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public static void addPoints(int newPoints){
        points += newPoints;
    }
        
    void OnGUI(){
        GUI.Label(new Rect(10, 10, 200, 60), "Puntos: " + points);
    }
}
