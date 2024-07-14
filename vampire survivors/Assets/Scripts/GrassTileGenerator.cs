using UnityEngine;
using UnityEngine.Tilemaps;

public class GrassTileGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;
    public Transform player;
    public int viewDistance = 10;

    private Vector3Int previousPlayerCell;

    void Start()
    {
        previousPlayerCell = tilemap.WorldToCell(player.position);
        GenerateInitialTiles();
    }

    void Update()
    {
        Vector3Int currentPlayerCell = tilemap.WorldToCell(player.position);
        if (currentPlayerCell != previousPlayerCell)
        {
            GenerateTilesAroundPlayer(currentPlayerCell);
            previousPlayerCell = currentPlayerCell;
        }
    }

    void GenerateInitialTiles()
    {
        Vector3Int playerCell = tilemap.WorldToCell(player.position);
        GenerateTilesAroundPlayer(playerCell);
    }

    void GenerateTilesAroundPlayer(Vector3Int playerCell)
    {
        for (int x = -viewDistance; x <= viewDistance; x++)
        {
            for (int y = -viewDistance; y <= viewDistance; y++)
            {
                Vector3Int tilePosition = new Vector3Int(playerCell.x + x, playerCell.y + y, 0);
                if (!tilemap.HasTile(tilePosition))
                {
                    tilemap.SetTile(tilePosition, tile);
                }
            }
        }
    }
}
