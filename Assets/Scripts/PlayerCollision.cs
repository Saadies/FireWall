using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    GameObject level;
    EnemySpawnerScript ESscript;
    ParticleSystem PaSys;


    private int health = 3;

    private void Start()
    {
        PaSys = gameObject.GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "enemy")
        {
            level = GameObject.Find("LevelManager");
            ESscript = level.GetComponent<EnemySpawnerScript>();
            ESscript.decreaseScore(1000);
            
            Destroy(col.gameObject);
            health--;

            var emission = PaSys.emission;
            emission.rateOverTime = 10f;

            if (health == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }



    }
}
