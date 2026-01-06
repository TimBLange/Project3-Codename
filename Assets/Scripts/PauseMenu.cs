using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;


    


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
    }


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

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void MainMenu()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Debug.Log("MainMenu has been pressed");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }


}
