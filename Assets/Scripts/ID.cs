using UnityEngine;

public class ID : MonoBehaviour
{
    [Range(0,255)] public int id;
    public static ID instance;
    void Start()
    {
        instance = this;
    }

    public void IDNumber()
    {
        int number = id;
    }
}
