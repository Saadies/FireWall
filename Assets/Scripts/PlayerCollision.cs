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
    [SerializeField]
    GameObject face;


    private int health = 3;

    private void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "enemy" || col.gameObject.tag == "enemyWallImmune")
        {
            level = GameObject.Find("LevelManager");
            ESscript = level.GetComponent<EnemySpawnerScript>();
            ESscript.decreaseScore(1000);
            
            Destroy(col.gameObject);

            if (health == 3)
            {
                Destroy(health1);
                face.GetComponent<facesScript>().surpriseLeft();
            }
            if (health == 2)
            {
                Destroy(health2);
                face.GetComponent<facesScript>().surpriseRight();
            }
            if (health <= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            

            health--;
        }



    }
}
