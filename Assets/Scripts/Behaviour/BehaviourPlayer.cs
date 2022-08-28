using UnityEngine;

using PrawnEntertainment.Events;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourPlayer : MonoBehaviour
    {
        [Header("Events")]
        public SO_SimpleEvent LoadNextLevel;
        int _CheckpointCount;
        bool _IsEndWasReached;
        void Start()
        {
            _IsEndWasReached = false;
            _CheckpointCount = 0;
            GameObject[] Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
            if (Checkpoints != null)
                _CheckpointCount = Checkpoints.Length;
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
        }

        public void PlayerReachedAnExit()
        {
            _IsEndWasReached = true;
            if (_CheckpointCount == 0)
            {
                Debug.Log("The end was reached!");
                Debug.Log("Loading a next level!");
                LoadNextLevel.Raise();
            } else {
                Debug.Log("You need to pass through all checkpoints");
            }
        }

    }
}
