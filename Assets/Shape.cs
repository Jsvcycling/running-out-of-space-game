using UnityEngine;

public class Shape : MonoBehaviour {
  void Update() {
    if (Input.GetKeyDown(KeyCode.LeftArrow)) {
      transform.position += Vector3.left;

      // Make sure the new position is valid.
      if (!IsValidPosition()) transform.position += Vector3.right;

    } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
      transform.position += Vector3.right;

      // Make sure the new position is valid.
      if (!IsValidPosition()) transform.position += Vector3.left;

    } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
      transform.position += Vector3.up;

      // Make sure the new position is valid.
      if (!IsValidPosition()) transform.position += Vector3.down;

    } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
      transform.position += Vector3.down;

      // make sure the new position is valid.
      if (!IsValidPosition()) transform.position += Vector3.up;

    } else if (Input.GetKeyDown(KeyCode.Space)) {
      // Place the blocks on the board.
      UpdateBoard();
    }
  }

  bool IsValidPosition() {
    return false;
  }

  void UpdateBoard() {
    // TODO
  }
}
