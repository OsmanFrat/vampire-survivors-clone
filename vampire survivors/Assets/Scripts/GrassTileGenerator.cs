using UnityEngine;
using UnityEngine.Tilemaps;

public class GrassTileGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;
    public Transform player;
    public int viewDistanceX = 10; 
    public int viewDistanceY = 5; 

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
        for (int x = -viewDistanceX; x <= viewDistanceX; x++)
        {
            for (int y = -viewDistanceY; y <= viewDistanceY; y++)
            {
                Vector3Int tilePosition = new Vector3Int(playerCell.x + x, playerCell.y + y, 0);
                if (!tilemap.HasTile(tilePosition))
                {
                    tilemap.SetTile(tilePosition, tile);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        if (tilemap == null || player == null) return;

        Gizmos.color = Color.green;
        Vector3Int playerCell = tilemap.WorldToCell(player.position);

        
        for (int x = -viewDistanceX; x <= viewDistanceX; x++)
        {
            for (int y = -viewDistanceY; y <= viewDistanceY; y++)
            {
                Vector3Int tilePosition = new Vector3Int(playerCell.x + x, playerCell.y + y, 0);
                Vector3 tileWorldPosition = tilemap.CellToWorld(tilePosition) + tilemap.tileAnchor;
                Gizmos.DrawWireCube(tileWorldPosition, Vector3.one);
            }
        }
    }
}
