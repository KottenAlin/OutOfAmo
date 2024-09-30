using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LoadScene : MonoBehaviour
{

    public GameObject blackComponent;
    public string sceneName;

    // Start is called before the first frame update   
    public void PlayGame()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            sceneName = SceneManager.GetActiveScene().name;
        }
        StartCoroutine(WaitForTenSeconds());
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadNextScene() // Load the next scene in the build settings
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(WaitForTenSeconds());
        SceneManager.LoadSceneAsync(currentSceneIndex + 1);
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        StartCoroutine(WaitForTenSeconds());
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    IEnumerator WaitForTenSeconds()
    {
        if (blackComponent != null)
        {
            blackComponent.SetActive(true);
            yield return new WaitForSeconds(3);
        }
    }
}
