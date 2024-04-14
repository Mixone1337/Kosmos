using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kosmos6{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour {
        public bool CanFire;
        public float MaxDistance = 100.0f;

        private Coroutine _coroutineFiring;
        private WaitForSeconds _waitForFiring;
        [SerializeField] private float _waitTimeFiring = 0.1f;

        [Header("Links")]
        [SerializeField] private LineRenderer _lineRenderer;

        // Start is called before the first frame update
        void Start() {
            if (_lineRenderer == null)
                _lineRenderer = GetComponent<LineRenderer>();

            _waitForFiring = new WaitForSeconds(_waitTimeFiring);

            _lineRenderer.enabled = false;
            CanFire = true;
        }

        // Update is called once per frame
        private void Update() {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 targetPosition = FireWeapon(transform.position + transform.forward * MaxDistance);
                VisualizeFiringWeapon(targetPosition);
            }
        }

        public Vector3 FireWeapon(Vector3 targetPosition) {
            RaycastHit hitInfo;
            var direction = targetPosition - transform.position;
            if(Physics.Raycast(transform.position, direction, out hitInfo, MaxDistance)) {

                var targetHit = hitInfo.transform;
                if (targetHit != null) {
                    Debug.Log($"FireWeapon. targetHit: {targetHit.name}");
                    //Destroy(targetHit.gameObject);
                    return targetHit.position;
                }
                    
            }

            //if nothing was hit
            return targetPosition;
        }

        public void VisualizeFiringWeapon(Vector3 targetPosition) {
            if (CanFire)
            {
                _lineRenderer.enabled = true;
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, targetPosition);

                CanFire = false;

                _coroutineFiring = StartCoroutine(FiringCor());
            }
        }

        private IEnumerator FiringCor() {
            yield return _waitForFiring;

            CanFire = true;
            _lineRenderer.enabled = false;
        }
    }
}