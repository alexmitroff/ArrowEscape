/* Based on example of Unity Austin 2017 talk "Game Architecture with Scriptable Objects"
https://www.youtube.com/watch?v=raQ3iHhE_Kk
*/
using System.Collections.Generic;

using UnityEngine;

namespace PrawnEntertainment.Events
{
    [CreateAssetMenu(fileName = "OnStringEvent", menuName = "PrawnEntertainment/Events/StringEvent")]
    public class SO_StringEvent: ScriptableObject
    {
        private List<BehaviourStringEventListener> listners = new List<BehaviourStringEventListener>();

        public void Raise(string text)
        {
            for(int i = listners.Count -1; i >= 0; i--)
                listners[i].OnEventRaised(text);
        }

        public void RegisterListner( BehaviourStringEventListener listener )
        {
            listners.Add(listener);
        }

        public void UnregisterListner( BehaviourStringEventListener listener )
        {
            listners.Remove(listener);
        }
    }
}