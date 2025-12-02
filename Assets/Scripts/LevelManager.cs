using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Scene currentScene;
    [SerializeField] public Scene nextScene;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextScene = GetComponent<Scene>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(nextScene.name);
        }
    }
}