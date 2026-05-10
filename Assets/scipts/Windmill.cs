using UnityEngine;

public class Windmill : MonoBehaviour
{
    public float speed = 90f;
    public Vector3 axis = Vector3.up;

    void Update()
    {
        transform.Rotate(axis * speed * Time.deltaTime);
    }
}