using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour, ICanBeInteracted
{
    [SerializeField] private GameObject[] customerModels;
    [SerializeField] private float maxInteractionTimer;
    private float interactionTimer;
    [HideInInspector] public GameObject exitDoor;
    [HideInInspector] public GameObject seatToTake;
    [HideInInspector] public GameObject targetedLocation;
    [HideInInspector] public Table thisTable;
    [HideInInspector] public int thisTableId;
    [HideInInspector] public bool interactionReceived;
    [HideInInspector] public bool waitingForOrder;
    [HideInInspector] public bool leave;
    public NavMeshAgent thisNavMeshAgent;
    public Order.OrderType[] possibleTypes;
    public SoulType.SoulColor[] possibleIngredients;
    [HideInInspector] public Order.OrderType chosenType;
    [HideInInspector] public List<SoulType.SoulColor> chosenIngredients;
    private Vector3 startingPos;

    [HideInInspector] public CustomerReferences customerReferences;

    public GameObject Self { get; set; }
    private GameObject selectedModel;

    private void Awake()
    {
        customerReferences = this.gameObject.GetComponent<CustomerReferences>();
        Self = this.gameObject;
        exitDoor = GameObject.FindGameObjectWithTag("Exit");
        startingPos = this.gameObject.transform.position;
    }
    private void Start()
    {
        interactionTimer = maxInteractionTimer;
        RandomizeModel();
    }
    private void OnDisable()
    {
        leave = false;
        this.gameObject.transform.position = startingPos;
    }
    private void Update()
    {
        if (interactionReceived) InteractionTimer();
    }
    public void ChooseSeat()
    {
        Table[] tablesList = FindObjectsOfType<Table>();
        int randIndex = Random.Range(0, tablesList.Length);
        SeatInfo[] seatInfos = tablesList[randIndex].seatInfo;
        for (int i = 0; i < seatInfos.Length; i++)
        {
            if (!seatInfos[i].seatIsOccupied)
            {
                seatToTake = tablesList[randIndex].seatInfo[i].seatTarget;
                tablesList[randIndex].seatInfo[i].seatIsOccupied = true;
                thisTable = tablesList[randIndex];
                thisTable.seatInfo[i].customer = this;
                thisTableId = i;
                targetedLocation = seatToTake;
                break;
            }
        }
    }
    public void RandomizeModel()
    {
        int randIndex = Random.Range(0, customerModels.Length);
        selectedModel = customerModels[randIndex];
        selectedModel.SetActive(true);
    }
    public void Interaction()
    {
        interactionReceived = true;
    }
    private void InteractionTimer()
    {
        if (interactionTimer > 0) interactionTimer -= Time.deltaTime;
        else
        {
            interactionReceived = false;
            interactionTimer = maxInteractionTimer;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit")) this.gameObject.SetActive(false);
    }
}
