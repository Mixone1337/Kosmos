using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kosmos6
{
    public class Engine : MonoBehaviour
    {
        [Serializable]
        class EngineVisuals
        {
            [SerializeField] private ParticleSystem _particleSystem;
            [Header("Settings")]
            [SerializeField] private float _psEmittedMax = 50;
            [SerializeField] private float _psEmittedMin = 50;
            [SerializeField] private float _visualizationLerpRate = 0.25f;

            [Header("Current Values")]
            [SerializeField] private float _psEmittedCurr = 50;
            [SerializeField] private float _visualizationCurrNormalized = 0; //0-1

            public void VisualizeThrust(float inputMove)
            {
                var emission = _particleSystem.emission;

                _visualizationCurrNormalized = Mathf.Lerp
                    (_visualizationCurrNormalized, inputMove, _visualizationLerpRate);


                _psEmittedCurr = _psEmittedMax * _visualizationCurrNormalized;

                emission.rateOverTime = Mathf.Max(_psEmittedCurr, _psEmittedMin);
            }
        }


        [SerializeField] private float _moveSpeed = 100f;
        [SerializeField] private List<EngineVisuals> _engineVisuals = new List<EngineVisuals>();


        public Vector3 Thrust(float inputMove)
        {
            VisualizeThrust(inputMove);

            var calculatedThust = inputMove * _moveSpeed;

            return -transform.forward * calculatedThust;
        }

        private void VisualizeThrust(float inputMove)
        {
            foreach(var ev in _engineVisuals)
            {
                ev.VisualizeThrust(inputMove);
            }
        }
    }

}
