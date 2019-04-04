﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus1Script : MonoBehaviour {
	public float radius;
	public float speed;
    public float spawnBorder = 0.1f;
    protected float startX;
    protected float screenHeight;
    
    private GameObject target;
	// Use this for initialization
	void Start () {
        Camera cam = Camera.main;
        screenHeight = 2f * cam.orthographicSize;
        float width = screenHeight * cam.aspect;
        float Border = width * spawnBorder;

        float randomX = Random.Range((-width + Border) / 2, (width - Border) / 2);
        startX = randomX;

        float startY = screenHeight;
		Vector2 randomPos = new Vector2 (randomX, screenHeight);
		this.transform.position = randomPos;
		target = GameObject.Find ("Player");

        Object.Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;

		this.transform.position = Vector2.MoveTowards (this.transform.position, new Vector2(startX,-screenHeight), step);
	}
}

/* Circle Spawner
    public float angleMin = 0.1f;
    public float angleMax = 0.4f;

 	void Start () {
		float angle = Random.Range(angleMin,angleMax) * (Mathf.PI * 2);
		float randomX = Mathf.Cos (angle) * radius;
		float randomY = Mathf.Sin (angle) * radius;
		Vector2 randomPos = new Vector2 (randomX, randomY);
		this.transform.position = randomPos;
		target = GameObject.Find ("Player");
        Object.Destroy(gameObject, 5f);
	}
*/