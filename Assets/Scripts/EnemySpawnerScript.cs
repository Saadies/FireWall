using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawnerScript : MonoBehaviour {
	public GameObject Virus1;
	public float spawnrate = 100f;
    public float spawnrate_max = 20; 
    public bool getFaster = true;
	float counter = 0;

    public TextMeshProUGUI scoreText;
    private int score = 0;

    private float startTime;

    public void increaseScore(int add)
    {
        score += add;
    }

    void displayScore()
    {
        scoreText.SetText("Score: " + score);
    }

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        

        float t = Time.time - startTime;

        displayScore();

        switch (t)
        {
            case 1.5f:
                Instantiate(Virus1);
                break;
            case 2.5f:
                Instantiate(Virus1);
                Instantiate(Virus1);
                break;
            default:
                break;

        }

		if (counter >= spawnrate) {
			Instantiate (Virus1);
			counter = 0;
            increaseScore(10);
		} else {
            if (!getFaster){
                counter++;
            }
            else{
                counter++;
                if (spawnrate > spawnrate_max)
                {
                    spawnrate -= 0.01f;
                }
            }
        }
	}
}
