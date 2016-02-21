using UnityEngine;
using System.Collections;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;


public class MFalcon : MonoBehaviour {

    GameObject myo;
    public GameObject[] asteroid =  new GameObject[5];
    float speed = 8.0f;
    bool isright;
    int time, score;
    ThalmicMyo thalmicMyo;
    public string scene1;
    public string scene2;
    public string scene3;



    void Awake()
    {
        myo = GameObject.Find("Myo");
    }
    void Start () {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        isright = thalmicMyo.arm == Thalmic.Myo.Arm.Right;
        StartCoroutine(CreateAsteroid());
        StartCoroutine(GameTimer());
        time = 10;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        thalmicMyo = myo.GetComponent<ThalmicMyo>();
        float movement;

        if (thalmicMyo.pose == Pose.WaveIn)
        {
            movement = -1 * speed * Time.deltaTime;
        }else if (thalmicMyo.pose == Pose.WaveOut)
        {
            movement = speed * Time.deltaTime;
        }

        else
        {
            movement = 0;
        }

        if (!isright)
            movement *= -1;

        
        transform.Translate(new Vector3(movement, 0));

        if(time <= 0)
        {
            Destroy(myo.transform.parent.gameObject);
            Application.LoadLevel("Menu");
        }
    }


    IEnumerator CreateAsteroid()
    {
        while (true)
        {
            float x = Random.Range(-6, 6);
            int a = Random.Range(0, 5);
            GameObject ast = (GameObject) Instantiate(asteroid[a]);
            ast.transform.position = new Vector3(x, 6);

            yield return new WaitForSeconds(1f);

        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        Destroy(c.gameObject);
        score -= 50;
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 100, 20), "Time: " + time + ":00");
        GUI.Label(new Rect(20, 50, 100, 20), "Score: " + score);
    }

    IEnumerator GameTimer()
    {
        while(true)
        {
            Debug.Log("Time =" +time);
            Debug.Log("Score =" + score);
            time--;
            score += 100;
            yield return new WaitForSeconds(1f);
        }
    }

  /*  public void randomGame()
    {
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
    }*/
}
