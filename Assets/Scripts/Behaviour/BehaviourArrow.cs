using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourArrow : MonoBehaviour
    {
        [Header("Move variants")]
        public Transform LeftMove;
        public Transform ForwardMove;
        public Transform RightMove;

        [Header("Replacements")]
        public GameObject PrefabTurnLeft;
        public GameObject PrefabTurnRight;
        public GameObject PrefabStright;

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
            if (LeftMove == null) return;
            _SpawnPlaceholder(LeftMove, PrefabTurnLeft);
            _MakeAMove(LeftMove);
        }
        public void OnForward()
        {
            if (ForwardMove == null) return;
            _SpawnPlaceholder(ForwardMove, PrefabStright);
            _MakeAMove(ForwardMove);
        }
        public void OnRight()
        {
            if (RightMove == null) return;
            _SpawnPlaceholder(RightMove, PrefabTurnRight);
            _MakeAMove(RightMove);
        }

        private void _MakeAMove(Transform Move)
        {
            bool isUp = Move.position.y > _SelfTranform.position.y+1;
            bool isDown = Move.position.y < _SelfTranform.position.y-1;

            _CleanMoveVariants();

            Debug.Log($"UP DOWN {isUp} {isDown} { isUp || isDown }");

            _SelfTranform.LookAt(Move);
            if (isUp) _SelfTranform.rotation = _TurnUp();
            if (isDown) _SelfTranform.rotation = _TurnDown();
            _SelfTranform.position = Move.position;
        }

        private void _SpawnPlaceholder(Transform Move, GameObject PlaceholderPrefab)
        {
            Move.gameObject.SetActive(false);
            Instantiate<GameObject>(PlaceholderPrefab, _SelfTranform.position, _SelfTranform.rotation);
        }

        private void _CleanMoveVariants()
        {
            LeftMove = null;
            ForwardMove = null;
            RightMove = null;
        }

        private Quaternion _TurnRight()
        {
            return new Quaternion(0,1,0,90);
        }

        private Quaternion _TurnLeft()
        {
            return new Quaternion(0,1,0,-90);
        }

        private Quaternion _TurnUp()
        {
            return new Quaternion(1,0,0,-45);
        }

        private Quaternion _TurnDown()
        {
            return new Quaternion(1,0,0,45);
        }
    }
}
