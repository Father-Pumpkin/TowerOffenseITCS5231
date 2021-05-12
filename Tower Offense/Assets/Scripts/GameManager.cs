using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 0;
    public int statsScene = 1;
    public float volume = .5f;
    public int strength = 0;
    public int sneak = 0;
    private int availablePoints = 10;
    public bool hasNoPoints = false;
    public int finalScene;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.SetFloat("Volume", PlayerPrefs.GetFloat("Volume", 1f));
        PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength"));
        PlayerPrefs.SetInt("Sneak", PlayerPrefs.GetInt("Sneak"));
        finalScene = SceneManager.sceneCountInBuildSettings;
    }

    private void Start()
    {

    }

    public void gainPoint()
    {
        availablePoints++;
    }
    public void spendPoint()
    {
        if(availablePoints == 0)
        {
            hasNoPoints = true;
            return;
        }
        availablePoints--;
    }
    public int getPoint()
    {
        return availablePoints;
    }
}
