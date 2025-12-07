using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadSceneAsync("House");
    }
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
