using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 0.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    public Vector3 Thrust()
    {
        return Vector3.forward * _moveSpeed * Time.deltaTime;
    }
}
