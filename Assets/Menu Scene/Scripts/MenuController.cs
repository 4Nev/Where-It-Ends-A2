using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Start()
    {
        // This is the "Fix" from your dev log: 
        // Ensures mouse is visible and game isn't frozen when menu loads
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // This is the logic for your Help Button
    public void LoadHelpScene()
    {
        SceneManager.LoadScene("HelpScene"); 
        // Make sure your help scene is named EXACTLY "HelpScene" in Unity
    }

    // This is the logic for your Stage Button
    public void LoadNevilleStage()
    {
        SceneManager.LoadScene("Neville_Terrain_Stage");
    }

    // Use this for the "Back" button inside the Help Scene 
    // to return to the main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit Requested");
    }
}