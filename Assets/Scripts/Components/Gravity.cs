using UnityEngine;

public class Gravity : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BottomBlockDestroying()
    {
        Debug.Log(gameObject.name + " should move");

        this.transform.Translate(0, -0.4f, 0);
    }
}
