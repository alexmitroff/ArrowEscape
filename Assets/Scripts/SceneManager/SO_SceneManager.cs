using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace PrawnEntertainment.SceneManagement
{
    [CreateAssetMenu(fileName = "SceneManager", menuName ="PrawnEntertainment/SceneManager")]
    public class SO_SceneManager : ScriptableObject
    {
        private Dictionary<string, AsyncOperation> _SceneState;
        public void LoadScene(string scene_name)
        {
            _CheckSceneStateDict();
            if (!_SceneState.ContainsKey(scene_name))
            {
                Debug.Log($"Loading `{scene_name}` scene");
                _SceneState[scene_name] = SceneManager.LoadSceneAsync(scene_name, LoadSceneMode.Additive);
            }
        }
        public void UnloadScene(string scene_name)
        {
            _CheckSceneStateDict();
            if (IsSceneLoaded(scene_name))
            {
                Debug.Log($"Unloading `{scene_name}` scene");
                SceneManager.UnloadSceneAsync(scene_name);
                _SceneState.Remove(scene_name);
            }
        }

        void _CheckSceneStateDict()
        {
            if ( _SceneState == null )
                _SceneState = new Dictionary<string, AsyncOperation>();
        }

        public void ClearSceneState()
        {
            if ( _SceneState != null )
                _SceneState.Clear();
        }

        public bool IsSceneLoaded(string scene_name)
        {
            return SceneManager.GetSceneByName(scene_name).isLoaded;
        }

        public static bool SetActiveScene(string scene_name)
        {
            return SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene_name));
        }

        public static string GetActiveSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }
    }

}