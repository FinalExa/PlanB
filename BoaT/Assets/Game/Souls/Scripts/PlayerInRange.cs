using UnityEngine;

public class PlayerInRange : MonoBehaviour
{
    private SoulController soulController;

    private void Awake()
    {
        soulController = this.gameObject.transform.parent.GetComponent<SoulController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) soulController.playerIsInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) soulController.playerIsInRange = false;
    }
}
