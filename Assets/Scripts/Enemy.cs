using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float invincibilityTime = 0.5f;

    private bool isInvincible = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && !isInvincible)
        {
            TakeDamage();
            StartCoroutine(InvincibilityFrames());
            collision.gameObject.SetActive(false);
        }
    }

    private System.Collections.IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }

    private void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}