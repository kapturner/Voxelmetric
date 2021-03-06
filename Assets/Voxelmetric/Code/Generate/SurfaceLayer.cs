﻿using System;
using SimplexNoise;
using UnityEngine;
public class SurfaceLayer : TerrainLayer
{
    // Right now this acts just like additive layer but always set to one block thickness
    // but it's a placeholder so that in the future we can do things like blend surface layers
    // between separate biomes

    Block blockToPlace;

    protected override void SetUp(LayerConfig config)
    {
        blockToPlace = Block.New(properties["blockName"], world);

        if (properties.ContainsKey("blockColors"))
        {
            string[] colors = properties["blockColors"].Split(',');
            ((ColoredBlock)blockToPlace).color = new Color(byte.Parse(colors[0]) / 255f, byte.Parse(colors[1]) / 255f, byte.Parse(colors[2]) / 255f);
        }
    }

    public override int GenerateLayer(Chunk chunk, int x, int z, int heightSoFar, float strength, bool justGetHeight = false)
    {

        //If we're not just getting the height apply the changes
        if (!justGetHeight)
        {
            SetBlocksColumn(chunk, x, z, heightSoFar, heightSoFar + 1, blockToPlace);
        }

        return heightSoFar + 1;
    }
}
