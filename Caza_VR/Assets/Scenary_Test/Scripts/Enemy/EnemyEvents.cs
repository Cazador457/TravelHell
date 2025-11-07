using UnityEngine;
using System;

public class EnemyEvents : MonoBehaviour
{
    /*public static event Action PuntingT1;
    public static event Action PuntingT2;
    public static event Action PuntingT3;*/
    public static event Action<Transform> OnPursuit;
    public static event Action<GameObject> OnRespawnLight;
    public static event Action<GameObject> OnRespawnPatrol;
    public static event Action<GameObject> OnRespawnSpecial;

    public static void Pursuit(Transform agent) => OnPursuit?.Invoke(agent);
    public static void Respawn(GameObject enemy) => OnRespawnLight?.Invoke(enemy);
    public static void RespawnPatrol(GameObject enemy) => OnRespawnPatrol?.Invoke(enemy);
    public static void RespawnSpecial(GameObject enemy) => OnRespawnSpecial?.Invoke(enemy);
}
