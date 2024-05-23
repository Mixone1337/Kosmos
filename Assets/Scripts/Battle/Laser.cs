using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kosmos6{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour, IWeapon {
        public bool CanFire;
        public float MaxDistance = 100.0f;
        public float DamageAmount = 5f;

        private Coroutine _coroutineFiring;
        private WaitForSeconds _waitForFiring;
        [SerializeField] private float _waitTimeFiring = 0.1f;

        [Header("Links")]
        [SerializeField] private LineRenderer _lineRenderer;
        private ShipWeapons _ShipWeapons;

        public List<IDamagable> TargetsHit = new List<IDamagable>();

        private void Awake()
        {
            if(_ShipWeapons == null)
                _ShipWeapons = GetComponentInParent<ShipWeapons>();
            if (_lineRenderer == null)
                _lineRenderer = GetComponent<LineRenderer>();
        }

        // Start is called before the first frame update
        void Start() {
            _waitForFiring = new WaitForSeconds(_waitTimeFiring);

            _lineRenderer.enabled = false;
            CanFire = true;
        }

       

        public Vector3 FireWeapon(Vector3 targetPosition) {
            RaycastHit hitInfo;
            var direction = targetPosition - transform.position;
            if(Physics.Raycast(transform.position, direction, out hitInfo, MaxDistance)) {

                var targetHit = hitInfo.transform;
                if (targetHit != null) {
                    Debug.Log($"FireWeapon. targetHit: {targetHit.name}");
                    var damagableHit = targetHit.GetComponent<IDamagable>();
                    if (damagableHit != null)
                    {
                        TargetsHit.Add(damagableHit);
                        Damage(DamageAmount, targetHit.position, _ShipWeapons.Spaceship.ShipAgent);
                    }

                    VisualizeFiring(targetHit.position);

                    return targetHit.position;
                }
                    
            }

            //if nothing was hit
            VisualizeFiring(transform.position + direction.normalized * MaxDistance);
            return targetPosition;
        }

        public void Damage(float damageAmount, Vector3 targetHitPosition, GameAgent sender)
        {
            foreach(var targetHit in TargetsHit){ 
                targetHit.RecieveDamage(damageAmount, targetHitPosition, sender); 
            }
            TargetsHit.Clear();
        }

        public void VisualizeFiring(Vector3 targetPosition) {
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