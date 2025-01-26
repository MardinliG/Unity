using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed; // Vitesse de déplacement
    [SerializeField] private float jumpForce = 5f; // Force de saut
    [SerializeField] private float minJumpInterval = 1f; // Intervalle minimum entre les sauts
    [SerializeField] private float maxJumpInterval = 3f; // Intervalle maximum entre les sauts
    [SerializeField] private float minDirectionChangeInterval = 1f; // Intervalle minimum pour changer de direction
    [SerializeField] private float maxDirectionChangeInterval = 5f; // Intervalle maximum pour changer de direction
    private Rigidbody2D body;
    private bool grounded;
    private float jumpTimer;
    private float directionChangeTimer;
    private float nextJumpInterval;
    private float nextDirectionChangeInterval;
    private bool movingRight = true;

    private void Awake()
    {
        // Récupère la référence pour Rigidbody2D
        body = GetComponent<Rigidbody2D>();
        SetNextJumpInterval();
        SetNextDirectionChangeInterval();
    }

    private void Update()
    {
        // Déplacement vers la gauche ou la droite
        if (movingRight)
        {
            body.linearVelocity = new Vector2(speed, body.linearVelocity.y);
        }
        else
        {
            body.linearVelocity = new Vector2(-speed, body.linearVelocity.y);
        }

        // Met à jour le timer de saut
        jumpTimer += Time.deltaTime;
        if (grounded && jumpTimer >= nextJumpInterval)
        {
            Jump();
            jumpTimer = 0;
            SetNextJumpInterval();
        }

        // Met à jour le timer de changement de direction
        directionChangeTimer += Time.deltaTime;
        if (directionChangeTimer >= nextDirectionChangeInterval)
        {
            movingRight = !movingRight;
            directionChangeTimer = 0;
            SetNextDirectionChangeInterval();
        }
    }

    private void Jump()
    {
        // Applique une force verticale pour le saut
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Détection du contact avec le sol
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        // Change direction upon hitting a wall
        if (collision.gameObject.tag == "Wall")
        {
            movingRight = !movingRight;
        }
        // Load GameOver scene if the enemy touches the player
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadSceneAsync(5);
        }
    }

    private void SetNextJumpInterval()
    {
        nextJumpInterval = Random.Range(minJumpInterval, maxJumpInterval);
    }

    private void SetNextDirectionChangeInterval()
    {
        nextDirectionChangeInterval = Random.Range(minDirectionChangeInterval, maxDirectionChangeInterval);
    }
}