using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daging : MonoBehaviour {

	private	PlayerInventoryDisplay playerInventoryDisplay;	
	private	int	totalStars = 0;
	// Use this for initialization
	void Start () {
		playerInventoryDisplay = GetComponent<PlayerInventoryDisplay> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D	hit)	
	{	
		if	(hit.CompareTag("daging"))	
		{	
			totalStars++;	
			playerInventoryDisplay.OnChangeStarTotal(totalStars);	
			Destroy(hit.gameObject);	
		}	
	}	

}
