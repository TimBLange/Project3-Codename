using UnityEngine;

public class ScrollingCredits : MonoBehaviour
{
    public float scrollingSpeed = 0.5f;
    public Vector2 scrollingDirection;
    
    public GameObject scrollingTarget;
    void Start()
    {
        
    }

    void Update()
    {
        scrollingTarget.transform.Translate(scrollingDirection * Time.deltaTime * scrollingSpeed);
    }
}
