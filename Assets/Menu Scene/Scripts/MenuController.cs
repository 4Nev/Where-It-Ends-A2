using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    void Start()
    {
        // Unlocks the mouse for menus
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Neville_Terrain_Stage");
    }

    public void LoadHome()
    {
        SceneManager.LoadScene("MenuScene");
    }

}