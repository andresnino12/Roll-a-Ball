using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float height = 3f;
    public float speed = 2f;
    public float waitTime = 1f;

    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0, height, 0);

        // Iniciamos la corrutina
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            
            yield return StartCoroutine(MoveToPoint(endPosition));
            yield return new WaitForSeconds(waitTime);  

        
            yield return StartCoroutine(MoveToPoint(startPosition));
            yield return new WaitForSeconds(waitTime);  
        }
    }

    IEnumerator MoveToPoint(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                speed * Time.deltaTime
            );
            yield return null;  
        }

        transform.position = target;  
    }
}