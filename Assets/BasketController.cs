using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

	// アウトレット接続
	public AudioClip appleSE;
	public AudioClip bombSE;
	AudioSource aud;
	GameObject director;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Apple") {
			// りんご
			this.aud.PlayOneShot(this.appleSE);
			this.director.GetComponent<GameDirector>().GetApple();
		} else {
			// 爆弾
			this.aud.PlayOneShot(this.bombSE);
			this.director.GetComponent<GameDirector>().GetBomb();
		}
		Destroy (other.gameObject); // otherはぶつかってきたItemのコライダー(other.gameObjectでGameObjectの参照ができる)
	}

	// Use this for initialization
	void Start () {
		this.aud = GetComponent<AudioSource> (); // GUI上で音楽を直接指定するのではなく、スクリプトで。複数の音源が使えるように。
		this.director = GameObject.Find("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			// out: メソッド内で hitに値を代入するというキーワード
			// rayがコライダーとぶつかったら値を返却する
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				float x = Mathf.RoundToInt (hit.point.x); // 四捨五入
				float z = Mathf.RoundToInt (hit.point.z); // 四捨五入
				transform.position = new Vector3 (x, 0, z);
			}
		}
		
	}
}
