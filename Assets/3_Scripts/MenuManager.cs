using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        
        SceneManager.LoadScene("BasicGameplay");
    }

    public void Start()
    {
        PlayerPrefs.SetInt("skipTime", 0);
        PlayerPrefs.SetInt("spawnCount", 0);
    }
}
