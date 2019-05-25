using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class s_Level1_2 : MonoBehaviour
{ 

    public GameObject[] Enemies;
    
    
    [SerializeField]
    private float t;
    
    int customSpawn;
    
    public float spawnBorder = 0.8f;
    protected float startX;
    protected float screenHeight;
    
    
    protected Camera cam;
    
    private float startTime;
    
    [SerializeField]
    private int spawnCount = 0;
    
    float startY;
    
    public bool stop = false;
    [SerializeField]
    private float normalSpeed = 1;
    [SerializeField]
    private float normalSpawn = 1;
    [SerializeField]
    private float speedMod = 1;
    [SerializeField]
    private float spawnMod = 1;



// Use this for initialization
void Start()
{
    startTime = Time.time;

    cam = Camera.main;

    screenHeight = 2f * cam.orthographicSize;
    startY = screenHeight / 2 + 50;

    float width = screenHeight * cam.aspect;
    spawnBorder = spawnBorder * (width / 2);

    spawnCount = PlayerPrefs.GetInt("spawnCount", spawnCount);
    PlayerPrefs.SetInt("endgame", 0);

    normalSpeed = 1f;
    normalSpawn = 1f;

    startLevel1();

    

}

// Update is called once per frame
void Update()
{
    t = Time.time - startTime;
}


#region LEVEL

public void startLevel1()
{
        PlayerPrefs.SetInt("endgame", 0);
        StartCoroutine(level1());
}

IEnumerator level1()
{
    stop = false;

        

        switch (spawnCount)
        {
            case 0:
                //tutorial
                break;
            case 1:


                normalSpawn = 1.5f;
                normalSpeed = 0.5f;

                yield return new WaitForSeconds(3f);

                spawner(1, speed: normalSpeed, x:2);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 1);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 2);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 3);


                yield return new WaitForSeconds(3f);
                normalSpawn = 1f;
                normalSpeed = 0.75f;

                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 1);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 3);

                normalSpawn = 0.75f;
                normalSpeed = 0.7f;

                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 1);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 2);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 3);

                yield return new WaitForSeconds(2f);

                normalSpawn = 0.4f;
                normalSpeed = 0.6f;

                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 3);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 2);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 1);

                yield return new WaitForSeconds(2f);
                normalSpawn = 0.3f;
                normalSpeed = 0.5f;

                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 1);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 2);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 1);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 2);
                yield return new WaitForSeconds(normalSpawn);
                spawner(1, speed: normalSpeed, x: 3);

                yield return new WaitForSeconds(5f);
                break;
            case 2:
                normalSpawn = 1.5f;
                normalSpeed = 0.75f;

                spawner(3, speed: normalSpeed, x: 4);
                yield return new WaitForSeconds(normalSpawn);
                spawner(3, speed: normalSpeed, x: 5);

                yield return new WaitForSeconds(2f);

                normalSpawn = 1.25f;
                normalSpeed = 0.85f;

                yield return new WaitForSeconds(normalSpawn);
                spawner(3, speed: normalSpeed, x: 4);
                yield return new WaitForSeconds(normalSpawn);
                spawner(4, speed: normalSpeed, x: 5);
                yield return new WaitForSeconds(normalSpawn);
                spawner(3, speed: normalSpeed, x: 4);
                yield return new WaitForSeconds(normalSpawn);
                spawner(4, speed: normalSpeed, x: 5);

                yield return new WaitForSeconds(2f);

                normalSpawn = 1.0f;
                normalSpeed = 1f;

                yield return new WaitForSeconds(normalSpawn);
                spawner(4, speed: normalSpeed, x: 4);
                yield return new WaitForSeconds(normalSpawn);
                spawner(3, speed: normalSpeed, x: 4);
                yield return new WaitForSeconds(normalSpawn);
                spawner(4, speed: normalSpeed, x: 5);
                yield return new WaitForSeconds(normalSpawn);
                spawner(3, speed: normalSpeed, x: 5);

                yield return new WaitForSeconds(2f);

                normalSpawn = 0.75f;
                normalSpeed = 1.15f;

                yield return new WaitForSeconds(normalSpawn);
                spawner(3, speed: normalSpeed, x: 4);
                yield return new WaitForSeconds(normalSpawn);
                spawner(4, speed: normalSpeed, x: 4);
                yield return new WaitForSeconds(normalSpawn);
                spawner(3, speed: normalSpeed, x: 4);
                yield return new WaitForSeconds(normalSpawn);
                spawner(4, speed: normalSpeed, x: 4);

                yield return new WaitForSeconds(2f);

                normalSpawn = 0.55f;
                normalSpeed = 1.25f;

                yield return new WaitForSeconds(normalSpawn);
                spawner(3, speed: normalSpeed, x: 5);
                yield return new WaitForSeconds(normalSpawn);
                spawner(4, speed: normalSpeed, x: 5);
                yield return new WaitForSeconds(normalSpawn);
                spawner(3, speed: normalSpeed, x: 5);
                yield return new WaitForSeconds(normalSpawn);
                spawner(4, speed: normalSpeed, x: 5);

                yield return new WaitForSeconds(5f);

                break;

            case 99:
                
                break;
            default:
                normalSpawn = 0.5f;
                normalSpeed = 0.50f;
                
                yield return new WaitForSeconds(normalSpawn);
                spawner(1,speed:normalSpeed);
                //spawner(666, speed: 0.25f);
                if (normalSpawn > 0.35f)
                {
                    normalSpawn -= 0.05f;
                    
                }
                if(normalSpeed < 0.6f)
                {
                    normalSpeed += 0.01f;
                }
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




