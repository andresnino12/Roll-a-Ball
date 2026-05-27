using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Score score;
    private Vector3 currSpawnPlayer;
    public Vector3 CurrSpawnPlayer {get =>currSpawnPlayer;set =>currSpawnPlayer = value;}
    public GameObject player;

    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
        currSpawnPlayer = player.transform.position;
    }

    public void ChangeScore(int newScore)
    {
        score.AddScore(newScore);
    }

    public void ClearPlayerPref()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ReSpawnPlayer()
    {
        player.SetActive(false);
        player.transform.position = CurrSpawnPlayer;
        player.GetComponent<PlayerController>().rb.angularVelocity = Vector3.zero;
        player.GetComponent<PlayerController>().rb.linearVelocity= Vector3.zero;
        player.SetActive(true);
    }
}
