using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourArrow : MonoBehaviour
    {
        public Transform OnLeft;
        public Transform OnForward;
        public Transform OnRight;

        public void SetForward(Transform transform)
        {
            OnForward = transform;
        }

        public void SetLeft(Transform transform)
        {
            OnLeft = transform;
        }

        public void SetRight(Transform transform)
        {
            OnRight = transform;
        }
    }
}
