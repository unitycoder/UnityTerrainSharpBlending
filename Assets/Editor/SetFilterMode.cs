// use from menu: Tools/UnityLibrary/Terrain/FilterMode/
// sets active terrain alphamap texture filtermode
// https://unitycoder.com/blog/2017/05/20/terrain-alphamap-texture-filtermode-sharp-texture-blending

using UnityEngine;
using UnityEditor;

public class SetFilterMode : MonoBehaviour
{
    [MenuItem("Tools/UnityLibrary/Terrain/FilterMode/Point")]
    static void SetTerrainAlphaMapFilterModeToPoint()
    {
        SetFilter(FilterMode.Point);
    }
    [MenuItem("Tools/UnityLibrary/Terrain/FilterMode/Bilinear")]
    static void SetTerrainAlphaMapFilterModeToBilinear()
    {
        SetFilter(FilterMode.Bilinear);
    }
    [MenuItem("Tools/UnityLibrary/Terrain/FilterMode/Trilinear")]
    static void SetTerrainAlphaMapFilterModeToTrilinear()
    {
        SetFilter(FilterMode.Trilinear);
    }

    static void SetFilter(FilterMode filterMode)
    {
        var terrain = Terrain.activeTerrain;
        if (terrain == null)
        {
            Debug.LogError("No active terrain in scene..");
            return;
        }

        // set all alphamaps to this filtermode
        for (int i = 0, length = terrain.terrainData.alphamapTextures.Length; i < length; i++)
        {
            terrain.terrainData.alphamapTextures[i].filterMode = filterMode;
        }
    }
}
