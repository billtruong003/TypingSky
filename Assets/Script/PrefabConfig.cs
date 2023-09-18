using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;
[CreateAssetMenu(fileName = "PrefabData", menuName = "Typing Sky/Prefab Asset/PrefabData")]
public class PrefabConfig : ScriptableObject
{
    private string PATH_PREFAB = "Resources/Prefabs/";
    [Serializable]
    class Prefab
    {
        public string namePrefab;
        public string pathPrefab;
    }
    [SerializeField] private List<Prefab> prefabData;

    [Button]
    private void FillPathPrefab()
    {
        foreach (var prefab in prefabData)
        {
            prefab.pathPrefab = PATH_PREFAB + prefab.namePrefab;
        }
    }
    public GameObject GetPrefab(string objectName)
    {
        foreach (var pref in prefabData)
        {
            if (pref.namePrefab == objectName)
            {
                GameObject prefab = Resources.Load<GameObject>(pref.pathPrefab);
                return prefab;
            }
        }
        return null;
    }
}
