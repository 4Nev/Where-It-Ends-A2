using UnityEngine;

public class MenuController : MonoBehaviour
{
    void Start()
    {
        // 1. Unlock the cursor so it can move freely
        Cursor.lockState = CursorLockMode.None;
        
        // 2. Make the cursor visible
        Cursor.visible = true;
    }
}