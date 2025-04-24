using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Data;

namespace UnityUtils.BaseClasses
{
    public class BaseCinematicController<TType> : MonoBehaviour where TType : Enum
    {
        [SerializeField] protected List<CinematicData<TType>> _cinematics;
        protected Dictionary<TType, CinematicData<TType>> _cinematicsMap = new();

        protected virtual void Awake()
        {
            foreach (var cinematic in _cinematics)
            {
                _cinematicsMap[cinematic.Type] = cinematic;
            }
        }

        protected CinematicData<TType> GetCinematic(TType type)
        {
            return _cinematicsMap[type];
        }

    }
}
