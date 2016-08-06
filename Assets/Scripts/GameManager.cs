using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	[SerializeField]private List<Texture2D> cards_temp = new List<Texture2D>();
	[SerializeField]private Transform Deck;

	private Dictionary<Texture2D, int> cards = new Dictionary<Texture2D, int> ();

	void Start () {
		foreach (Texture2D card in cards_temp)
			cards.Add (card, 2);

		print (Deck);

		assignCards ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void assignCards() {
		foreach (Transform card in Deck) {
			Material mat = card.FindChild ("back").gameObject.GetComponent<MeshRenderer>().material;

			do {
				int rand = Random.Range (0, cards_temp.Count - 1);
				if (cards[cards_temp[rand]] > 0) {
					cards[cards_temp[rand]]--;
					mat.mainTexture = cards_temp[rand];
					break;
				}
			} while (true);
		}
	}
}