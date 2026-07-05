using UnityEngine;
using System.Collections.Generic;

public class BotController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private int difficulty = 1; // 1-3

    private Rigidbody rb;
    private bool isGrounded;
    private int botScore = 0;
    private Vector3 moveDirection;
    private float[] abilityCooldowns = new float[4];
    private float decisionTimer = 0f;
    private float decisionInterval = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        SetupBot();
    }

    private void SetupBot()
    {
        gameObject.name = $"Bot_{Random.Range(1000, 9999)}";
        gameObject.tag = "Player";
        Debug.Log($"🤖 Bot spawned: {gameObject.name} (Difficulty: {difficulty})");
    }

    private void Update()
    {
        CheckGrounded();
        UpdateAI();
        UpdateCooldowns();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void UpdateAI()
    {
        decisionTimer += Time.deltaTime;

        if (decisionTimer >= decisionInterval)
        {
            MakeDecision();
            decisionTimer = 0f;
        }
    }

    private void MakeDecision()
    {
        // Random movement
        moveDirection = new Vector3(
            Random.Range(-1f, 1f),
            0,
            Random.Range(0.5f, 1f)
        ).normalized;

        // Jump occasionally
        if (isGrounded && Random.value > 0.7f)
        {
            Jump();
        }

        // Use ability occasionally
        if (Random.value > 0.8f && difficulty >= 2)
        {
            UseRandomAbility();
        }
    }

    private void Move()
    {
        moveDirection = moveDirection.normalized;
        rb.velocity = new Vector3(
            moveDirection.x * moveSpeed,
            rb.velocity.y,
            moveDirection.z * moveSpeed
        );
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void UseRandomAbility()
    {
        int randomAbility = Random.Range(0, 4);
        if (abilityCooldowns[randomAbility] <= 0)
        {
            abilityCooldowns[randomAbility] = 10f;
            Debug.Log($"🤖 {gameObject.name} used ability {randomAbility + 1}");
        }
    }

    private void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        isGrounded = Physics.Raycast(ray, 0.2f);
    }

    private void UpdateCooldowns()
    {
        for (int i = 0; i < 4; i++)
        {
            if (abilityCooldowns[i] > 0)
            {
                abilityCooldowns[i] -= Time.deltaTime;
            }
        }
    }

    public void AddScore(int points)
    {
        botScore += points;
    }

    public int GetScore()
    {
        return botScore;
    }

    public void SetDifficulty(int diff)
    {
        difficulty = Mathf.Clamp(diff, 1, 3);
    }
}
