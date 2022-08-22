using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourArrow : MonoBehaviour
    {
        public Transform LeftMove;
        public Transform ForwardMove;
        public Transform RightMove;

        private Transform _SelfTranform;

        void Awake()
        {
            _SelfTranform = transform;
        }

        public void SetForward(Transform transform)
        {
            ForwardMove = transform;
        }

        public void SetLeft(Transform transform)
        {
            LeftMove = transform;
        }

        public void SetRight(Transform transform)
        {
            RightMove = transform;
        }

        public void OnLeft()
        {
            Transform Target = LeftMove;
            LeftMove = null;
            _SelfTranform.position = Target.position;
            _SelfTranform.rotation = Target.rotation;
        }
        public void OnForward()
        {
            Transform Target = ForwardMove;
            ForwardMove = null;
            _SelfTranform.position = Target.position;
            _SelfTranform.rotation = Target.rotation;
        }
        public void OnRight()
        {
            Transform Target = RightMove;
            RightMove = null;
            _SelfTranform.position = Target.position;
            _SelfTranform.rotation = Target.rotation;
        }
    }
}
