using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kosmos6
{
    public class ShipMovement : MonoBehaviour
    {
        [Header("Movement Multipliers")]
        [SerializeField] private float _pitchSpeed = 125000f;
        [SerializeField] private float _yawSpeed = 125000f;
        [SerializeField] private float _rollSpeed = 125000f;

        [SerializeField] private float _moveSpeed = 125000f;

        [Header("Drag Multipliers")]
        [Range(0.5f, 50f)]
        [SerializeField] private float _proportionalAngularDrag = 10f;
        [Range(10f, 1000f)]
        [SerializeField] private float _proportionalDrag = 100f;

        [Header("Links")]
        public Spaceship SpaceShip;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private List<Engine> Engines = new List<Engine>();

        void Start()
        {

        }

        void FixedUpdate()
        {
            Turn(SpaceShip.InputShipMovement.CurrentInputRotatePitch,
                SpaceShip.InputShipMovement.CurrentInputRotateYaw,
                SpaceShip.InputShipMovement.CurrentInputRotateRoll);
            Move(SpaceShip.InputShipMovement.CurrentInputMove);
        }

        private void Turn(float inputPitch, float inputYaw, float inputRoll )
        {
            if (!Mathf.Approximately(0f, inputPitch))
                _rigidbody.AddTorque(transform.right * inputPitch * _pitchSpeed * Time.fixedDeltaTime);

            if (!Mathf.Approximately(0f, inputYaw))
                _rigidbody.AddTorque(transform.up * inputYaw * _yawSpeed * Time.fixedDeltaTime);

            if (!Mathf.Approximately(0f, inputRoll))
                _rigidbody.AddTorque(transform.forward * inputRoll * _rollSpeed * Time.fixedDeltaTime);

            _rigidbody.AddForce(- _rigidbody.angularVelocity * _proportionalAngularDrag * Time.fixedDeltaTime);
        }

        private void Move(float inputMove)
        {
            Vector3 resultingThrust = new Vector3();
            foreach (var engine in Engines)
            {
                resultingThrust += engine.Thrust(inputMove);
            }

            _rigidbody.AddForce(resultingThrust * inputMove *  _moveSpeed * Time.fixedDeltaTime);
            _rigidbody.AddForce(- _rigidbody.velocity * _proportionalDrag * Time.fixedDeltaTime);
        }
    }
}

