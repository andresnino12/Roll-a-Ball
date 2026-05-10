using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  
    private Vector3 lastCheckpointPosition;
    private bool hasCheckpoint = false;

    void Awake()
    {
        
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetCheckpoint(int index, Vector3 position)
    {
        lastCheckpointPosition = position;
        hasCheckpoint = true;
    }

    public Vector3 GetRespawnPosition()
    {
        return hasCheckpoint ? lastCheckpointPosition : Vector3.zero;
    }
}