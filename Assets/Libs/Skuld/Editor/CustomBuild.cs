using UnityEngine;
using UnityEditor;
using System;

#if UNITY_EDITOR
namespace Skuld.Editor
{
    public class CustomBuild : MonoBehaviour
    {
        [MenuItem("CustomBuild/Create Package/Default")]
        public static void CreatePackageByBuildSettings()
        {
            var scenes = EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes);
            CreatePackage(scenes);
        }

        [MenuItem("CustomBuild/Create Package/Current Scene")]
        public static void CreatePackageCurrentSceneOnly()
        {
            var scenes = new string[] { };
            CreatePackage(scenes);
        }

        static void CreatePackage(string[] scenes)
        {
            string buildDir = "build";
            string productName = UnityEditor.PlayerSettings.productName;
            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var outputDir = string.Format($"{buildDir}\\{productName}_{timeStamp}");
            var fileName = string.Format($"{productName}.exe");
            var outputPath = string.Format($"{outputDir}\\{fileName}");

            var result = BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.StandaloneWindows64, BuildOptions.None);
            if (result.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded)
            {
                var currentDir = global::System.IO.Directory.GetCurrentDirectory();
                var fullOutputDir = string.Format($"{currentDir}\\{outputDir}");
                global::System.Diagnostics.Process.Start($"explorer.exe", $"/select,{fullOutputDir}");
            }
        }
    }
}
#endif
