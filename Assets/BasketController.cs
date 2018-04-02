using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Apple") {
			// りんご
		} else {
			// 爆弾
		}
		Destroy (other.gameObject); // otherはぶつかってきたItemのコライダー(other.gameObjectでGameObjectの参照ができる)
	}

	// Use this for initialization
	void Start () {
		
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
