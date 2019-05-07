using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineCollision : MonoBehaviour
{

    GameObject level;
    EnemySpawnerScript ESscript;

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "enemy")
        {
            level = GameObject.Find("LevelManager");

            if (SceneManager.GetActiveScene().name == "BasicGameplay")
            {
                ESscript = level.GetComponent<EnemySpawnerScript>();
                ESscript.increaseScore(100);
            }
            Destroy(col.gameObject);
            
        }
    }
}
