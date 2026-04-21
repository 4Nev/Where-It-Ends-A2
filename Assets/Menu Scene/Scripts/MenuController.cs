using UnityEngine;
using UnityEngine.SceneManagement; // Essential for scene switching

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        // Ensure the mouse is visible and free when the menu loads
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Call this from the PLAY button
    public void StartGame()
    {
        // Replace "Neville_Terrain_Stage" with the EXACT name of your maze scene file
        SceneManager.LoadScene("Neville_Terrain_Stage");
    }

    // Call this from any HOME icon button
    public void LoadHome()
    {
        // Replace "MenuScene" with the EXACT name of your menu scene file
        SceneManager.LoadScene("MenuScene");
    }

}