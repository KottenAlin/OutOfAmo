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

    }

    IEnumerator WaitForTenSeconds()
    {
        if (blackComponent != null)
        {
            blackComponent.SetActive(true);
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(sceneName);

    }
}
