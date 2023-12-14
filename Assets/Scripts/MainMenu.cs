using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public void PlayGame()
    {
        // Load the "GameScene" when the "Play" button is pressed.
        SceneManager.LoadScene("GameScene");
    }

    // This method is called when the "Quit" button is pressed in the main menu.
    public void QuitGame()
    {
        // Quit the application. Note that this may not work in all environments.
        Application.Quit();
    }
}
