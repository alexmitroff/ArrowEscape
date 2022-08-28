/* Based on example of Unity Austin 2017 talk "Game Architecture with Scriptable Objects"
https://www.youtube.com/watch?v=raQ3iHhE_Kk
*/

using UnityEngine;
using UnityEngine.Events;

namespace PrawnEntertainment.Events
{
    public class BehaviourSimpleEventListener: MonoBehaviour
    {
        public SO_SimpleEvent Event;
        public UnityEvent Response;
        private void OnEnable()
        {
            Event.RegisterListner(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListner(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}