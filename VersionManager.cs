//using UnityEngine;
//using System.Collections;
//using UnityEditor;

//public class VersionManager : MonoBehaviour
//{

//    public static void Test()
//    {
//        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
//        AssetImporter import = AssetImporter.GetAtPath(path);
//        import.userData = PlayerSettings.bundleVersion;
//        import.SaveAndReimport();
//        Debug.LogError("im");
//    }

//    void Update()
//    {
//        Debug.LogError(Application.version);
//    }
//}
