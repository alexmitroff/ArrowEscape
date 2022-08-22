/* Based on example of Unity Austin 2017 talk "Game Architecture with Scriptable Objects"
https://www.youtube.com/watch?v=raQ3iHhE_Kk
*/

using UnityEngine;

namespace PrawnEntertainment.Events
{
    public class BehaviourTransformEventListener: MonoBehaviour
    {
        public SO_TransformEvent Event;
        public TransformEvent Response;
        private void OnEnable()
        {
            Event.RegisterListner(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListner(this);
        }

        public void OnEventRaised(Transform transform)
        {
            Response.Invoke(transform);
        }
    }
}