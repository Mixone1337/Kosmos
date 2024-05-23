using System;
using System.Collections;
using System.Collections.Generic;

namespace Kosmos6
{
    public interface IInputShipMovement {
        
        public float CurrentInputMove { get; }

        public float CurrentInputRotatePitch { get; }
        public float CurrentInputRotateYaw { get; }
        public float CurrentInputRotateRoll { get; } 

    }

    public interface IInputShipWeapons {
        public bool CurrentInputAttack { get; }
        public event Action OnAttackInput;

    }
}
