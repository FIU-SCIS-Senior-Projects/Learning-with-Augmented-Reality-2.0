using UnityEngine;
using UnityEditor;

public class PackageToolb
{
    [MenuItem("Package/Update Package")]
    static void UpdatePackage()
    {
        AssetDatabase.ExportPackage("Assets/Kino", "KinoBokeh.unitypackage", ExportPackageOptions.Recurse);
    }
}
