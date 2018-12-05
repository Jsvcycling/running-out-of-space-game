﻿using UnityEngine;

public class GameController : MonoBehaviour {
  public int boardWidth = 10;
  public int boardHeight = 10;

  public int score = 0;

  public GameObject[] shapes;

  public Transform[,] grid;

  public static Vector2 RoundVector2(Vector2 v) {
    return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
  }

  void Start() {
    grid = new Transform[boardWidth, boardHeight];

    SpawnNewShape();
  }

  public void FixedUpdate() {
    for (int i = 0; i < boardHeight; i++) {
      if (IsRowFull(i)) {
        DeleteRow(i);
        score += 1;
      }
    }

    for (int i = 0; i < boardWidth; i++) {
      if (IsColumnFull(i)) {
        DeleteColumn(i);
        score += 1;
      }
    }
  }

  // Delete all elements in a row.
  void DeleteRow(int row) {
    for (int i = 0; i < boardWidth; i++) {
      if (grid[i, row] != null) {
        Object.Destroy(grid[i, row].gameObject);
        grid[i, row] = null;
      }
    }
  }

  // Delete all elements in a column.
  void DeleteColumn(int col) {
    for (int i = 0; i < boardHeight; i++) {
      if (grid[col, i] != null) {
        Object.Destroy(grid[col, i].gameObject);
        grid[col, i] = null;
      }
    }
  }

  // Check to see if the selected row is full.
  bool IsRowFull(int row) {
    for (int i = 0; i < boardWidth; i++) {
      if (grid[i, row] == null) return false;
    }

    return true;
  }

  // Check to see if the selected column is full.
  bool IsColumnFull(int col) {
    for (int i = 0; i < boardHeight; i++) {
      if (grid[col, i] == null) return false;
    }

    return true;
  }

  public void SpawnNewShape() {
    if (shapes.Length > 0) {
      int idx = Random.Range(0, shapes.Length);

      // TODO: Spawn it in different orientations.
      Instantiate(shapes[idx], transform.position, Quaternion.identity);
    }
  }
}