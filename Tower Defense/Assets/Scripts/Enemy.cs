using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("Enemy Stats")]
    public float startSpeed = 10f;
    public float health = 100;
    public int worth = 50;

    [HideInInspector]
    public float speed;

    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    public void Slow(float slowAmount)
    {
        speed = startSpeed * (1f - slowAmount);
    }
}
