using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourArrow : MonoBehaviour
    {
        [Header("Move variants")]
        public Transform LeftUpMove;
        public Transform LeftMove;
        public Transform LeftDownMove;
        [Space(10)]
        public Transform ForwardUpMove;
        public Transform ForwardMove;
        public Transform ForwardDownMove;
        [Space(10)]
        public Transform RightUpMove;
        public Transform RightMove;
        public Transform RightDownMove;

        [Header("Replacements")]
        public GameObject PrefabTurnLeft;
        public GameObject PrefabTurnRight;
        public GameObject PrefabStright;

        private Transform _SelfTranform;

        void Awake()
        {
            _SelfTranform = transform;
        }

        public void SetForward(Transform transform) { if( ForwardMove != transform ) ForwardMove = transform; }
        public void SetForwardUp(Transform transform) { if( ForwardUpMove != transform ) ForwardUpMove = transform; }
        public void SetForwardDown(Transform transform) { if( ForwardDownMove != transform ) ForwardDownMove = transform; }
        public void SetLeft(Transform transform) { if( LeftMove != transform ) LeftMove = transform; }
        public void SetLeftUp(Transform transform) { if( LeftUpMove != transform ) LeftUpMove = transform; }
        public void SetLeftDown(Transform transform) { if( LeftDownMove != transform ) LeftDownMove = transform; }
        public void SetRight(Transform transform) { if( RightMove != transform ) RightMove = transform; }
        public void SetRightUp(Transform transform) { if( RightUpMove != transform ) RightUpMove = transform; }
        public void SetRightDown(Transform transform) { if( RightDownMove != transform ) RightDownMove = transform; }

        public void OnLeft()
        {
            if( LeftUpMove != null )
            {
                _SpawnPlaceholder(LeftUpMove, PrefabTurnLeft);
                _TurnLeft();
                _TurnUp();
                _MakeAMove(LeftUpMove);
                return;
            }
            if (LeftDownMove != null)
            {
                _SpawnPlaceholder(LeftDownMove, PrefabTurnLeft);
                _TurnLeft();
                _TurnDown();
                _MakeAMove(LeftDownMove);
                return;
            }
            if (LeftMove != null)
            {
                _SpawnPlaceholder(LeftMove, PrefabTurnLeft);
                _TurnLeft();
                _MakeAMove(LeftMove);
                return;
            }
        }

        public void OnForward()
        {
            if( ForwardUpMove != null )
            {
                _SpawnPlaceholder(ForwardUpMove, PrefabStright);
                _TurnUp();
                _MakeAMove(ForwardUpMove);
                return;
            }
            if (ForwardDownMove != null)
            {
                _SpawnPlaceholder(ForwardDownMove, PrefabStright);
                _TurnDown();
                _MakeAMove(ForwardDownMove);
                return;
            }
            if (ForwardMove != null)
            {
                _SpawnPlaceholder(ForwardMove, PrefabStright);
                _MakeAMove(ForwardMove);
                return;
            }
        }

        public void OnRight()
        {
            if( RightUpMove != null )
            {
                _SpawnPlaceholder(RightUpMove, PrefabTurnRight);
                _TurnRight();
                _TurnUp();
                _MakeAMove(RightUpMove);
                return;
            }
            if (RightDownMove != null)
            {
                _SpawnPlaceholder(RightDownMove, PrefabTurnRight);
                _TurnRight();
                _TurnDown();
                _MakeAMove(RightDownMove);
                return;
            }
            if (RightMove != null)
            {
                _SpawnPlaceholder(RightMove, PrefabTurnRight);
                _TurnRight();
                _MakeAMove(RightMove);
                return;
            }
        }

        private void _MakeAMove(Transform Move)
        {
            _CleanMoveVariants();
            _SelfTranform.position = Move.position;
        }

        private void _FaceUpDown(Transform Move)
        {
            if (_IsUp(Move)) _TurnUp();
            else if (_IsDown(Move)) _TurnDown();
        }

        private void _SpawnPlaceholder(Transform Move, GameObject PlaceholderPrefab)
        {
            Move.gameObject.SetActive(false);
            Instantiate<GameObject>(PlaceholderPrefab, _SelfTranform.position, _SelfTranform.rotation);
        }

        private void _CleanMoveVariants()
        {
            LeftUpMove = null;
            LeftMove = null;
            LeftDownMove = null;
            ForwardUpMove = null;
            ForwardMove = null;
            ForwardDownMove = null;
            RightUpMove = null;
            RightMove = null;
            RightDownMove = null;
        }

        private bool _IsUp(Transform Move)
        {
            return Move.position.y > _SelfTranform.position.y+1;
        }

        private bool _IsDown(Transform Move)
        {
            return Move.position.y < _SelfTranform.position.y-1;
        }

        private void _TurnLeft()
        {
            Debug.Log($"Up {_SelfTranform.up}");
            _SelfTranform.RotateAround(_SelfTranform.position, _SelfTranform.up, -90);
        }

        private void _TurnRight()
        {
            Debug.Log($"Up {_SelfTranform.up}");
            _SelfTranform.RotateAround(_SelfTranform.position, _SelfTranform.up, 90);
        }

        private void _TurnUp()
        {
            Debug.Log($"Right {_SelfTranform.right}");
            _SelfTranform.RotateAround(_SelfTranform.position, _SelfTranform.right, -90);
        }

        private void _TurnDown()
        {
            Debug.Log($"Right {_SelfTranform.right}");
            _SelfTranform.RotateAround(_SelfTranform.position, _SelfTranform.right, 90);
        }
    }
}
