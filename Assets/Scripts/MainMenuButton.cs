using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuButton : MonoBehaviour
{
    public void MainMenu()
    {
        Debug.Log("MainMenu has been pressed");
        SceneManager.LoadScene(0);
    }
    void Start()
    {

    }
    void Update()
    {

    }

}
