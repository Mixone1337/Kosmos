using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 90;

    [Header("Links")]
    public Transform SpaceShip;
    [SerializeField] private List<Engine> Engines = new List<Engine> ();

    void Start()
    {
        
    }

    void Update(){
        Turn();
        Move();
    }

    private void Turn() {
        float yaw = _rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        float pitch = _rotationSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        float roll = _rotationSpeed * Input.GetAxis("Roll") * Time.deltaTime;

        SpaceShip.Rotate(pitch, yaw, roll);
    }

    private void Move() {
        Vector3 resultingThrust = new Vector3();
        foreach (var engine in Engines){
            resultingThrust += engine.Thrust();
        }

        SpaceShip.Translate(resultingThrust);
    }
}
