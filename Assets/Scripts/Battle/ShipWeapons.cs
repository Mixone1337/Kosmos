using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Kosmos6
{
    public class ShipWeapons : MonoBehaviour
    {
        public Spaceship Spaceship;

        public List<IWeapon> Weapons = new List<IWeapon>();

        public float MaxDistanceToTarget = 250f;

        private void Awake()
        {
            if (Spaceship == null)
                Spaceship = GetComponentInParent<Spaceship>();
            Weapons = GetComponentsInChildren<IWeapon>().ToList();
        }

        // Update is called once per frame
        private void OnEnable()
        {
            Spaceship.InputShipWeapons.OnAttackInput += FireWeapons;
        }

        private void OnDisable()
        {
            Spaceship.InputShipWeapons.OnAttackInput -= FireWeapons;
        }

        public void FireWeapons()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out hit, MaxDistanceToTarget))
            {
                foreach (var weapon in Weapons)
                {
                    weapon.FireWeapon(hit.point);

                }
            }
            else
            {
                foreach (var weapon in Weapons)
                {
                    weapon.FireWeapon(ray.origin + ray.direction * MaxDistanceToTarget);

                }
            }

        }

    }

}

