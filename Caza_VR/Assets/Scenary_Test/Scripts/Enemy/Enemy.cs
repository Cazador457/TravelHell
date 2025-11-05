using UnityEngine;
using System;
using System.Collections;
public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float health = 50f;

    [Header("Respawn Settings")]
    public float respawnDelay = 3f; // Tiempo que tarda en reaparecer
    public Transform[] respawnPoints; //Puntos de respawn del propio enemigo

    public event Action onDeath;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameManager.Instance.enemiesKilled++;
            Die();
        }
    }

    public void Die()
    {
        onDeath?.Invoke();

        // Desactiva el enemigo (puede mostrar animación antes)
        gameObject.SetActive(false);

        // Inicia el proceso de reaparecer
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);

        //Verifica que haya puntos asignados
        if (respawnPoints != null && respawnPoints.Length > 0)
        {
            // Elige uno aleatorio
            int index = UnityEngine.Random.Range(0, respawnPoints.Length);
            transform.position = respawnPoints[index].position;
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} no tiene puntos de respawn asignados.");
        }

        //Restaura la vida
        health = 50f;

        //Reactiva el enemigo
        gameObject.SetActive(true);
    }

    public virtual void OnEnable()
    {
        //Cada vez que se active, restaura vida
        health = 50f;
    }
}
