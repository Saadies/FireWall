using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
	public GameObject Virus1;
	public float spawnrate = 100f;
    public bool getFaster = true;
	float counter = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (counter >= spawnrate) {
			Instantiate (Virus1);
			counter = 0;
		} else {
            if (!getFaster){
                counter++;
            }
            else{
                counter++;
                if (spawnrate > 1){
                    spawnrate -= 0.01f;
                }
            }
        }
	}
}
