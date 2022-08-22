/* MIT License
Copyright (c) 2016 RedBlueGames
*/

#if UNITY_EDITOR
using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEditor;
using UnityEditor.Build.Reporting;

namespace Visualization.Build
{
    public class BehaviourBuild : MonoBehaviour
    {
        #if UNITY_EDITOR_LINUX
        static BuildTarget _targetPlatform = BuildTarget.StandaloneLinux64;
        #endif
        #if UNITY_EDITOR_WIN
        static BuildTarget _targetPlatform = BuildTarget.StandaloneWindows64;
        #endif
        // public static SO_BuildingScenes BuildingScenes;
        [MenuItem("Build/Build dev version")]
        public static void BuildDev()
        {
            Debug.Log($"Build development version for {_targetPlatform}");
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.options = BuildOptions.Development;
            buildPlayerOptions.options |= BuildOptions.AllowDebugging;
            buildPlayerOptions.options |= BuildOptions.CompressWithLz4HC;

            BuildProject(buildPlayerOptions);
        }

        [MenuItem("Build/Build prod version")]
        public static void BuildProd()
        {
            Debug.Log($"Build production version for {_targetPlatform}");
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.options = BuildOptions.CompressWithLz4HC;

            BuildProject(buildPlayerOptions);
        }

        public static void BuildProject(BuildPlayerOptions buildPlayerOptions)
        {
            string path = EditorUtility.SaveFolderPanel("Choose Location of Built Applications", "VehicleViz", "VehicleVisualization");
            if (String.IsNullOrEmpty(path))
            {
                Debug.Log("A build path is empty or Null. Building is canceled.");
                return;
            }
            Debug.Log($"A build path is '{path}'");
            FileUtil.DeleteFileOrDirectory(path);
            path = $"{path}/{PlayerSettings.productName}";
            #if UNITY_EDITOR_LINUX
            path += ".run";
            #endif
            #if UNITY_EDITOR_WIN
            path += ".exe";
            #endif

            // This gets the Build Version from Git via the `git describe` command
            PlayerSettings.bundleVersion = Git.BuildVersion;

            // ===== This sample is taken from the Unity scripting API here:
            // https://docs.unity3d.com/ScriptReference/BuildPipeline.BuildPlayer.html
            Debug.Log($"Start to build Vehicle visualization {PlayerSettings.bundleVersion}");

            buildPlayerOptions.scenes = GetProductionScenes();
            buildPlayerOptions.locationPathName = path;
            buildPlayerOptions.target = _targetPlatform;

            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary summary = report.summary;

            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log($"Build succeeded: {summary.totalSize} bytes in {summary.totalTime}");
            }

            if (summary.result == BuildResult.Failed)
            {
                Debug.Log("Build failed");
            }
        }

        public static string[] GetProductionScenes()
        {
            string[] ScenesGUIDS = AssetDatabase.FindAssets("l:ProdScene", null);
            List<string> SceneRelPathes = new List<string>() {};
            foreach(string GUID in ScenesGUIDS)
            {
                string path = AssetDatabase.GUIDToAssetPath(GUID);
                SceneRelPathes.Add(path);
                Debug.Log($"{path} added to build");
            }
            return SceneRelPathes.ToArray();
        }
    }

}

#endif
