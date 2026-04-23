using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 
using System.Collections;         

public class MazeGameManager : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timeLimit = 120f;
    private float currentTime;
    private bool isGameOver = false;

    [Header("UI Reference")]
    public TextMeshProUGUI timerDisplay;
    public TextMeshProUGUI statusDisplay;

    [Header("Audio Settings")]
    public AudioSource sfxSource; 
    public AudioClip winSound;    
    public AudioClip loseSound;   

    void Start()
    {
        // IMPORTANT: Ensure time is moving when the level starts
        Time.timeScale = 1f; 
        
        currentTime = timeLimit;
        if (statusDisplay != null) statusDisplay.gameObject.SetActive(false);
        
        if (sfxSource == null) sfxSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isGameOver) return;

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            EndGame("You Lost Your Way...", false);
        }
    }

    void UpdateTimerUI()
    {
        if (timerDisplay == null) return;
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void WinGame()
    {
        if (!isGameOver)
        {
            EndGame("You Found the End!", true);
        }
    }

    void EndGame(string message, bool didWin)
    {
        isGameOver = true;
        statusDisplay.text = message;
        statusDisplay.gameObject.SetActive(true);

        float delay = 2f; 

        if (didWin && winSound != null)
        {
            sfxSource.PlayOneShot(winSound);
            delay = 4f; 
        }
        else if (!didWin && loseSound != null)
        {
            sfxSource.PlayOneShot(loseSound);
            delay = 2f; 
        }

        StartCoroutine(ReturnToMenuAfterDelay(delay));
    }

    IEnumerator ReturnToMenuAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        CleanUpAndLoadMenu(); // Use the cleanup helper
    }

    // Manual Home Button Call
    public void ReturnToMenu()
    {
        CleanUpAndLoadMenu(); // Use the cleanup helper
    }

    // NEW: This helper ensures the Menu is actually usable when you get there
    private void CleanUpAndLoadMenu()
    {
        Time.timeScale = 1f;                     // Unfreeze time
        Cursor.lockState = CursorLockMode.None;  // Unlock the mouse
        Cursor.visible = true;                   // Show the mouse
        SceneManager.LoadScene("MenuScene");     // Load the scene
    }
}