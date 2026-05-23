using System;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSimpleController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private GameObject obstacleObj;
    [SerializeField] private Vector3 StartPosition;
    private Vector3 CurrTargetPosition;
    [SerializeField] private float rotationSpeed;

    void Start()
    {
        StartPosition = obstacleObj.transform.position;
        CurrTargetPosition = target.position;
    }
    void Update()
    {
        obstacleObj.transform.Rotate(Vector3.right,rotationSpeed * Time.deltaTime);
        if (obstacleObj.transform.position != CurrTargetPosition)
        {
        obstacleObj.transform.position = Vector3.MoveTowards(obstacleObj.transform.position, CurrTargetPosition, speed * Time.deltaTime);            
        }
        else
        {
            if(CurrTargetPosition == target.position)
            {
                CurrTargetPosition = StartPosition;
            }
            else if(CurrTargetPosition == StartPosition)
            {
                CurrTargetPosition = target.position;
            }
        }
    }
}
