using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    private Tilemap TileMapGround;
    private Tilemap TileMapBorder;

    public int Width;
    public int Height;
    public Tile[] GroundTiles;
    public Tile[] BorderTiles;

    // Start is called before the first frame update
    void Start()
    {
        TileMapGround = GetComponentsInChildren<Tilemap>(true)
            .FirstOrDefault(tm => tm.name == "Ground");
        TileMapBorder = GetComponentsInChildren<Tilemap>(true)
            .FirstOrDefault(tm => tm.name == "CantWalk");

        for (int y = 0; y < Height; ++y)
        {
            for(int x = 0; x < Width; ++x)
            {
                Tile GroundTile = null;
                Tile BorderTile = null;
              
                if(x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                {
                    BorderTile = BorderTiles[Random.Range(0, BorderTiles.Length)];
                }

                    GroundTile = GroundTiles[Random.Range(0, GroundTiles.Length)];

              
                if (GroundTile != null) TileMapGround.SetTile(new Vector3Int(x, y, 0), GroundTile);
                if (BorderTile != null) TileMapBorder.SetTile(new Vector3Int(x, y, 0), BorderTile);
            }
        }
    }

}