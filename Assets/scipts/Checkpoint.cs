using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    private bool isActive = true;

    void OTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            GameManager.instance.CurrSpawnPlayer = spawnPosition.position;
            isActive = false;
        }
    }
}