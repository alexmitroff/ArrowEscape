/* Based on example of Unity Austin 2017 talk "Game Architecture with Scriptable Objects"
https://www.youtube.com/watch?v=raQ3iHhE_Kk
*/
using System.Collections.Generic;

using UnityEngine;

namespace PrawnEntertainment.Events
{
    [CreateAssetMenu(fileName = "OnTransform", menuName = "PrawnEntertainment/Events/TransformEvent")]
    public class SO_TransformEvent: ScriptableObject
    {
        private List<BehaviourTransformEventListener> listners = new List<BehaviourTransformEventListener>();

        public void Raise(Transform transform)
        {
            for(int i = listners.Count -1; i >= 0; i--)
                listners[i].OnEventRaised(transform);
        }

        public void RegisterListner( BehaviourTransformEventListener listener )
        {
            listners.Add(listener);
        }
        public void UnregisterListner( BehaviourTransformEventListener listener )
        {
            listners.Remove(listener);
        }

    }
}