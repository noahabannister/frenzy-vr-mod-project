using UnityEditor;
using System.IO;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

public class CreateAssetBundles {
    [MenuItem("Frenzy Modding/Build AssetBundles/Windows (SteamVR)")]
    static void BuildAllAssetBundlesWindows() {
        string assetBundleDirectory = "AssetBundles/Windows";
        if (!Directory.Exists(assetBundleDirectory)) {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory,
                                        BuildAssetBundleOptions.ForceRebuildAssetBundle,
                                        BuildTarget.StandaloneWindows);

        //Add .bundle to the bundle files
        List<string> files = Directory.GetFiles(assetBundleDirectory).ToList();

        foreach (string file in files) {
            string ext = Path.GetExtension(file);
            if (ext != ".bundle" && ext != ".manifest" && ext != ".meta") {
                string newPath = file + ".bundle";
                if (File.Exists(newPath))
                    File.Delete(newPath);
                File.Move(file, newPath);
            }
        }
    }

    [MenuItem("Frenzy Modding/Build AssetBundles/Android (Quest)")]
    static void BuildAllAssetBundlesAndroid() {
        string assetBundleDirectory = "AssetBundles/Android";
        if (!Directory.Exists(assetBundleDirectory)) {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory,
                                        BuildAssetBundleOptions.ForceRebuildAssetBundle,
                                        BuildTarget.Android);
        
        //Add .bundle to the bundle files
        List<string> files = Directory.GetFiles(assetBundleDirectory).ToList();
        
        foreach (string file in files) {
            string ext = Path.GetExtension(file);
            if (ext != ".bundle" && ext != ".manifest" && ext != ".meta") {
                string newPath = file + ".bundle";
                if (File.Exists(newPath))
                    File.Delete(newPath);
                File.Move(file, newPath);
            }
        }
    }
}