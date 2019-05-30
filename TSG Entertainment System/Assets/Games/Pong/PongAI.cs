    using UnityEngine;
    using System.Collections;
     
    public class PongAI : MonoBehaviour {
        public GameObject Ball;
		public GameObject Bot;
		private Rigidbody2D Botrb;
        public Transform CurrentTransform;
        public float speed = 1.5f;
        // Use this for initialization
        void Start () {
            CurrentTransform = Bot.transform;
			Botrb = Bot.GetComponent<Rigidbody2D>();
        }
     
        // Update is called once per frame
        void FixedUpdate () {
			Botrb = Bot.GetComponent<Rigidbody2D>();
            CurrentTransform = Bot.transform;
            if (CurrentTransform.position.x < Ball.transform.position.x) {
                if (CurrentTransform.position.y < Ball.transform.position.y) {
                    //Bot.GetComponent<Rigidbody2D>
					Botrb.velocity = new Vector2 (0, 1) * speed;
                } else if (CurrentTransform.position.y > Ball.transform.position.y) {
                    //Bot.GetComponent<Rigidbody2D>
					Botrb.velocity = new Vector2 (0, -1) * speed;
                } else {
                    //Bot.GetComponent<Rigidbody2D>
					Botrb.velocity = new Vector2 (0, 0) * speed;
                }
            }
        }
    }
