using UnityEngine;

using PrawnEntertainment.Events;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourSetSceneActive : MonoBehaviour
    {
        [Header("Events")]
        public SO_StringEvent SetActive;

        void Start()
        {
            SetActive.Raise(gameObject.scene.name);
        }
    }
}
