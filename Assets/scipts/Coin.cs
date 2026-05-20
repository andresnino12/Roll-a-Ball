using UnityEngine;
using UnityEditor.Build;

public class Coin : MonoBehaviour
{
    [SerializeField] private int point;


    private void OTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.ChangeScore(point);
            Debug.Log("Entro en el trigger");
        }
    }

    private void OTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Esta en el trigger");
        }
    }

    void OTriggerExit(Collider other)
    {
        if (other.tag =="Player");
        {
            Debug.Log("salio del trigger");
        }
    }
}
