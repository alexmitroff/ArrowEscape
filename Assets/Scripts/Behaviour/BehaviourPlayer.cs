using UnityEngine;

using PrawnEntertainment.Events;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourPlayer : MonoBehaviour
    {
        [Header("Events")]
        public SO_SimpleEvent LoadNextLevel;
        public SO_SimpleEvent ReloadLevel;
        public SO_StringEvent HUDMessage;
        int _CheckpointCount;
        bool _IsNewMovesAvailable;
        bool _IsEndWasReached;
        bool _WereAllCheckpointsPassed;
        void Start()
        {
            _IsEndWasReached = false;
            _WereAllCheckpointsPassed = true;
            _IsNewMovesAvailable = true;
            _CheckpointCount = 0;
            GameObject[] Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
            if (Checkpoints != null)
            {
                _WereAllCheckpointsPassed = false;
                _CheckpointCount = Checkpoints.Length;
            }
        }

        public void PlayerPassedAChechpoint()
        {
            if (_CheckpointCount < 1)
            {
                Debug.LogWarning("There is no additional checkpoints");
                return;
            }
            Debug.Log("Checkpoint was passed.");
            _CheckpointCount--;
            _WereAllCheckpointsPassed = _CheckpointCount == 0;
        }

        public void PlayerReachedAnExit()
        {
            _IsEndWasReached = true;
            if (_WereAllCheckpointsPassed)
            {
                Debug.Log("The end was reached!");
                HUDMessage.Raise("Level is complete!\nPress [SPACE] to load next level");
            } else {
                Debug.Log("You need to pass through all checkpoints");
                HUDMessage.Raise("You need to pass through all checkpoints.\nPress [SPACE] to restart level");
            }
        }

        public void NoMovesAvailable()
        {
            _IsNewMovesAvailable = false;
            HUDMessage.Raise("There are not any moves available.\n Press [SPACE] to restart level");
        }

        public void OnAction()
        {
            if ( _IsEndWasReached && _WereAllCheckpointsPassed ) LoadNextLevel.Raise();
            if ( _IsEndWasReached && !_WereAllCheckpointsPassed ) ReloadLevel.Raise();
            if ( !_IsNewMovesAvailable ) ReloadLevel.Raise();
        }
    }
}
