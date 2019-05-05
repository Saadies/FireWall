using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter1Script : MonoBehaviour
{
    GameObject level;
    EnemySpawnerScript ESscript;


    private float startTime;

    public float spawnrate;
    private float counter;
    private Vector3 childPos;

    public GameObject virus1;


    // Use this for initialization
    void Start()
    {
        Object.Destroy(gameObject, 120f);

        level = GameObject.Find("LevelManager");
        ESscript = level.GetComponent<EnemySpawnerScript>();

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        childPos = this.transform.GetChild(0).transform.position;
        childPos.z = this.transform.position.z + 10;
        childPos.x += 10;

        if (counter >= spawnrate)
        {
            counter = 0;
            Instantiate(virus1,childPos, new Quaternion());
        }
        else
        {     
            counter += Time.deltaTime;
        }

    }

    void OnDestroy()
    {
        ESscript.startLevel1();
    }
}
