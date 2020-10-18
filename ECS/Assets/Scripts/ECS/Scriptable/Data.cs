using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Data : ScriptableObject
{
    // public static PlayerInitData playerData
    public  PlayerInitData playerInitData;
    public PlayerInitData enemyInitData;
   
    public static PlayerInitData LoadPlayerInitData() => Resources.Load("Data/Player Data") as PlayerInitData;
   
    // public static PlayerInitData LoadPlayerInitData() => Addressables.LoadAsset<PlayerInitData>();
}
