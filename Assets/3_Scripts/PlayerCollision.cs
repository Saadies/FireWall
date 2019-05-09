using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    GameObject level;
    EnemySpawnerScript ESscript;
    ParticleSystem PaSys;
    [SerializeField]
    GameObject health1;
    [SerializeField]
    GameObject health2;


    private int health = 3;

    private void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "enemy" || col.gameObject.tag == "enemyWallImmune")
        {
            
            Destroy(col.gameObject);

            if (health == 3)
            {
                Destroy(health1);

            }
            if (health == 2)
            {
                Destroy(health2);

            }
            if (health <= 1)
            {
                SceneManager.LoadScene("StarMenu");
            }
            

            health--;
        }



    }
}
