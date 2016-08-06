using UnityEngine;
using System.Collections;

public class RotateCard : MonoBehaviour {

	public static event cardTurned onCardTurnedHandler;

	private bool turnByUser = false;
	private bool turnByCPU = false;

	void OnMouseDown () {
		turnByUser = true;
	}

	public void setTurn(bool b) {
		turnByCPU = b;
	}

	void Update() {
		if (turnByUser) {
			if (transform.rotation.eulerAngles.y < 180)
				transform.Rotate (0, 75 * Time.deltaTime, 0);
			else {
				turnByUser = false;
				onCardTurnedHandler (gameObject);

				Quaternion temp = transform.rotation;
				temp.eulerAngles = new Vector3(0, 180, 0);
				transform.rotation = temp;
			}
		} else if (turnByCPU) {
			if (transform.rotation.eulerAngles.y > 0 && transform.rotation.eulerAngles.y <= 180)
				transform.Rotate (0, -75 * Time.deltaTime, 0);
			else {
				turnByCPU = false;

				Quaternion temp = transform.rotation;
				temp.eulerAngles = new Vector3(0, 0, 0);
				transform.rotation = temp;
			}
		}
	}
}