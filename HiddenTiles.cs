using Godot;
using System;

public class HiddenTiles : TileMap
{

    public override void _Ready()
    {
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        var c = Color.Color8(255, 255, 255, 170);
        if (true)
        {
            //TileSet.TileSetModulate(2, c);
            //TileSet.TileSetModulate(3, c);
            //System.Console.WriteLine(TileSet.TileGetModulate(2));
            // System.Console.WriteLine(TileSet.TileGetName(2));
            //TileSet.TileSetZIndex(2, 0);
            Vector2 test = new Vector2(0, 0);
            //System.Console.WriteLine(WorldToMap(test));



        }
    }
}
