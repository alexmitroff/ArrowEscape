/* Based on example of Unity Austin 2017 talk "Game Architecture with Scriptable Objects"
https://www.youtube.com/watch?v=raQ3iHhE_Kk
*/
using System.Collections.Generic;

using UnityEngine;

namespace PrawnEntertainment.Events
{
    [CreateAssetMenu(fileName = "OnSomethingSimple", menuName = "PrawnEntertainment/Events/SimpleEvent")]
    public class SO_SimpleEvent: ScriptableObject
    {
        private List<BehaviourSimpleEventListener> listners = new List<BehaviourSimpleEventListener>();

        public void Raise()
        {
            for(int i = listners.Count -1; i >= 0; i--)
                listners[i].OnEventRaised();
        }

        public void RegisterListner( BehaviourSimpleEventListener listener )
        {
            listners.Add(listener);
        }
        public void UnregisterListner( BehaviourSimpleEventListener listener )
        {
            listners.Remove(listener);
        }

    }
}