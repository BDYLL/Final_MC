using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject character;
	public float arrivalTime;
	public float waitTime;
	public Queue<GameObject> queue;
    // Use this for initialization
    void Start () {
		double x = Distributions.Poisson(0.15);
		Debug.Log (x);
    }
	
	IEnumerator Spawn(float waitTime)
	{
		while (true)
		{
			yield return new WaitForSeconds(waitTime);

		}
	}
}
