﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    GameObject level;
    MenuManager MenuManager;
    public GameObject repeatUI;
    ParticleSystem PaSys;
    [SerializeField]
    GameObject health1;
    [SerializeField]
    GameObject health2;


    private int health = 3;

    private void Start()
    {
        MenuManager = GameObject.Find("Level1").GetComponent<MenuManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.tag == "enemy" || col.gameObject.tag == "enemyWallImmune")
        {
            
            Destroy(col.gameObject);

            if (health == 3)
            {
                health1.SetActive(false);

            }
            if (health == 2)
            {
                health2.SetActive(false);

            }
            if (health <= 1)
            {
                int bossState = PlayerPrefs.GetInt("endgame");
                if (bossState == 0)
                {
                    MenuManager.LoadMenu();
                }
                else
                {
                        Time.timeScale = 0;
                    //TODO Destroy all rats
                    //SrepeatUI.enabled = true;
                    repeatUI.SetActive(true);
                    health1.SetActive(true);
                    health2.SetActive(true);
                    health = 4;
                }
                
            }
            

            health--;
        }



    }
}
