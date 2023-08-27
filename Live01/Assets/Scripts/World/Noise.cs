using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise {
    private static float frequency = 0.01f;
    private static float amplitude = 50.0f;
    private static float heightOffset = 63.0f;
    private static int seed;

    public static float Perlin(float x, float z) {
        x *= frequency;
        z *= frequency;

        x += seed;
        z += seed;

        float y = Mathf.PerlinNoise(x, z);
        y *= amplitude;
        y += heightOffset;

        return y;
    }
}
