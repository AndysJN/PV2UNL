using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    public class CellData
    {
        public bool Spawneable;
    }

    private CellData[,] BoardData;
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
        
        BoardData = new CellData[Width, Height];

        for (int y = 0; y < Height; ++y)
        {
            for(int x = 0; x < Width; ++x)
            {
                Tile BorderTile = null;
                BoardData[x,y] = new CellData();
              
                if(x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                {
                    BorderTile = BorderTiles[Random.Range(0, BorderTiles.Length)];
                    BoardData[x,y].Spawneable = false;
                }
                // else
                // {
                //     BoardData[x,y].Spawneable = true; //A futuro puedo definir aca donde spawnearan los comestibles / enemigos. No Quiero que spawneen en los bordes de la pantalla...
                // }

                Tile GroundTile = GroundTiles[Random.Range(0, GroundTiles.Length)];

              
                TileMapGround.SetTile(new Vector3Int(x, y, 0), GroundTile);
                if (BorderTile != null) TileMapBorder.SetTile(new Vector3Int(x, y, 0), BorderTile);
            }
        }
    }

}