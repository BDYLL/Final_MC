using UnityEngine;
using System.Collections.Generic;

public class Pathfinding {

	public static List<Node> Breadthwise(Node start, Node end){

		Queue<Node> working = new Queue<Node> ();
		List<Node> visited = new List<Node> ();

		start.history = new List<Node> ();
		working.Enqueue (start);

		while(working.Count > 0){
			Node current = working.Dequeue ();
			if(current == end) {
				List<Node> result = current.history;
				result.Add (current);
				return result;
			} else {
				visited.Add (current);
				for(int i = 0; i < current.neighbors.Length; i++){
					Node currentChild = current.neighbors[i];
					if(!visited.Contains(currentChild)){
						working.Enqueue (currentChild);
						currentChild.history = new List<Node> (current.history);
						currentChild.history.Add (current);
					}
				}
			}
		}

		return null;
	}

}
