using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LevelExit")
        {
            SceneManager.LoadScene(1);
        }
            
    }
}
