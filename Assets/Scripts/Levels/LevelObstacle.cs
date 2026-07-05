using UnityEngine;

public class LevelObstacle : MonoBehaviour
{
    public enum ObstacleType
    {
        Platform,
        Pit,
        MovingPlatform,
        Propeller,
        Spike,
        RotatingBlade,
        RollingBall,
        ElectricFence,
        Trampoline,
        IcePatch
    }

    [SerializeField] private ObstacleType obstacleType;
    [SerializeField] private float damage = 1f;
    [SerializeField] private bool isKillZone = false;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Vector3 moveDirection = Vector3.forward;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        ApplyObstacleProperties();
    }

    private void ApplyObstacleProperties()
    {
        switch (obstacleType)
        {
            case ObstacleType.Platform:
                GetComponent<Renderer>().material.color = Color.gray;
                break;

            case ObstacleType.Pit:
                GetComponent<Collider>().isTrigger = true;
                isKillZone = true;
                break;

            case ObstacleType.MovingPlatform:
                GetComponent<Renderer>().material.color = Color.cyan;
                break;

            case ObstacleType.Spike:
                GetComponent<Renderer>().material.color = Color.red;
                damage = 1f;
                break;

            case ObstacleType.Propeller:
                GetComponent<Renderer>().material.color = new Color(1, 0.5f, 0);
                break;

            case ObstacleType.RotatingBlade:
                GetComponent<Renderer>().material.color = Color.yellow;
                break;

            case ObstacleType.IcePatch:
                GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
    }

    private void Update()
    {
        if (obstacleType == ObstacleType.MovingPlatform)
            MovePlatform();
        else if (obstacleType == ObstacleType.RotatingBlade || obstacleType == ObstacleType.Propeller)
            RotateBlade();
    }

    private void MovePlatform()
    {
        transform.position = startPosition + moveDirection * Mathf.Sin(Time.time * speed) * 2f;
    }

    private void RotateBlade()
    {
        transform.Rotate(0, speed * 100f * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isKillZone)
            {
                Debug.Log($"💀 {other.name} fiel in ein Pit!");
                Destroy(other.gameObject);
            }
            else if (obstacleType == ObstacleType.Spike)
            {
                Debug.Log($"🔪 {other.name} berührte Spikes!");
                Destroy(other.gameObject);
            }
        }
    }
}
