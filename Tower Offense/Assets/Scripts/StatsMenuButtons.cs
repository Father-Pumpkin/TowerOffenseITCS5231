using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StatsMenuButtons : MonoBehaviour
{
    public GameManager gm;
    private void Awake()
    {
        gm = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
    }
    public void spendPointStrength()
    {
        if(gm.getPoint() > 0)
        {
            gm.spendPoint();
            PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength", 0) + 1);
        }
        else
        {
            gm.hasNoPoints = true;
            Debug.Log("Not enough Points");
            return;
        }
        Debug.Log("Strength Points " + PlayerPrefs.GetInt("Strength") + ", Sneak Points " + PlayerPrefs.GetInt("Sneak") + ". " + gm.getPoint() + " still remaining");
    }
    public void spendPointSneak()
    {
        if (gm.getPoint() > 0)
        {
            gm.spendPoint();
            PlayerPrefs.SetInt("Sneak", PlayerPrefs.GetInt("Sneak", 0) + 1);
        }
        else
        {
            gm.hasNoPoints = true;
            Debug.Log("Not enough Points");
            return;
        }
        Debug.Log("Strength Points " + PlayerPrefs.GetInt("Strength") + ", Sneak Points " + PlayerPrefs.GetInt("Sneak") + ". " + gm.getPoint() + " still remaining");
    }

    public void Confirm()
    {
        StartCoroutine(LoadSceneAnsync());
    }

    IEnumerator LoadSceneAnsync()
    {
        gm.currentLevel++;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gm.currentLevel);

        // Wait till loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
