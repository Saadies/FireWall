using System;
using UnityEngine;
using TMPro;

public class EnemySpawnerScript : MonoBehaviour {
	public GameObject Virus1;
    public GameObject DecreaseScore;
    public float spawnrate;
    public float spawnrate_max; 
    public bool getFaster = true;
	float counter = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI difficultyText;
    private int score = 0;
    public float difficulty = 0f;

    private float startTime;

    private static float init_spawnrate;

    public void increaseScore(int add)
    {
        score += add;
    }

    public void decreaseScore(int remove)
    {
        score -= 1000;
        Instantiate(DecreaseScore,GameObject.FindGameObjectWithTag("Canvas").transform);
    }

    public void calculateDifficulty()
    {
        difficulty = 1 + init_spawnrate/10 - (spawnrate/10);
    }

    void displayScore()
    {
        scoreText.SetText("Score: " + score);
    }

    void displayDifficulty()
    {
        difficultyText.SetText("Difficulty: " + difficulty.ToString("0.0"));
    }

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        init_spawnrate = spawnrate;
    }
	
	// Update is called once per frame
	void Update () {

        

        float t = Time.time - startTime;

        displayScore();

        calculateDifficulty();
        displayDifficulty();

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
