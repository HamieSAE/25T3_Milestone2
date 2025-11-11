using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private TargetHP[] targets;
    private int currentTargetIndex = 0;

    [SerializeField] private Camera playerCamera;
    /*WALL feel free to ignore my extra steps */
    [SerializeField] private LayerMask obsticleLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); //<==Find the correct Syntax to replace this line 

        targets = gameManager.GetSortedTargets();

        FaceNextVisibleTarget();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            FaceNextVisibleTarget();
        }
    }

    private void FaceNextVisibleTarget()
    {
        currentTargetIndex = (currentTargetIndex + 1) % targets.Length;

        TargetHP target = targets[currentTargetIndex];

        if(isTargetVisible(target))
        {
            playerCamera.transform.LookAt(target.transform);
            return;
        }
    }

    private bool isTargetVisible(TargetHP target)
    {
        Vector3 directionToTarget = target.transform.position - playerCamera.transform.position;
        float distanceToTarget = Vector3.Distance(playerCamera.transform.position, target.transform.position);

        if(!Physics.Raycast(playerCamera.transform.position, directionToTarget, distanceToTarget, obsticleLayer))
        {
            return true;
        }
        return false;
    }
}