IEnumerator ap_v2_repeater(float speed, int repeats, float waitBehind, float startX = 9999)
{
    

    for (int i = 1; i <= repeats; i++)
    {
        spawner(1, speed: speed, x: startX);
        yield return new WaitForSeconds(waitBehind);
    }
    
}

#endregion






#region SPAWNER


void customSpawner(List<int> types)
{
    int maxRand = types.Count;
    int newRand = UnityEngine.Random.Range(1, maxRand);

    spawner(types[newRand]);
}

//spawntype 666 is random type
//x = 9999 is random position
void spawner(int spawnType, int maxType = 5, int startType = 1, float speed = 1, float x = 9999, string spawnText = "")
{

        //float randomX = UnityEngine.Random.Range(-spawnBorder, spawnBorder);
        float randomX = UnityEngine.Random.Range(1, 4);

    if (x != 9999)
    {
            switch (x)
            {
                //set random position on lanes
                case 1:
                    startX = -140;
                    break;
                case 2:
                    startX = 00;
                    break;
                case 3:
                    startX = 140;
                    break;
                case 4:
                    startX = -70;
                    break;
                case 5:
                    startX = 70;
                    break;
                default:
                    startX = 0;
                    break;
            }
        }
    else
    {
            switch (randomX)
            {
                //set random position on lanes
                case 1:
                    startX = -140;
                    break;
                case 2:
                    startX = 00;
                    break;
                case 3:
                    startX = 140;
                    break;
                case 4:
                    startX = -70;
                    break;
                case 5:
                    startX = 70;
                    break;
                default:
                    startX = 0;
                    break;
            }
    }

    Vector3 startPos = new Vector3(startX, startY, 0);
    Vector3 startPos2_1 = new Vector3(startX - 15f, startY, 0);
    Vector3 startPos2_2 = new Vector3(startX + 15f, startY, 0);
    Vector3 bossPos = new Vector3(-350, 280, -50);


    System.Random spawnID = new System.Random();

    int newSpawn = spawnID.Next(startType, maxType + 1);

    GameObject spawnedEnemy;

    if (startX > 500)
    {
        Debug.Log("how");
    }


    switch (spawnType)
    {
        case 1:
            //normal Virus
            spawnedEnemy = Instantiate(Enemies[0], startPos, new Quaternion());
            setSpeed(speed, spawnedEnemy);
            break;
        case 2:
            //normal Virus side by side
            spawnedEnemy = Instantiate(Enemies[0], startPos2_1, new Quaternion());
            setSpeed(speed, spawnedEnemy);
            spawnedEnemy = Instantiate(Enemies[0], startPos2_2, new Quaternion());
            setSpeed(speed, spawnedEnemy);
            break;
        case 3:
            //swaying Virus
            spawnedEnemy = Instantiate(Enemies[1], startPos, new Quaternion());
            setSpeed(speed, spawnedEnemy);
            break;
        case 4:
            //swaying other direction Virus
            spawnedEnemy = Instantiate(Enemies[2], startPos, new Quaternion());
            setSpeed(speed, spawnedEnemy);

            //GameObject mySprite = spawnedEnemy.transform.GetChild(0).gameObject;
            //mySprite.GetComponent<virusParent>().spawnText("You can Shoot me btw");

            break;
        case 5:
            //2 bikes splitting up
            spawnedEnemy = Instantiate(Enemies[3], startPos, new Quaternion());
            setSpeed(speed, spawnedEnemy);

            break;
        case 6:

        case 666:
            spawner(newSpawn, maxType, startType, speed);
            break;
    }

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
    parentObject.GetComponent<virusParent>().setSpeed(speed);
    //GameObject test = parentObject;
}


#endregion


}
