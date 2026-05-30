using UnityEngine;

public class TileCursor : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

    void OnEnable()
    {
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        StopListeningToTilesIn(TargetGrid);
    }

    public void ListenToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.AddListener(HandleTileEntered);
        }
    }

    public void HandleTileEntered(TileController tile)
    {
        transform.position = tile.transform.position;
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.RemoveListener(HandleTileEntered);
        }
    }
}
