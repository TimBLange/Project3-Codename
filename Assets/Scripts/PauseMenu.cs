using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;

    public InputActionAsset interactActions;
    private InputActionMap _actionMap;

    
    void OnEnable()
    {
        interactActions.Enable();
    }

    void OnDisable()
    {
        interactActions.Disable();
    }

    void Awake()
    {
        ResumeGame();
        _actionMap = interactActions.FindActionMap("Player", true);
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
    }

/*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;

            }
            else
            {
                PauseGame();
                Cursor.lockState = CursorLockMode.Confined;

            }
        }
        
    }
*/
    public void OnPause(InputAction.CallbackContext context)
    {
        
            if (Dialogue.instance.talking == true)
            {
                Dialogue.instance.EndDialogue();
            }
            else
            {
                PauseGame();
            }
        
    }

  /*  public void OnResume(InputAction.CallbackContext context)
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
*/
    private void PauseGame()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void MainMenu()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Debug.Log("MainMenu has been pressed");
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
        
    }


}
