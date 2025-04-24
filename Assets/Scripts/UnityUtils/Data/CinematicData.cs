using System;
using UnityEngine;
using UnityEngine.Playables;

namespace UnityUtils.Data
{
    [Serializable]
    public class CinematicData<TType> where TType : Enum
    {
        public PlayableDirector PlayableDirectory;
        public TType Type;

        public void PlayCinematic()
        {
            PlayableDirectory.Play();
        }
    }
}