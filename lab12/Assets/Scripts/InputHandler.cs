using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical   { get; private set; }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical   = Input.GetAxis("Vertical");
    }
}