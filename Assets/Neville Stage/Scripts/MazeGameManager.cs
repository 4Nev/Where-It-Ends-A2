using UnityEngine;
using TMPro;

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
    public AudioSource sfxSource; // The speaker
    public AudioClip winSound;    // Your 4s clip
    public AudioClip loseSound;   // Your 2s clip

    void Start()
    {
        currentTime = timeLimit;
        if (statusDisplay != null) statusDisplay.gameObject.SetActive(false);
        
        // Auto-grab the AudioSource if you forgot to drag it in
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
            EndGame("Lost Before It Ends...", false);
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void WinGame()
    {
        if (!isGameOver)
        {
            EndGame("The Journey Ends Here... You Win!", true);
        }
    }

    void EndGame(string message, bool didWin)
    {
        isGameOver = true;
        statusDisplay.text = message;
        statusDisplay.gameObject.SetActive(true);

        // Play the appropriate sound
        if (didWin && winSound != null)
        {
            sfxSource.PlayOneShot(winSound);
        }
        else if (!didWin && loseSound != null)
        {
            sfxSource.PlayOneShot(loseSound);
        }
        
        if (currentTime < 0) currentTime = 0;
        UpdateTimerUI();
    }
}