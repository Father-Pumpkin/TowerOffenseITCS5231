using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    bool isMuted;
    GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
        if (PlayerPrefs.GetFloat("Volume") > 0)
        {
            isMuted = false;
        }
    }
    public void StartGameButton()
    {
        StartCoroutine(LoadSceneAnsync());
        PlayerPrefs.SetFloat("Strength", 0);
        PlayerPrefs.SetFloat("Sneak", 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Mute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            AudioListener.volume = 1f;
        }
        else
        {
            AudioListener.volume = 0f;
        }
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
