using UnityEngine;

using PrawnEntertainment.SceneManagement;

namespace PrawnEntertainment.Behaviour
{
    public class BehaviourSceneManager : MonoBehaviour
    {
        public SO_SceneManager SceneManager;

        void OnDestroy()
        {
            SceneManager.ClearSceneState();
        }

        public void LoadScene(string scene_name){
            SceneManager.LoadScene(scene_name);
        }
        public void UnloadScene(string scene_name){
            SceneManager.UnloadScene(scene_name);
        }

        public void SetActiveScene(string scene_name){
            SO_SceneManager.SetActiveScene(scene_name);
        }

        public void ReloadScene(string scene_name)
        {
            UnloadScene(scene_name);
            LoadScene(scene_name);
        }

    }
}
