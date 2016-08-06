using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void cardTurned(GameObject obj);

public class GameManager : MonoBehaviour {

	[SerializeField]private List<Texture2D> cards_temp = new List<Texture2D>();
	[SerializeField]private List<Transform> Deck = new List<Transform>();

	private Dictionary<Texture2D, int> cards = new Dictionary<Texture2D, int> ();

	private Texture lastTurned = null;
	private GameObject lastObj = null;

	void Start () {
		foreach (Texture2D card in cards_temp)
			cards.Add (card, 2);

		assignCards ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void assignCards() {
		foreach(Transform child in Deck) {
			Material mat = child.FindChild ("back").gameObject.GetComponent<MeshRenderer>().material;

			do {
				int rand = Random.Range (0, cards_temp.Count - 1);
				if (cards[cards_temp[rand]] > 0) {
					cards[cards_temp[rand]] -= 1;
					mat.mainTexture = cards_temp[rand];
					break;
				} else
					cards_temp.RemoveAt(rand);
			} while (true);
		}
	}

	#region Events
	void OnEnable() {
		RotateCard.onCardTurnedHandler += checkCard;
	}

	void OnDesable() {
		RotateCard.onCardTurnedHandler -= checkCard;
	}

	private void checkCard(GameObject obj) {
		Texture tex = obj.transform.FindChild ("back").gameObject.GetComponent<MeshRenderer> ().material.mainTexture;

		if (lastTurned == null) {
			lastTurned = tex;
			lastObj = obj;
		} else if (lastTurned == tex) {
			lastTurned = null;
			lastObj = null;
		} else {
			obj.GetComponent<RotateCard> ().setTurn (true);
			lastTurned = null;
			if (lastObj != null)
				lastObj.GetComponent<RotateCard> ().setTurn (true);
		}
	}
	#endregion
}