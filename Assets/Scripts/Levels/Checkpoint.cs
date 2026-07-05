using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointNumber;
    [SerializeField] private bool isFinal = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddScore(100);
                Debug.Log($"🚩 Checkpoint {checkpointNumber} reached!");

                if (isFinal)
                {
                    Debug.Log($"🏁 ZIEL ERREICHT!");
                    OnFinalCheckpoint(player);
                }
            }
        }
    }

    private void OnFinalCheckpoint(PlayerController player)
    {
        if (MatchManager.Instance != null)
        {
            MatchManager.Instance.PlayerFinished(player);
        }
    }

    public int GetCheckpointNumber() => checkpointNumber;
}
