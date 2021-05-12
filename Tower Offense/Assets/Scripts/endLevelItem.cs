using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevelItem : MonoBehaviour
{
    public GameManager gm;
    public LayerMask playerMask;
    private void Awake()
    {
        gm = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
    }

    void Update()
    {
        if(Physics.CheckSphere(this.transform.position, 1f, playerMask))
        {
            Interact();
        }
    }
    public void Interact()
    {
        Cursor.lockState = CursorLockMode.None;
        //base.Interact();
        if (gm.currentLevel < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(LoadSceneAnsync());
        }
        else
        {
            StartCoroutine(LoadFinalScene());
        }
    }
    IEnumerator LoadSceneAnsync()
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gm.statsScene);

        // Wait till loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    IEnumerator LoadFinalScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gm.finalScene);

        // Wait till loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
