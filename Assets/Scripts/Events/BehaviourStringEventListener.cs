/* Based on example of Unity Austin 2017 talk "Game Architecture with Scriptable Objects"
https://www.youtube.com/watch?v=raQ3iHhE_Kk
*/

using UnityEngine;
using UnityEngine.Events;

namespace PrawnEntertainment.Events
{
    public class BehaviourStringEventListener: MonoBehaviour
    {
        public SO_StringEvent Event;
        public StringEvent Response;
        private void OnEnable()
        {
            Event.RegisterListner(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListner(this);
        }

        public void OnEventRaised(string text)
        {
            Response.Invoke(text);
        }
    }
}