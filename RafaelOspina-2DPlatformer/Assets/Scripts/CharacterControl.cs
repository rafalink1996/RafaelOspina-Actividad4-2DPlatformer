using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para usar el UI

public class CharacterControl : MonoBehaviour {

	public float speed;
	int coins = 0; // cantidad de monedas
	int hearts = 3;
	int stars = 0;
	public Text contadorCoins;
	public Text contadorHearts;
	public Text contadorStars;
	public float jumpForce;
	bool isGrounded = false;
	Animator anim;
	public AudioClip coin;
	public AudioClip heart;
	public AudioClip jump;
	public AudioClip star;
	public AudioClip hit;
	public AudioClip death;
	public AudioClip finish;
	//public float volume;
	AudioSource audio;
	bool isAlive = true;
	int deathTimer = 1;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		audio = GetComponent <AudioSource> ();
	}

	/*public void clickEnElBoton() {
		this.gameObject.GetComponent <Rigidbody2D> ().AddForce (Vector2.up * 8, ForceMode2D.Impulse); // permite saltar presionando el boton de la pantalla
	}*/
	
	// Update is called once per frame
	void Update () {
		//en el componente de rigidbody 2d tenemos que activar el constraint en el eje Z para que no rote y el movimiento quede bien
		//movimiento a la derecha
		if (Input.GetKey (KeyCode.RightArrow) && isAlive == true) {
			this.gameObject.transform.Translate (speed * Time.deltaTime, 0, 0);
			anim.SetBool ("Right", true);
			anim.SetBool ("Left", false);
			//this.gameObject.transform.Translate (Vector2.left * -speed * Time.deltaTime, Space.World); // esta es otra opcion
		}
		//movimiento a la izquierda
		if (Input.GetKey (KeyCode.LeftArrow) && isAlive == true) {
			this.gameObject.transform.Translate (-speed * Time.deltaTime, 0, 0);
			anim.SetBool ("Right", false);
			anim.SetBool ("Left", true);
			//this.gameObject.transform.Translate (Vector2.right * -speed * Time.deltaTime, Space.World); // esta es otra opcion
		} 
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			anim.SetBool ("isMoving", true);
		} else {
			anim.SetBool ("isMoving", false);
		}
		//salto
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true && isAlive == true) {
			this.gameObject.GetComponent <Rigidbody2D> ().AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse); // le agregamos una fuerza hacia arriba
			audio.PlayOneShot (jump, 1);
		}
		if (hearts == 0) {
			isAlive = false;
			anim.SetBool ("Dead", true);
		}
		if (isAlive == false) {
			deathTimer = deathTimer - 1;
		}
		if (deathTimer == 0) {
			audio.PlayOneShot (death, 3);
		}
	}
	//Cuando el collider 2D del gameObject colisiona con otro collider 2D
	// Es muy importante que sea 2D. Si es 3D no se detecta
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Coins") { //Detectamos colision solo con monedas
			// aumentar la cantidad de monedas
			coins = coins + 1;
			// mostramos la cantidad de monedas usando el componente Text
			contadorCoins.text = coins.ToString();

			audio.PlayOneShot (coin, 1);

			//Destruimos la moneda
			GameObject.Destroy (coll.gameObject);
		}
		if (coll.gameObject.tag == "Hearts") { //Detectamos colision solo con monedas
			// aumentar la cantidad de monedas
			hearts = hearts + 1;
			// mostramos la cantidad de monedas usando el componente Text
			contadorHearts.text = hearts.ToString();

			audio.PlayOneShot (heart, 3);

			//Destruimos la moneda
			GameObject.Destroy (coll.gameObject);
		}
		if (coll.gameObject.tag == "Stars") { //Detectamos colision solo con monedas
			// aumentar la cantidad de monedas
			stars = stars + 1;
			// mostramos la cantidad de monedas usando el componente Text
			contadorStars.text = stars.ToString();

			audio.PlayOneShot (star, 1);

			//Destruimos la moneda
			GameObject.Destroy (coll.gameObject);
		}
		if (coll.gameObject.tag == "Death") {
			isAlive = false;
		}
		if (coll.gameObject.tag == "Finish") {
			audio.PlayOneShot (finish, 8);
			GameObject.Destroy (coll.gameObject);
		}
	}
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.collider.gameObject.tag == "Ground") {
			isGrounded = true;
			anim.SetBool ("Jump", false);
		}
		if (collision.collider.gameObject.tag == "Enemies") {
			hearts = hearts - 1;
			contadorHearts.text = hearts.ToString ();
			this.gameObject.GetComponent <Rigidbody2D> ().AddForce (Vector2.left * 12, ForceMode2D.Impulse);
			audio.PlayOneShot (hit, 1);
			GameObject.Destroy (collision.gameObject);
		}
	}
	void OnCollisionExit2D (Collision2D collision) {
		if (collision.collider.gameObject.tag == "Ground") {
			isGrounded = false;
			anim.SetBool ("Jump", true);
		}
	}

}
