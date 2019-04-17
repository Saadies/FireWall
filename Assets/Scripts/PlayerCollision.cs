using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameObject level;
    EnemySpawnerScript ESscript;

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "enemy")
        {
            level = GameObject.Find("LevelManager");
            ESscript = level.GetComponent<EnemySpawnerScript>();
            ESscript.decreaseScore(1000);

            Destroy(col.gameObject);

        }
    }
}
