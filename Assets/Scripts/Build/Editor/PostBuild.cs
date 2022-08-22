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
        string config_file_name = "Config.ini";
        string path_to_build = pathToBuiltProject;
        #if UNITY_EDITOR_LINUX
        string extention = ".run";
        #endif
        #if UNITY_EDITOR_WIN
        string extention = ".exe";
        #endif
        string projectName = PlayerSettings.productName;


        path_to_build = path_to_build.Remove(path_to_build.Length-extention.Length, extention.Length);

        string path_to_build_data = $"{path_to_build}_Data/{config_file_name}";
        string path_to_config = Application.dataPath;
        path_to_config = $"{path_to_config}/{config_file_name}";

        FileUtil.CopyFileOrDirectory(path_to_config, path_to_build_data);
        Debug.Log($"Config file successfully copied to {path_to_build}");

        string buildDate = DateTime.Now.ToString("yyyyMMdd");
        string sourceDirPath = path_to_build.Remove(path_to_build.Length-projectName.Length-1, projectName.Length+1);
        string compressedDirPath = $"{sourceDirPath}_v{PlayerSettings.bundleVersion}_{buildDate}.zip";
        ZipUtility.CompressFolderToZip(compressedDirPath, "", sourceDirPath);
        Debug.Log($"{compressedDirPath} successfully created!");
    }
}


#endif
