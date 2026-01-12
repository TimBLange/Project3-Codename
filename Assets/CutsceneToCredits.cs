using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneToCredits : MonoBehaviour
{
   
    void OnEnable()
    {

        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }


}
