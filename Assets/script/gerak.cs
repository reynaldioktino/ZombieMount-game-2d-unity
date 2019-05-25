using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerak : MonoBehaviour {
	Text infoNyawa, infoKoin;

	public int kecepatan, kekuatanLompat, pindah;
	public bool balik;

	Rigidbody2D lompat;

	public bool tanah;
	public LayerMask targetLayer;
	public Transform deteksiTanah;
	public float jangkauan;

	Animator anim;

	public int nyawa;
	public int koin;

	Vector2 mulai;

	public bool ulang;

	public GameObject menang, kalah;

	// Use this for initialization
	void Start () {
		infoNyawa = GameObject.Find ("UInyawa").GetComponent<Text> ();
		infoKoin = GameObject.Find ("UIkoin").GetComponent<Text> ();
		lompat = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		mulai = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		infoNyawa.text = "Nyawa  : " + nyawa.ToString();
		infoKoin.text = "Daging : " + koin.ToString();

		if(ulang == true) {
			transform.position = mulai;
			ulang = false;
		}

		if(nyawa <= 0) {
			Destroy (gameObject);
			kalah.SetActive (true);
		}

		if(koin >= 1) {
			menang.SetActive (true);
		}

		if (tanah == true) {
			anim.SetBool ("lompat", false);
		} else {
			anim.SetBool ("lompat",true);
		}

		tanah = Physics2D.OverlapCircle (deteksiTanah.position, jangkauan, targetLayer);

		if (Input.GetKey (KeyCode.RightArrow)) {
			anim.SetBool ("jalan", true);
			transform.Translate (Vector2.right * kecepatan * Time.deltaTime);
			pindah = -1;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			anim.SetBool ("jalan", true);
			transform.Translate (Vector2.right * -kecepatan * Time.deltaTime);
			pindah = 1;
		} else {
			anim.SetBool ("jalan",false);
		}

		if(tanah == true && Input.GetKey(KeyCode.Space)) {
			lompat.AddForce (new Vector2 (0, kekuatanLompat));
		}

		if (pindah > 0 && !balik) {
			balikBadan ();
		} else if (pindah < 0 && balik) {
			balikBadan ();
		}
	}

	void balikBadan() {
		balik = !balik;
		Vector3 karakter = transform.localScale;
		karakter.x *= -1;
		transform.localScale = karakter;
	}
}
