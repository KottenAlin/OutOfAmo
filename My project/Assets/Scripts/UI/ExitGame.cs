using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        #if UNITY_EDITOR // If we are running the game in the Unity Editor
                UnityEditor.EditorApplication.isPlaying = false; // Stop playing the game in the editor
        #else
                Application.Quit(); // Quit the game in a built application
        #endif
        Debug.Log("Game is exiting");
    }
}
