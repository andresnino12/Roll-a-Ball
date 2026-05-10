using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointIndex;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SetCheckpoint(checkpointIndex, transform.position);
            Debug.Log("Checkpoint " + checkpointIndex + " activado!");
        }
    }
}