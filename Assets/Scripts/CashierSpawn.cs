using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierSpawn : MonoBehaviour {

	public Vector3[] spawnPositions;
	public GameObject[] characters;

	// Use this for initialization
	void Start () {
		//spawnCashiers (8);
	}

	// Update is called once per frame
	void Update () {

	}

	public void spawnCashiers(int cashiers){
		int i = 0;
		int index;
		while (i < cashiers) {
			index = (int)(Random.Range (0.0f, 1.5f));
			//Debug.Log ("Index : "+index);
			GameObject people = Instantiate (characters[0], spawnPositions[i], this.transform.rotation);
			i++;
		}
	}
}
