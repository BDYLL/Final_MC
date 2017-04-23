using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterPath : MonoBehaviour {

	public Node start, end;
	List<Node> path;
	int currentNode;
	public float threshold;

	// Use this for initialization
	void Start () {
		path = Pathfinding.Breadthwise(start, end);
		for (int i = 0; i < path.Count; i++) {
			Debug.Log (path[i].transform.name);
		}
		currentNode = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.LookAt (path [currentNode].transform);
		transform.Translate (transform.forward * Time.deltaTime * 5, Space.World);
		float distance = Vector3.Distance (transform.position, 
											path [currentNode].transform.position);
		if(distance < threshold){

			if (currentNode == path.Count - 1) {
			
				Destroy (this);
			}
			currentNode++;
		}
	}
}
