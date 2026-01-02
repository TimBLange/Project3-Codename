using UnityEngine;

public class SceneLoaderQuitGame : MonoBehaviour
{
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
