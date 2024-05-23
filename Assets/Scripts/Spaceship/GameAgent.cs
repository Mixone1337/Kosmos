using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kosmos6
{
    public class GameAgent : MonoBehaviour
    {
        public enum faction
        {
            Player,
            Allies,
            SeventhStar
        }
        public faction ShipFaction;
    }
}

