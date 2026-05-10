using UnityEngine;
using System.Collections;

public class PlatformLR : MonoBehaviour
{
   public float Distance = 3f;
   public float speed =2f;
   public float WaitTime = 1f;

   private Vector3 startPosition;
   private Vector3 endPosition;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + Vector3.right * Distance;
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            yield return StartCoroutine(MoveToPoint(endPosition));
            yield return new WaitForSeconds(WaitTime);
            yield return StartCoroutine(MoveToPoint(startPosition));
            yield return new WaitForSeconds(WaitTime);
        }
    }

    IEnumerator MoveToPoint(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = target;
    }

}
