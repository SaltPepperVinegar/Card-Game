using CardHouse;
using UnityEngine;

public class CreatureDrag : MonoBehaviour
{
    [Header("Arrow Setup")]
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] float maximumRange = 5f;

    [Header("Click Settings")]
    [SerializeField] LayerMask clickMask; // assign in Inspector to "Creatures"
    [SerializeField] LayerMask blockMask;
    GameObject arrow;
    Camera mainCamera;
    bool isDragging;
    Transform Head;
    private Vector3 offset;
    Arrow arrowScript;
    void Start()
    {
        mainCamera = Camera.main;
        arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.transform.SetParent(transform, worldPositionStays: true);
        arrow.SetActive(false);
        arrowScript = arrow.GetComponent<Arrow>();
        arrowScript.Init(this.GetComponent<Creature>());

    }

    void Update()
    {
        HandleMouseInput();

        if (isDragging)
        {
            UpdateArrow();
        }
    }

    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ClickedThisCreature() && GetComponent<Creature>().ownerPlayerId == PhaseManager.Instance.CurrentPlayer)
            {
                isDragging = true;
                arrow.SetActive(true);
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {   
            isDragging = false;
            if (arrowScript.block && !arrowScript.block.Occupied)
            {
                GetComponent<Creature>().MoveToBlock(arrowScript.block);
            }
            arrow.SetActive(false);

        }
    }

    bool ClickedThisCreature()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // 2D raycast for a top-down or side view
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, clickMask);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            Debug.Log("Clicked creature via raycast");
            return true;
        }

        return false;
    }

    void UpdateArrow()
    {
        arrow.transform.position = transform.position; // tail fixed
        Vector3 mouseWorld = GetMouseWorldPosition();
        Vector3 direction = mouseWorld - transform.position;


        // Rotate arrow to point toward mouse
        arrow.transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);

        // Clamp length
        float len = Mathf.Min(maximumRange, direction.magnitude);

        offset = len * direction.normalized;

        Vector3 scale = arrow.transform.localScale;
        scale.x = len;
        arrow.transform.localScale = scale;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 tail = transform.position;
        float z = mainCamera.WorldToScreenPoint(tail).z;
        return mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, z));
    }
}