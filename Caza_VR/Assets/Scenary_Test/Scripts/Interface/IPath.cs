using UnityEngine;

public interface IPath
{
    void OnSpawned(Transform[] optionalRoute = null);
}
