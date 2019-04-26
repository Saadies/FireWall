using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemySpawnerScript : MonoBehaviour {
	public GameObject Virus1;
    public GameObject Virus2;
    public GameObject DecreaseScore;
    public float spawnrate;
    public float spawnrate_max; 
    public bool getFaster = true;
    [SerializeField]
    private bool rSpawner = false;
    [SerializeField]
    private bool spawn = false;
    [SerializeField]
    private float t;

    [SerializeField]
    private int level = 1;

    int customSpawn;

    float counter = 0;

   // public TextMeshProUGUI scoreText;
    public TextMeshProUGUI awakeText;

    private int score = 0;
    public float awake = 0f;

    public float spawnBorder = 0.8f;
    protected float startX;
    protected float screenHeight;

    protected Camera cam;

    private float startTime;
    [SerializeField]
    private float skipTime;

    private static float init_spawnrate;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        init_spawnrate = spawnrate;

        cam = Camera.main;
        screenHeight = 2f * cam.orthographicSize;
        float width = screenHeight * cam.aspect;
        spawnBorder = spawnBorder * (width / 2);

        setAwake(0);
    }
	
	// Update is called once per frame
	void Update () {

        t = Time.time - startTime + skipTime;

        displayScore();

        //calculateawake();

        displayawake();

        spawn = SpawnTimer();
        switch (level){
            case 1:
                level1(t);
                break;
            case 2:

                break;
        }
        

	}



    bool RspawnerActive(bool active, int spawnType, int maxType, int startType = 1)
    {
        if (active == true){
            spawner(spawnType,maxType,startType);
            rSpawner = true;
        }
        else
        {
            rSpawner = false;
        }
        return rSpawner;
    }

    #region LEVEL

    void level1(float time)
    {
        

        if (spawn){
            if (time <= 10)
            {
                spawnrate = 1f;
                spawner(1);
            }
            else if (time > 10 && time < 20)
            {
                spawnrate = 0.95f;
                spawner(1);
            }
            else if (time > 20 && time < 30)
            {
                spawnrate = 0.90f;
                spawner(1);
            }
            else if (time > 30 && time < 40)
            {
                spawnrate = 0.85f;
                spawner(1);
            }
            else if (time > 40 && time < 50)
            {
                spawnrate = 0.80f;
                spawner(1);
            }
            else if (time > 50 && time < 80)
            {
                spawnrate = 0.75f;
                spawner(1);
            }
            else if (time > 80 && time < 100)
            {
                setAwake(5);
                spawnrate = 1f;
                spawner(2);
            }
            else if (time > 100 && time < 120)
            {
                spawnrate = 0.8f;
                spawner(2);
            }
            else if (time > 120 && time < 130)
            {
                setAwake(10);
                spawnrate = 0.9f;
                spawner(666, 3, 1);
            }
            else if (time > 130 && time < 150)
            {
                spawnrate = 0.8f;
                spawner(666, 3, 1);
            }
            else if (time > 150 && time < 170)
            {
                setAwake(15);
                spawnrate = 1f;
                spawner(3);
            }
            else if (time > 170 && time < 190)
            {
                spawnrate = 0.9f;
                spawner(3);
            }
            else if (time > 190 && time < 220)
            {
                setAwake(20);
                spawnrate = 0.9f;
                customSpawner(new List<int>() {1,3});
            }
            else if (time > 220 && time < 230)
            {
                spawnrate = 0.8f;
                customSpawner(new List<int>() { 1, 3 });
            }
            else if (time > 230 && time < 250)
            {
                setAwake(25);
                spawnrate = 1f;
                spawner(666, 4, 1);
            }
            else if (time > 250 && time < 270)
            {
                spawnrate = 0.9f;
                spawner(666, 4, 1);
            }
            else if (time > 270 && time < 290)
            {
                spawnrate = 0.8f;
                spawner(666, 4, 1);
            }
            else if (time > 290)
            {
                setAwake(30);
                spawnrate = 0.7f;
                spawner(666, 4, 1);
            }
        }
        

    }

    #endregion





    #region ATTACK_PATTERNS



    #endregion





    #region SPAWNER


    void customSpawner(List<int> types)
    {
        int maxRand = types.Count;
        int newRand = UnityEngine.Random.Range(1,maxRand);

        spawner(types[newRand]);
    }

    void spawner(int spawnType, int maxType = 4, int startType = 1)
    {
            float randomX = UnityEngine.Random.Range(-spawnBorder, spawnBorder);
            startX = randomX;

            float startY = screenHeight / 2;

            Vector3 startPos = new Vector3(startX, startY, 0);
            Vector3 startPos2_1 = new Vector3(startX - 15f, startY, 0);
            Vector3 startPos2_2 = new Vector3(startX + 15f, startY, 0);


            System.Random spawnID = new System.Random();

            int newSpawn = spawnID.Next(startType, maxType);

            switch (spawnType)
            {
                case 1:
                    Instantiate(Virus1, startPos, new Quaternion());
                    break;
                case 2:
                    Instantiate(Virus1, startPos2_1, new Quaternion());
                    Instantiate(Virus1, startPos2_2, new Quaternion());
                    break;
                case 3:
                    Instantiate(Virus2, startPos, new Quaternion());
                    break;
                case 666:
                        spawner(newSpawn, maxType, startType);
                    break;
            }

            //counter = 0;
            increaseScore(10);
    }

    bool SpawnTimer()
    {
        if (counter >= spawnrate)
        {
            counter = 0;

            return true;
        }
        else
        {
            if (!getFaster)
            {
                counter += Time.deltaTime;
            }
            else
            {
                counter += Time.deltaTime;

                if (spawnrate > spawnrate_max)
                {
                    spawnrate -= 0.01f;
                }
            }

            return false;
        }
    }

    #endregion



    public void increaseScore(int add)
    {
        score += add;
    }

    public void decreaseScore(int remove)
    {
        score -= 1000;
        Instantiate(DecreaseScore, GameObject.FindGameObjectWithTag("Canvas").transform);
    }

    public void setAwake(int status)
    {
        awake = status;
    }



    void displayScore()
    {
       // scoreText.SetText("Score: " + score);
    }

    void displayawake()
    {
        awakeText.SetText("Awake: " + awake + "%");
    }
}
