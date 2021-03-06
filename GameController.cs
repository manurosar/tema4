using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	static public GameController S;	
	public GameObject pajaroPrefab;
	public GameObject cestaPrefab;
	public GameObject GusanoPrefab;
	public GameObject manzanaPrefab;
	public float limite = 5;

	public float cestaBottomY = -16f;

	public float tiempoSalida;
	public float c;
	GameObject cesta;

	GameObject pajaro;


	// Use this for initialization
	void Start () {
		S = this;
		InvokeRepeating( "Pajaro", 5f, 8f );

			cesta = Instantiate( cestaPrefab ) as GameObject;
			
			




		InvokeRepeating( "Pajaro", 5f, 8f );
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (Input.GetAxis ("Fire1")==1  && tiempoSalida< Time.time ){
			tiempoSalida = Time.time + 0.5f;
			GameObject gusano = Instantiate( GusanoPrefab ) as GameObject;
			gusano.transform.position = cesta.transform.position;
		}
	}

	void Pajaro() {
		pajaro = Instantiate( pajaroPrefab ) as GameObject;

		float y = Random.Range (-2, 11);

		if (y > 5) {
			c = -1;
		}else{
			c = 1;
			}
			pajaro.transform.position = new Vector3(c*calcularLimite(),y,0);
		InvokeRepeating( "manzana", 1f, 1f );
			
	}
	void manzana()	{
		GameObject manzana = Instantiate( manzanaPrefab) as GameObject;
		manzana.transform.position = pajaro.transform.position;
	}

	public void AppleDestroyed(){
		

			SceneManager.LoadScene ("INICIO");
		}


	public float calcularLimite(){
		Vector3 limite = Camera.main.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		Debug.Log (limite);
		return limite.x;
	}	

}
