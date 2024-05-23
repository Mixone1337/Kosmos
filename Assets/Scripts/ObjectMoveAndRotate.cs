using UnityEngine;
using System.Collections;

namespace Kosmos6
{
    public class ObjectMooveAndRotate : MonoBehaviour
    {

        public Transform target; // the object to rotate around
        public float _speedRotation = 10; // the speed of rotation
        public float speedMoving = 0.5f;

        private IEnumerator coroutineMoveSun;
        private WaitForSeconds waitForMoveSun;

        [SerializeField] private float waitForMoveSunDelay = 0.1f;

        private void Start()
        {
            if (target == null)
            {
                target = transform;
                Debug.Log("RotateAround target not specified. Defaulting to current GameObject");

            }
            waitForMoveSun = new WaitForSeconds(waitForMoveSunDelay);
            StartCoroutineMoveSun();

        }

        // Update is called once per frame
        private void Update()
        {
            RotateAround();

        }

        private void RotateAround()
        {
            // RotateAround takes three arguments, first is the Vector to rotate around
            // second is a vector that axis to rotate around
            // third is the degrees to rotate, in this case the speed per second
            transform.RotateAround(target.transform.position, target.transform.up, _speedRotation * Time.deltaTime);
        }

        private void MoveSun()
        {
            if (gameObject.name == "Sun")
                transform.Translate(Vector3.forward * speedMoving * Time.deltaTime);
        }

        [ContextMenu("StartCoroutineMoveSun")]
        public void StartCoroutineMoveSun()
        {
            coroutineMoveSun = MoveSunCor();
            StartCoroutine(coroutineMoveSun);
        }

        [ContextMenu("StopCoroutineMoveSun")]
        public void StopCoroutineMoveSun()
        {
            StopCoroutine(coroutineMoveSun);
        }

        private IEnumerator MoveSunCor()
        {
            while (true)
            {
                yield return waitForMoveSun;
                MoveSun();
            }
        }
    }

}
