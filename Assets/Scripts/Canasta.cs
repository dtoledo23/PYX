using UnityEngine;
using System.Collections;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class Canasta : MonoBehaviour {

    GameObject myo;
    ThalmicMyo thalmicMyo;
    static int score, time;

    // Use this for initialization
    void Start () {
        myo = GameObject.Find("Myo");
        score = 0;
        time = 20;
        StartCoroutine(GameTimer());
	}
	
	// Update is called once per frame
	void Update () {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
    }

    void OnTriggerStay2D(Collider2D c)
    {
        string name = c.gameObject.name;
        //Debug.Log(name);
        if (name.Equals("Manzana(Clone)"))
        {
            
           if(thalmicMyo.pose == Pose.DoubleTap)
            {
                Destroy(c.gameObject);
                score += 100;

            }
        }else if(name.Equals("Naranja(Clone)"))
        {
            if (thalmicMyo.pose == Pose.Fist)
            {
                Destroy(c.gameObject);
                score += 100;
            }
        } else if(name.Equals("Banana(Clone)"))
        {
            if (thalmicMyo.pose == Pose.FingersSpread)
            {
                Destroy(c.gameObject);
                score += 100;
            }
        }

        if (time <= 0)
        {
            Destroy(myo.transform.parent.gameObject);
            Application.LoadLevel("Menu");
        }
           
    }

    void OnTriggerExit(Collider c)
    {
        Destroy(c.gameObject);
    }

    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(20, 20, 100, 20), "Time: " + time + ":00");
        GUI.Label(new Rect(20, 50, 100, 20), "Score: " + score);
    }

    IEnumerator GameTimer()
    {
        while (true)
        {
            time--;
            yield return new WaitForSeconds(1f);
        }
    }
}
