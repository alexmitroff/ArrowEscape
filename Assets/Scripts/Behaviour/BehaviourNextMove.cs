using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PrawnEntertainment.Events;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourNextMove : MonoBehaviour
    {
        public SO_TransformEvent PossibleNextMoveEvent;

        private void OnTriggerStay(Collider other)
        {
            PossibleNextMoveEvent.Raise(other.transform);
        }

    }
}
