using Unity.VisualScripting;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public int x, y;
    public DraggableRank currentRank;
    public SpriteRenderer cellRenderers;

    public void Initialize(int gridX, int gridY)
    {
        x = gridX;
        y = gridY;
        name = "Cell " + x + "," + y;

    }

    public bool IsEmpty()
    {
        return currentRank == null;
    }

    public bool ContainsPosition(Vector3 position)
    {
        Bounds bounds = cellRenderers.bounds;
        return bounds.Contains(position);
    }

    public void SetRank(DraggableRank rank)
    {
        currentRank = rank;
        if (rank != null)
        {
            rank.currentCell = this;
        }
        rank.originalPosition = new Vector3(transform.position.x, transform.position.y, 0);
        rank.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
