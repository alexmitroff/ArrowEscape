using UnityEngine;

using PrawnEntertainment.Events;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourLoadFirstLevel : MonoBehaviour
    {
        public bool IsTest;
        [Header("Events")]
        public SO_StringEvent LoadLevel;

        void Start()
        {
            if (IsTest)
            {
                LoadLevel.Raise("TestMovement");
            }
        }
    }
}
