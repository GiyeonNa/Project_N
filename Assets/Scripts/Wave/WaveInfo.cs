using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="WaveInfo/Wave")]

public class WaveInfo : ScriptableObject
{
    [System.Serializable]
    public class Enemy
    {
        public string type;
        public int amount;
    }
    public string waveName;
    public WaveInfo nextWave;
    public Enemy[] enemies;

}
