using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainButtonsPanel;   // Drag your first menu buttons here
    public GameObject stageSelectorPanel; // Drag your new selector panel here

    void Start()
    {
        // Makes sure the mouse is free to click buttons
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Start with Main Menu visible, Stage Selector hidden
        if (mainButtonsPanel != null) mainButtonsPanel.SetActive(true);
        if (stageSelectorPanel != null) stageSelectorPanel.SetActive(false);
    }

    // Opens the selector (Link to your "Stage" or "Start" button)
    public void OpenStageSelector()
    {
        mainButtonsPanel.SetActive(false);
        stageSelectorPanel.SetActive(true);
    }

    // Goes back (Link to a "Back" button in the selector)
    public void CloseStageSelector()
    {
        mainButtonsPanel.SetActive(true);
        stageSelectorPanel.SetActive(false);
    }

    // Load Neville's Stage
    public void LoadNevilleStage()
    {
        SceneManager.LoadScene("Neville_Terrain_Stage");
    }

    // Load Agnes's Stage
    public void LoadAgnesStage()
    {
        SceneManager.LoadScene("Agnes'Scene");
    }
}