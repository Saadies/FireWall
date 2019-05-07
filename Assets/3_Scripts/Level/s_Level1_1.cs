﻿using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class s_Level1_1 : MonoBehaviour
{ 

    public GameObject[] Enemies;
    
    
    [SerializeField]
    private float t;
    
    int customSpawn;
    
    public float spawnBorder = 0.8f;
    protected float startX;
    protected float screenHeight;
    
    [SerializeField]
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

    screenHeight = 2f * cam.orthographicSize;
    startY = screenHeight / 2;

    float width = screenHeight * cam.aspect;
    spawnBorder = spawnBorder * (width / 2);

    spawnCount = PlayerPrefs.GetInt("spawnCount", spawnCount);
    PlayerPrefs.SetInt("endgame", 0);


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
    StartCoroutine(level1());
}

IEnumerator level1()
{
    stop = false;

    float spawnBehind;
    float tempSpeed;

        switch (spawnCount)
        {
            case 0:
                // yield return StartCoroutine (tutorial) 
                //stop = true;
                yield return new WaitForSeconds(1.5f);
                spawner(1, speed: 0.6f, x: 0);
                yield return new WaitForSeconds(5f);
                spawner(1, speed: 0.6f);
                yield return new WaitForSeconds(5.0f);
                spawner(1, speed: 0.6f);
                yield return new WaitForSeconds(3.0f);
                spawner(1, speed: 0.6f);
                yield return new WaitForSeconds(2.5f);
                spawner(1, speed: 0.6f);
                yield return new WaitForSeconds(2.0f);
                spawner(1, speed: 0.7f);
                yield return new WaitForSeconds(1.5f);
                spawner(1, speed: 0.8f);
                yield return new WaitForSeconds(1.0f);
                spawner(1, speed: 0.9f);
                break;

            case 1:

                yield return new WaitForSeconds(3);

                yield return StartCoroutine(ap_v1_repeatLine(0.6f));

                break;

            case 2:
                tempSpeed = 1f;

                yield return new WaitForSeconds(3f);
                spawner(2, speed: tempSpeed, x: 0);
                yield return new WaitForSeconds(1f);
                spawner(2, speed: tempSpeed, x: -100);
                yield return new WaitForSeconds(1f);
                spawner(2, speed: tempSpeed, x: 100);

                break;
            case 3:
                tempSpeed = 1.25f;

                yield return new WaitForSeconds(2f);
                spawner(2, speed: tempSpeed, x: 100);
                yield return new WaitForSeconds(1f);
                spawner(2, speed: tempSpeed, x: 0);
                yield return new WaitForSeconds(1f);
                spawner(2, speed: tempSpeed, x: -100);
                break;
            case 4:
                yield return new WaitForSeconds(3f);
                spawner(3, speed: 0.5f, x: 0);

                yield return new WaitForSeconds(1.0f);
                spawner(3, speed: 0.75f);

                yield return new WaitForSeconds(1.0f);
                spawner(3, speed: 1.0f);

                break;
            case 5:
                yield return new WaitForSeconds(3f);
                spawner(5, speed: 1f);
                break;
            case 6:
                yield return new WaitForSeconds(3f);
                spawner(4, speed: 1f, x: 0);
                yield return new WaitForSeconds(1f);
                spawner(4, speed: 1f, x: -100);
                yield return new WaitForSeconds(1f);
                spawner(4, speed: 1f, x: 100);

                break;
            case 7:
                spawnBehind = 0.6f;
                yield return new WaitForSeconds(3f);
                spawner(4, speed: 1f, x: 0);
                yield return new WaitForSeconds(spawnBehind);
                spawner(4, speed: 1f, x: 0);
                yield return new WaitForSeconds(spawnBehind);
                spawner(4, speed: 1f, x: 0);
                yield return new WaitForSeconds(spawnBehind);
                spawner(4, speed: 1f, x: 0);
                yield return new WaitForSeconds(spawnBehind);
                spawner(4, speed: 1f, x: 0);
                break;
            case 8:
                spawnBehind = 0.3f;
                tempSpeed = 0.5f;
                yield return new WaitForSeconds(3f);
                yield return StartCoroutine(ap_v2_line(0.5f));
                yield return new WaitForSeconds(6f);
                break;
            case 9:
                yield return StartCoroutine(ap_v2_line(0.5f));
                yield return new WaitForSeconds(1f);
                yield return StartCoroutine(ap_v2_line(0.5f));
                yield return new WaitForSeconds(6f);
                break;
            case 10:
                yield return StartCoroutine(ap_v2_line(0.5f));
                yield return new WaitForSeconds(1f);
                yield return StartCoroutine(ap_v2_line(0.5f));
                yield return new WaitForSeconds(1f);
                yield return StartCoroutine(ap_v2_line(0.5f));
                yield return new WaitForSeconds(6f);
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

IEnumerator ap_v1_repeatLine(float speed)
{
    float spawnBehind = speed / 2;


    yield return new WaitForSeconds(1f);
    spawner(1, speed: speed, x: -100);
    yield return new WaitForSeconds(spawnBehind);
    spawner(1, speed: speed, x: -100);
    yield return new WaitForSeconds(spawnBehind);
    spawner(1, speed: speed, x: -100);

    yield return new WaitForSeconds(1f);
    spawner(1, speed: speed, x: 0);
    yield return new WaitForSeconds(spawnBehind);
    spawner(1, speed: speed, x: 0);
    yield return new WaitForSeconds(spawnBehind);
    spawner(1, speed: speed, x: 0);
    yield return new WaitForSeconds(spawnBehind);
    spawner(1, speed: speed, x: 0);

    yield return new WaitForSeconds(1f);
    spawner(1, speed: speed, x: 100);
    yield return new WaitForSeconds(spawnBehind);
    spawner(1, speed: speed, x: 100);
    yield return new WaitForSeconds(spawnBehind);
    spawner(1, speed: speed, x: 100);
    yield return new WaitForSeconds(spawnBehind);
    spawner(1, speed: speed, x: 100);
    yield return new WaitForSeconds(spawnBehind);
    spawner(1, speed: speed, x: 100);


}

IEnumerator ap_v2_line(float speed)
{
    spawner(4, speed: speed, x: -200);

    spawner(4, speed: speed, x: -100);

    spawner(4, speed: speed, x: 0);

    spawner(4, speed: speed, x: 100);

    spawner(4, speed: speed, x: 200);

    yield return null;
}

IEnumerator ap_v1_repeater(float speed, int repeats, float waitBehind, float startX = 9999)
{
    if (startX != 9999)
    {
        startX = UnityEngine.Random.Range(-spawnBorder, spawnBorder);
    }

    for (int i = 1; i <= repeats; i++)
    {
        spawner(1, speed: speed, x: startX);
        yield return new WaitForSeconds(waitBehind);
        i++;
    }

}

IEnumerator ap_v1_1_repeater(float speed, int repeats, float waitBehind, float startX = 9999)
{
    if (startX != 9999)
    {
        startX = UnityEngine.Random.Range(-spawnBorder, spawnBorder);
    }

    for (int i = 1; i <= repeats; i++)
    {
        spawner(2, speed: speed, x: startX);
        yield return new WaitForSeconds(waitBehind);
    }

}

IEnumerator ap_v1_2_repeater(float speed, int repeats, float waitBehind, float startX = 9999)
{
    if (startX != 9999)
    {
        startX = UnityEngine.Random.Range(-spawnBorder, spawnBorder);
    }

    for (int i = 1; i <= repeats; i++)
    {
        spawner(3, speed: speed, x: startX);
        yield return new WaitForSeconds(waitBehind);
    }

}

IEnumerator ap_v2_repeater(float speed, int repeats, float waitBehind, float startX = 9999)
{
    if (startX != 9999)
    {
        startX = UnityEngine.Random.Range(-spawnBorder, spawnBorder);
    }

    for (int i = 1; i <= repeats; i++)
    {
        spawner(4, speed: speed, x: startX);
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
            //Shootable Virus
            spawnedEnemy = Instantiate(Enemies[2], startPos, new Quaternion());
            setSpeed(speed, spawnedEnemy);

            //GameObject mySprite = spawnedEnemy.transform.GetChild(0).gameObject;
            //mySprite.GetComponent<virusParent>().spawnText("You can Shoot me btw");

            break;
        case 5:
            spawnedEnemy = Instantiate(Enemies[3], bossPos, new Quaternion());
            setSpeed(speed, spawnedEnemy);
            stop = true;
            break;
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