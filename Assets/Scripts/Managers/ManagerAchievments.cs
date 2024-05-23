using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Kosmos6
{
    public class ManagerAchievments : SingletonManager<ManagerAchievments>
    {

        private void OnEnable()
        {
            ManagerScore.Instance.OnNewScore += CheckAchievements;
        }

        private void OnDisable()
        {
            ManagerScore.Instance.OnNewScore -= CheckAchievements;
        }



        private void CheckAchievements(int newScore)
        {
            if (newScore > 9)
            {
                Debug.Log("You are the CHAMPION!");
            }
        }
    }
}


