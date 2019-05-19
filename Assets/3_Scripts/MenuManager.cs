using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject repeatUI;
    public void PlayGame()
    {
        
        SceneManager.LoadScene("BasicGameplay");
    }
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1_1");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("StarMenu");
    }

    public void Start()
    {
        
    }

    public void PlayBoss()
    {
        repeatUI = GameObject.Find("RepeatBoss");
        Time.timeScale = 1;
        repeatUI.SetActive(false);


        GameObject boss = GameObject.Find("pRatBoss(Clone)");
        GameObject rat = GameObject.Find("pRat(Clone)");
        GameObject rat_wave = GameObject.Find("pRat Variant wave(Clone)");
        GameObject rat_wave_alt = GameObject.Find("pRat Variant wave alt(Clone)");
        GameObject rat_wave_duo = GameObject.Find("pRat Variant wave duo(Clone)");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        


        if (boss != null)
        {
            Destroy(boss);
        }






        Instantiate(bossPrefab);

    }

}
