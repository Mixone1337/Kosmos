using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Kosmos6
{
    public class ShipHealth : MonoBehaviour, IDamagable
    {
        [SerializeField] private float _health;
        public float Health => _health;

        private void Start()
        {

        }

        public void RecieveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
        {
            _health -= damageAmount;
            if (_health <= 0)
            {
                Debug.Log($"Attacker: {sender.gameObject.name}");
                Debug.Log($"Attacker faction: {sender.ShipFaction}");
                Destroy(gameObject);
            }
        }

        public void RecieveHeal(float healAmount, Vector3 hitPosition, GameAgent sender)
        {
            throw new System.NotImplementedException();
        }


    }
}


