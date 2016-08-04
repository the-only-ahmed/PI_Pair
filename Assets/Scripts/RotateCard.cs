using UnityEngine;
using System.Collections;

public class RotateCard : MonoBehaviour {

	private bool turn = false;

	void OnMouseDown () {
		print (transform.rotation.eulerAngles.y);
		turn = true;
	}

	void Update() {
		if (turn) {
			if (transform.rotation.eulerAngles.y < 180)
				transform.Rotate (0, 75 * Time.deltaTime, 0);
			else
				turn = false;
		}
	}
}