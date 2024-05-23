using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Kosmos6
{
    public interface IWeapon
    {
        Vector3 FireWeapon(Vector3 targetPosition);
        void Damage(float damageAmount, Vector3 targetHitPosition, GameAgent sender);
        void VisualizeFiring(Vector3 targetPosition);
    }
}


