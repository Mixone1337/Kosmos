using System;
using UnityEngine;



namespace Kosmos6
{
	public class ShipInputDesktop : MonoBehaviour, IInputShipMovement, IInputShipWeapons
    {
		[field: Header("Ship Movement Values")]

        [field: SerializeField] public float CurrentInputMove { get; private set; }

        [field: SerializeField] public float CurrentInputRotatePitch {  get; private set; }
        [field: SerializeField] public float CurrentInputRotateYaw { get; private set; }
        [field: SerializeField] public float CurrentInputRotateRoll { get; private set; }

        [field: Header("Ship Attack Values")]
        [field: SerializeField] public bool CurrentInputAttack { get; private set; }
        public event Action OnAttackInput;

        //public Vector2 look;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

        private void Update()
        {
			OnRotate();
			OnMove();
			OnAttack();
        }



        private void OnRotate()
        {
			float pitch = Input.GetAxis("Mouse Y");
			if (Mathf.Abs(pitch) < 0.075f)
				pitch = 0f;

            float yaw = Input.GetAxis("Mouse X");
            if (Mathf.Abs(yaw) < 0.075f)
                yaw = 0f;

            float roll = Input.GetAxis("Roll");
            if (Mathf.Abs(roll) < 0.075f)
                roll = 0f;

            RotateInput(pitch, yaw, roll);
        }


        private void OnMove()
		{
			MoveInput(Input.GetAxis("Vertical"));
		}



		private void OnAttack()
		{
            AttackInput(Input.GetAxis("Fire1"));
        }




        //public void onlook()
        //{
        //	if (cursorinputforlook)
        //	{
        //		lookinput(value.get<vector2>());
        //	}
        //}

        private void RotateInput(float pitch, float yaw, float roll)
        {
            CurrentInputRotatePitch = pitch;
            CurrentInputRotateYaw = yaw;
            CurrentInputRotateRoll = roll;
        }


        private void MoveInput(float newMoveInput)
		{
            CurrentInputMove = newMoveInput;
		}


        private void AttackInput(float newAttackInput)
        {
            if (newAttackInput > 0){
                CurrentInputAttack = true;
                OnAttackInput?.Invoke();
            }
            else{
                CurrentInputAttack = false;
            }
        }

        //public void LookInput(Vector2 newLookDirection)
        //{
        //	look = newLookDirection;
        //}

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}