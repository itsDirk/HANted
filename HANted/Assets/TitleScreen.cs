using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        // Quits the application
        Application.Quit();
        
        // For debugging in the editor, this will stop playing the game
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
