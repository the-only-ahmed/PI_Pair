using UnityEngine;
using System.Collections;

public class RotateCard : MonoBehaviour {

	public static event cardTurned onCardTurnedHandler;

	private bool turnByUser = false;
	private bool turnByCPU = false;

	void OnMouseDown () {
		onCardTurnedHandler (gameObject);
		turnByUser = true;
	}

	public void setTurn(bool b) {
		turnByCPU = b;
	}

	void Update() {
		if (turnByUser) {
			if (transform.rotation.eulerAngles.y < 180)
				transform.Rotate (0, 75 * Time.deltaTime, 0);
			else
				turnByUser = false;
		} else if (turnByCPU) {
			if (transform.rotation.eulerAngles.y > 0)
				transform.Rotate (0, -75 * Time.deltaTime, 0);
			else
				turnByCPU = false;
		}
	}
}