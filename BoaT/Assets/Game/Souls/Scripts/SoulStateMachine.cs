using UnityEngine;

public class SoulStateMachine : MonoBehaviour
{
    [HideInInspector] public SoulController soulController;
    private void Awake()
    {
        soulController = this.gameObject.GetComponent<SoulController>();
    }
}
