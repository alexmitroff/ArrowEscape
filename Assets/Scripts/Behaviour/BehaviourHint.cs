using UnityEngine;
using TMPro;

using PrawnEntertainment.Events;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourHint : MonoBehaviour
    {
        public TextMeshProUGUI TextArea;
        void Start()
        {
            TextArea.enabled = false;
        }
        public void OnShowHint()
        {
            TextArea.enabled = true;
        }
    }
}
