using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TOUCHED: Something hit the finish line: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("SUCCESS: Player tag detected! Sending Win signal...");
            
            MazeGameManager manager = FindObjectOfType<MazeGameManager>();
            if (manager != null)
            {
                manager.WinGame();
            }
            else
            {
                Debug.LogError("ERROR: Could not find the MazeGameManager in the scene!");
            }
        }
        else
        {
            Debug.LogWarning("NOTICE: Object hit the finish line, but its tag was: " + other.tag);
        }
    }
}