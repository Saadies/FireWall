﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus1BuddyScript : MonoBehaviour{
    public float radius;
    public float speed;
    public float spawnBorder = 0.8f;
    protected float startX;
    protected float screenHeight;

    private GameObject target;
    // Use this for initialization
    void Start()
    {
        Camera cam = Camera.main;
        screenHeight = 2f * cam.orthographicSize;
        float width = screenHeight * cam.aspect;

        spawnBorder = spawnBorder * (width / 2);
        //spawnBorder in percent , ie 0.9 -> 90% of screen swidth

        float randomX = Random.Range(-spawnBorder, spawnBorder);
        startX = randomX;

        //Vector2 randomPos = new Vector2 (randomX, screenHeight);
        //this.transform.position = randomPos;
        //target = GameObject.Find ("Player");

        Object.Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {


        //float step = speed * Time.deltaTime;

        //this.transform.position = Vector2.MoveTowards (this.transform.position, new Vector2(startX,-screenHeight), step);
    }

    void OnDestroy()
    {
        Object.Destroy(transform.parent.gameObject);
    }
}
