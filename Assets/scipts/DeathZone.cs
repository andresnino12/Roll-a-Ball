using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("DeathZone tocó: " + other.gameObject.name + " tag: " + other.gameObject.tag);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player cayó! Respawneando en: " + GameManager.instance.GetRespawnPosition());
            other.transform.position = GameManager.instance.GetRespawnPosition();
            other.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }
}