using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kosmos6
{
    public interface IDamagable
    {
        float Health { get; }

        void RecieveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender);

        void RecieveHeal(float healAmount, Vector3 hitPosition, GameAgent sender);
    }
}

