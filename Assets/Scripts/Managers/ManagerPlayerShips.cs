using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Kosmos6
{
    public class ManagerPlayerShips : MonoBehaviour
    {
        public int CurrentShipId;
        public Transform ShipVisuals;
        public GameObject CurrentShip;

        [SerializeField] private List<GameObject> ShipsPrefabs = new List<GameObject>();

        void Update()
        {
            if(Input.GetButtonDown("ShipChange")){
                ChangeShipToNext();
            }
        }

        void ChangeShipToNext()
        {
            CurrentShipId++;
            if(CurrentShipId >= ShipsPrefabs.Count)
            {
                CurrentShipId = 0;
            }

            ChangeShip(CurrentShipId);
        }

        void ChangeShip(int id)
        {
            Destroy(CurrentShip);

            CurrentShip = Instantiate(ShipsPrefabs[CurrentShipId], ShipVisuals);
        }
    }
}

