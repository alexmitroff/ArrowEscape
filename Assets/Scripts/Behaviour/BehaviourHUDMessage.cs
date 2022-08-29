using UnityEngine;
using TMPro;

using PrawnEntertainment.Events;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourHUDMessage : MonoBehaviour
    {
        public TextMeshProUGUI TextArea;

        void Start()
        {
            TextArea.text = "";
        }
        public void OnMessageRecieved(string message)
        {
            TextArea.text = message;
        }
    }
}
