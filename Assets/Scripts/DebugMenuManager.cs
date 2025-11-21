using UnityEngine;
using UnityEngine.Serialization;

public class DebugMenuManager : MonoBehaviour
{
    public GameObject debugMenu;
    public PlayerMovement playerMovement;
    public Gun gun;
    
    
    
    void Start()
    {
        debugMenu.SetActive(false);
    }

  
    void Update()
    {
        if (Time.timeScale == 0) return;
        if (Input.GetKeyDown(KeyCode.F1) &&  !debugMenu.activeSelf)
        {
            ActivateDebugMenu();
           playerMovement.CursorUnlock();
        }
        else if (Input.GetKeyDown(KeyCode.F1) && debugMenu.activeSelf)
        {
            DeactivateDebugMenu();
            playerMovement.CursorLock();
        }
        
    }

    private void ActivateDebugMenu()
    {
        debugMenu.SetActive(true);
    }
    private void DeactivateDebugMenu()
    {
        debugMenu.SetActive(false);
    }

    void InfiniteAmmo()
    {
        
    }
}
