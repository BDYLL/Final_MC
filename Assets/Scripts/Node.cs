using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

	public Node[] neighbors;
	public List<Node> history;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position, 0.2f);
		Gizmos.color = Color.blue;
		for(int i = 0; i < neighbors.Length; i++){
			Gizmos.DrawLine (transform.position, neighbors [i].transform.position);
		}
	}
}
