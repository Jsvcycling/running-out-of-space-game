using UnityEngine;

public class Shape : MonoBehaviour {
  GameController controller;

  bool isActive;

  void Start() {
    controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    isActive = true;
  }

  void Update() {
    if (isActive) {
      if (Input.GetKeyDown(KeyCode.LeftArrow)) {
        transform.position += Vector3.left;

        // Make sure the new position is valid.
        if (!CanMove()) transform.position += Vector3.right;

      } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
        transform.position += Vector3.right;

        // Make sure the new position is valid.
        if (!CanMove()) transform.position += Vector3.left;

      } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
        transform.position += Vector3.up;

        // Make sure the new position is valid.
        if (!CanMove()) transform.position += Vector3.down;

      } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
        transform.position += Vector3.down;

        // make sure the new position is valid.
        if (!CanMove()) transform.position += Vector3.up;

      } else if (Input.GetKeyDown(KeyCode.Space)) {
        // Place the blocks on the board.
        if (CanPlace()) UpdateBoard();
      }
    }
  }

  // Can we move the shape here?
  bool CanMove() {
    foreach (Transform child in this.transform) {
      Vector2 pos = GameController.RoundVector2(child.position);

      if (!controller.IsValidPosition(pos)) return false;
    }

    return true;
  }

  // Can we move the shape here and put it down?
  bool CanPlace() {
    foreach (Transform child in this.transform) {
      Vector2 pos = GameController.RoundVector2(child.position);

      if (!controller.IsValidPosition(pos)) return false;

      if (controller.grid[(int)pos.x, (int)pos.y] != null) {
        return false;
      }
    }

    

    return true;
  }

  // Put down the shape.
  void UpdateBoard() {
    foreach (Transform child in this.transform) {
      Vector2 pos = GameController.RoundVector2(child.position);
      controller.grid[(int)pos.x, (int)pos.y] = child;
    }

    isActive = false;

    controller.CheckBoard();

    controller.SpawnNewShape();
  }
}
