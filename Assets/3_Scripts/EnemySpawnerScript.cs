using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {
	public GameObject Virus1;
    public GameObject Virus1_2;
    public GameObject Virus2;
    public GameObject Boss1;
    public GameObject DecreaseScore;

    //Spawnrate in seconds, 2 = every 2 second
    public float spawnrate;

    // - for old random spawner
    public float spawnrate_max; 
    public bool getFaster = true;
    // - /

    //[SerializeField]
    //private bool rSpawner = false;
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

    [SerializeField]
    protected Camera cam;

    private float startTime;
    [SerializeField]
    private int skipTime = 0;

    private static float init_spawnrate;

    [SerializeField]
    private int spawnCount = 0;

    float startY;

    public bool stop = false;

    public float normalSpeed = 1;
    public float normalSpawn = 1;
    public float speedMod = 1;
    public float spawnMod = 1;


    // Use this for initialization
    void Start () {
        startTime = Time.time;
        init_spawnrate = spawnrate;

        screenHeight = 2f * cam.orthographicSize;
        startY = screenHeight / 2;

        float width = screenHeight * cam.aspect;
        spawnBorder = spawnBorder * (width / 2);

        setAwake(0);

        //second value is default
        skipTime = PlayerPrefs.GetInt("skipTime", skipTime);
        spawnCount = PlayerPrefs.GetInt("spawnCount", spawnCount); 

        switch (level)
        {
            case 1:
                StartCoroutine(level1());
                break;
            case 2:

                break;
        }
    }
	
	// Update is called once per frame
	void Update () {

        t = Time.time - startTime + skipTime;

        displayScore();

        //calculateawake();

        displayawake();

        spawn = SpawnTimer();
        
        

	}


    /* 
     * 
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

    */
    

    #region LEVEL

    public void startLevel1()
    {
        StartCoroutine(level1());
    }
    
    IEnumerator level1()
    {
        stop = false;
        setAwake(spawnCount);

        float spawnBehind;
        float tempSpeed;

        switch (spawnCount)
        {
            case 0:
                // yield return StartCoroutine (tutorial) 
                //stop = true;
                yield return new WaitForSeconds(1.5f);
                spawner(1, speed: 0.6f, x:0);
                yield return new WaitForSeconds(2.5f);
                spawner(1, speed: 0.6f);
                yield return new WaitForSeconds(2.0f);
                spawner(1, speed: 0.7f);
                yield return new WaitForSeconds(1.4f);
                spawner(1, speed: 0.7f);
                yield return new WaitForSeconds(1.3f);
                spawner(1, speed: 0.8f);
                yield return new WaitForSeconds(1.0f);
                spawner(1, speed: 0.8f);
                break;

            case 1:
                tempSpeed = 0.6f;
                spawnBehind = 0.3f;

                yield return new WaitForSeconds(3);
                spawner(1, speed: tempSpeed, x: -200);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: -200);

                yield return new WaitForSeconds(1f);
                spawner(1, speed: tempSpeed, x: -100);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: -100);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: -100);

                yield return new WaitForSeconds(1f);
                spawner(1, speed: tempSpeed, x: 0);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 0);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 0);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 0);

                yield return new WaitForSeconds(1f);
                spawner(1, speed: tempSpeed, x: 100);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 100);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 100);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 100);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 100);


                yield return new WaitForSeconds(1f);
                spawner(1, speed: tempSpeed, x: 200);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 200);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 200);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 200);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 200);
                yield return new WaitForSeconds(spawnBehind);
                spawner(1, speed: tempSpeed, x: 200);



                break;

            case 2:
                yield return new WaitForSeconds(2.5f);
                spawner(1, speed: 0.7f,x:0);
                yield return new WaitForSeconds(0.25f);
                spawner(1, speed: 0.7f,x:0);
                yield return new WaitForSeconds(0.25f);
                spawner(1, speed: 0.7f, x: 0);

                spawner(5, speed: 0.5f);

                break;
            case 3:
                yield return new WaitForSeconds(2.5f);
                spawner(1, speed: 0.8f, x: 100);
                yield return new WaitForSeconds(0.3f);
                spawner(1, speed: 0.8f, x: 100);
                yield return new WaitForSeconds(0.3f);
                spawner(1, speed: 0.8f, x: 100);
                yield return new WaitForSeconds(0.3f);
                spawner(1, speed: 0.8f, x: 100);
                break;
            case 4:
                yield return new WaitForSeconds(3f);
                spawner(2, speed: 0.8f, x: 0);
                yield return new WaitForSeconds(0.5f);
                spawner(1, speed: 1.2f, x: 0);
                break;
            case 5:
                yield return new WaitForSeconds(2f);
                spawner(1, speed: 0.5f, x: 50);
                yield return new WaitForSeconds(0.2f);
                spawner(1, speed: 0.5f, x: -50);
                yield return new WaitForSeconds(0.2f);
                spawner(1, speed: 0.5f, x: 100);
                yield return new WaitForSeconds(0.2f);
                spawner(1, speed: 0.5f, x: -100);
                break;
            case 6:
                yield return new WaitForSeconds(3f);
                spawner(2, speed: 0.8f, x: 0);
                yield return new WaitForSeconds(0.2f);
                spawner(1, speed: 0.5f, x: 50);
                spawner(1, speed: 0.5f, x: -50);
                yield return new WaitForSeconds(2f);
                spawner(4, speed: 0.5f);
                break;
            case 7:
                yield return new WaitForSeconds(2f);
                spawner(5, speed: 0.5f, x: -50);
                break;
            case 8:
                yield return new WaitForSeconds(3f);
                break;
            case int spawnCount when (spawnCount > 8):
                yield return new WaitForSeconds(0.8f);
                float ranSpeed = UnityEngine.Random.Range(0.5f,1.2f);
                spawner(666,speed: ranSpeed);
                break;

        }

        spawnCount++;
        //yield return new WaitForSeconds(1);
        if (!stop)
        {
            StartCoroutine(level1());
        }
    }

    IEnumerator tutorial1()
    {
        yield return null;
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

    //spawntype 666 is random type

    void spawner(int spawnType, int maxType = 5, int startType = 1, float speed = 1, float x = 9999, string spawnText = "")
    {

        float randomX = UnityEngine.Random.Range(-spawnBorder, spawnBorder);
        

        if (x != 9999)
        {
            startX = x;
        }
        else
        {
            startX = randomX;
        }

        Vector3 startPos = new Vector3(startX, startY, 0);
        Vector3 startPos2_1 = new Vector3(startX - 15f, startY, 0);
        Vector3 startPos2_2 = new Vector3(startX + 15f, startY, 0);
        Vector3 bossPos = new Vector3(-350, 280, -50);


        System.Random spawnID = new System.Random();

        int newSpawn = spawnID.Next(startType, maxType+1);

        GameObject spawnedEnemy;


        switch (spawnType)
        {
            case 1:
                //normal Virus
                spawnedEnemy = Instantiate(Virus1, startPos, new Quaternion());
                setSpeed(speed, spawnedEnemy);
                break;
            case 2:
                //normal Virus side by side
                spawnedEnemy = Instantiate(Virus1, startPos2_1, new Quaternion());
                setSpeed(speed, spawnedEnemy);
                spawnedEnemy = Instantiate(Virus1, startPos2_2, new Quaternion());
                setSpeed(speed, spawnedEnemy);
                break;
            case 3:
                //swaying Virus
                spawnedEnemy = Instantiate(Virus1_2, startPos, new Quaternion());
                setSpeed(speed, spawnedEnemy);
                break;
            case 4:
                //Shootable Virus
                spawnedEnemy = Instantiate(Virus2, startPos, new Quaternion());
                setSpeed(speed, spawnedEnemy);

                //GameObject mySprite = spawnedEnemy.transform.GetChild(0).gameObject;
                //mySprite.GetComponent<virusParent>().spawnText("You can Shoot me btw");

                break;
            case 5:
                spawnedEnemy = Instantiate(Boss1, bossPos, new Quaternion());
                setSpeed(speed, spawnedEnemy);
                stop = true;
                break;
            case 666:
                    spawner(newSpawn, maxType, startType, speed);
                break;
        }

        

        //counter = 0;
        increaseScore(10);
    }

    void setHint(GameObject go)
    {
        GameObject spriteObject = go.transform.GetChild(0).gameObject;
        if (spriteObject != null)
        {
            if (spriteObject.GetComponent("s_attachText") != null)
            {

            }
        }
    }
    /*
    void setSpeed(float speed, GameObject parentObject)
    {
	// You can check with parentObject.?tranform.? etc. and then if == null -> Fehlermeldung
        GameObject childObj = parentObject.transform?.GetChild(0)?.gameObject;

        if(childObj != null)
        {
            //childObj.GetComponent<virusParent>().setSpeed(speed);
        }
        
    }
    */

    void setSpeed(float speed, GameObject parentObject)
    {

       //  parentObject.GetComponent("virusParentDirect").setSpeed(speed);
        //parentObject.GetComponent<virusParentDirect>().setSpeedDirect(speed);
         GameObject test = parentObject;
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
