using UnityEngine;

using UnityEngine.Events;

namespace PrawnEntertainment.Events
{
    [System.Serializable]
    public class StringEvent : UnityEvent<string> {}
    [System.Serializable]
    public class TransformEvent : UnityEvent<Transform> {}
}