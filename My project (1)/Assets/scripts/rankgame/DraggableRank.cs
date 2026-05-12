using UnityEngine;
using UnityEditor;

public class DraggableRank : MonoBehaviour
{
    public int rankValue = 1;
    public float dragSpeed = 30f;
    public float snapBackSpeed = 20f;

    public bool isDragging = false;

    public Vector3 originalPosition;
    public GridCell currentCell;

    public Camera mainCamera;
    public Vector3 dragOffset;
    public SpriteRenderer spriteRenderer;

    public RankGameManager GameManager;
    private object rankLevel;


    private void Awake()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameManager = GetComponent<RankGameManager>();
    }
    void Start()
    {
        originalPosition = transform.position;
    }

    void StartDragging()
    {
        isDragging = true;
        dragOffset = transform.position - GetMouseWorldPosition();
        spriteRenderer.sortingOrder = 0;
    }

    void StopDragging()
    {
        isDragging=false;
        spriteRenderer.sortingOrder = 1;
        GridCell targetCell = GameManager.FindClosesteCell(transform.position);

        if (targetCell != null )
        {
            if(targetCell.currentRank == null)
            {
                MoveToCell(targetCell);
            }
            else if (targetCell.currentRank != this && targetCell.currentRank.rankLevel == rankLevel)
            {
                MergeWithCell(targetCell);
            }
            else
            {
                RturnToOriginalPosition();
            }
        }
        else
        {
            RturnToOriginalPosition();

        }
    }

    public void MoveToCell(GridCell tagetCell)
    {
        if (currentCell != null)
        {
            currentCell.currentRank = null;
        }

        currentCell = tagetCell;
        tagetCell.currentRank = this;

        originalPosition = new Vector3(tagetCell.transform.position.x, tagetCell.transform.position.y, 0);
        transform.position = originalPosition;
    }

    public void RturnToOriginalPosition()
    {
        transform.position = originalPosition;
    }

    public void MergeWithCell(GridCell tagetCell)
    {
        if (tagetCell.currentRank == null || tagetCell.currentRank.rankLevel != rankLevel)
        {
            RturnToOriginalPosition();
            return;
        }

        if(currentCell != null)
        {
            currentCell.currentRank = this;
        }
    }

    public Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }

    public void SetRankLevel(int level)
    {
        rankLevel = level;

        if (GameManager != null && GameManager.rankSprites.Length > level - 1)
        {
            spriteRenderer.sprite = GameManager.rankSprites[level - 1];
        }
    }

}
