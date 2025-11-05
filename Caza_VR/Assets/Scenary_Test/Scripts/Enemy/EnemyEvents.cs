using UnityEngine;
using System;

public class EnemyEvents : MonoBehaviour
{
    /*public static event Action PuntingT1;
    public static event Action PuntingT2;
    public static event Action PuntingT3;*/
    public static event Action<Transform> OnPursuit;

    public static void Pursuit(Transform agent) => OnPursuit?.Invoke(agent);
}
