#if UNITY_EDITOR
using System;

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using Unity.SharpZipLib.Utils;

public class CustomPostProcessBuild
{
    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {
        string path_to_build = pathToBuiltProject;
        #if UNITY_EDITOR_LINUX
        string extention = ".run";
        #endif
        #if UNITY_EDITOR_WIN
        string extention = ".exe";
        #endif
        string projectName = PlayerSettings.productName;

        path_to_build = path_to_build.Remove(path_to_build.Length-extention.Length, extention.Length);

        string buildDate = DateTime.Now.ToString("yyyyMMdd");
        string sourceDirPath = path_to_build.Remove(path_to_build.Length-projectName.Length-1, projectName.Length+1);
        string compressedDirPath = $"{sourceDirPath}_v{PlayerSettings.bundleVersion}_{buildDate}.zip";
        ZipUtility.CompressFolderToZip(compressedDirPath, "", sourceDirPath);
        Debug.Log($"{compressedDirPath} successfully created!");
    }
}


#endif
