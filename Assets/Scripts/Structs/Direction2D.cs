using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Direction2D {
    public Vector2 Direction, DirectionX, DirectionY;
    public Direction2D(float x, float y) {
        DirectionX = Vector2.zero;
        DirectionY = Vector2.zero;
        Direction = Vector2.zero;
        if (x < 0) {
            DirectionX = Vector3.left;
        }
        else if (x > 0) {
            DirectionX = Vector3.right;
        }
        if (x < 0.2f && x > -0.2f) {
            DirectionX = Vector2.zero;
        }
        if (y < 0) {
            DirectionY = Vector3.down;
        }
        else if (y > 0) {
            DirectionY = Vector3.up;
        }
        if (y < 0.2f && y > -0.2f) {
            DirectionY = Vector2.zero;
        }
        Direction = DirectionX + DirectionY;
    }
}