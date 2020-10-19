using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInitData : ScriptableObject
{
    public GameObject playerPrefab;
    public float defaultSpeed = 2f;
    public float timeToAttack = 1f;
}
