using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rata", menuName = "EnemyScriptableObject", order = 1)]
public class ScriptableEnemy : ScriptableObject
{
    public string prefabName;
    public GameObject prefab;

    public int cant;
    public Vector3[] spawnPoint;

}
