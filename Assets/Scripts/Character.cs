using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float speed;
	public float threshold;
	public Node currentNode;
	private int nextNodeIndex;
	private Node next;
	private Node[] trajectory;
	private Node[] cashiers;
	private GameObject path;

	// Use this for initialization
	void Start () {
		path = GameObject.Find("Path");
		trajectory = path.GetComponentsInChildren<Node>();
		cashiers = GameObject.Find("Cashiers").GetComponentsInChildren<Node>();
		next = trajectory[0];
		nextNodeIndex = 0;
		StartCoroutine (CheckIfChange ());
	}
	
	// Update is called once per frame
	void Update () {
		path = GameObject.Find("Path");
		if(!next.bussy || next.occupiedBy == this.gameObject.GetInstanceID()){
			transform.LookAt(next.transform);
			transform.rotation = new Quaternion(0,0,transform.rotation.z,0);
			transform.position = Vector2.MoveTowards(transform.position, next.transform.position, Time.deltaTime * speed);
		}else{

		}
	}

	IEnumerator CheckIfChange(){
		while (true) {
			float distance = Vector3.Distance (transform.position, next.transform.position);
			if (distance < threshold) {
				nextNodeIndex++;
				if(next.cashier){
					next.bussy=false;
					next.occupiedBy = 0;
					Destroy(this.gameObject);
				}
				else if(nextNodeIndex >= trajectory.Length){
					for(int i=0; i<cashiers.Length; i++){
						if(!cashiers[i].bussy){
							next = cashiers[i];
						}
					}
				}else{
					next = trajectory[nextNodeIndex];
				}
				currentNode = next;
			}
			yield return new WaitForSeconds (0.02f);
		}
	}
}