using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kosmos6
{
    public class Spaceship : MonoBehaviour {
        public GameAgent ShipAgent;

        public IInputShipMovement InputShipMovement;
        public IInputShipWeapons InputShipWeapons;

        private void OnEnable()
        {
            if (ShipAgent == null)
                ShipAgent = GetComponent<GameAgent>();

            //Input
            if (InputShipMovement == null)
                InputShipMovement = GetComponent<IInputShipMovement>();

            if (InputShipWeapons == null)
                InputShipWeapons = GetComponent<IInputShipWeapons>();
        }
    }

}
