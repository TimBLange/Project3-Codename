using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class BackToMenu : MonoBehaviour
{
    public int SceneIndex;
    void OnEnable()
    {
        SceneManager.LoadSceneAsync(SceneIndex);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
}
