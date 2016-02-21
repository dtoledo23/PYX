using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class Menu : MonoBehaviour {

    public string game1;
    public string game2;
    public string game3;

    public static GameObject myo;
    ThalmicMyo thalmicMyo;
    // Use this for initialization
    void Start () {
        myo = GameObject.Find("Myo");
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
    }
	
	// Update is called once per frame
	void Update () {
        randomGame();

	}

    public void randomGame()    {
        string newScene = "Error";
        if (thalmicMyo.pose == Pose.Fist)
        {
            int rndGame = Random.Range(1, 4);
            switch (rndGame)
            {
                case 1:
                    Debug.Log(game1);
                    newScene = game1;
                    break;
                case 2:
                    Debug.Log(game1);
                    newScene = game2;
                    break;
                case 3:
                    Debug.Log(game1);
                    newScene = game3;
                    break;
            }
            Application.LoadLevel(newScene);
        }
    }
}
