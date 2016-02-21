using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class Shooter : MonoBehaviour
{
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    GameObject myo;
    ThalmicMyo thalmicMyo;
    float speed = 0.3f;
    int time, score;

    void Awake()
    {
        myo = GameObject.Find("Myo");
    }

    void Start()
    {
        time = 10;
        score = 0;
        transform.position = new Vector3(0, 0);
        StartCoroutine(GameTimer());
    }

    void Update()
    {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        if(thalmicMyo.pose == Pose.FingersSpread)
        {
            transform.position = new Vector3(0, 0);
        }
        Debug.Log(thalmicMyo.gyroscope);
        transform.Translate(new Vector3(thalmicMyo.gyroscope.x * Time.deltaTime * speed, thalmicMyo.gyroscope.y * Time.deltaTime * speed));

        if (time <= 0)
        {
            Destroy(myo.transform.parent.gameObject);
            Application.LoadLevel("Menu");
        }
            
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (thalmicMyo.pose == Pose.Fist)
        {
            Game.addPoints(100);
            GameObject newO = (GameObject)Instantiate(c.gameObject);
            newO.transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-2f, 3.5f));
            Destroy(c.gameObject);
            score += 100;
        }
    }

    IEnumerator GameTimer()
    {
        while (true)
        {
            time--;
            yield return new WaitForSeconds(1f);
        }
    }

    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(20, 20, 100, 20), "Time: " + time + ":00");
        GUI.Label(new Rect(20, 50, 100, 20), "Score: " + score);
    }

}