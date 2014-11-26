using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float constantSpeed;

    float camRayLength = 100f;
    Rigidbody playerRigidbody;
	GameObject levelEnd;
	PlayerStatus status;

	void Start() {
		levelEnd = GameObject.FindGameObjectWithTag("levelEnd");
		status = GetComponent<PlayerStatus>() as PlayerStatus;
	}

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Turn();

		if (levelFinished()) {
			// comportement à coder quand le niveau de boss sera prêt (passer en paramètre le prochain niveau à loader).
			Application.LoadLevel("GameScene");
		}

    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * (constantSpeed + status.speed);
    }

    void Turn()
    {
        //rayon de la souris à l'écran en direction de la camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        // si le raycast atteint qqchose
        if (Physics.Raycast(camRay, out floorHit, camRayLength))
        {
            // vecteur de player au point du plancher frappé par le raycast
            Vector3 playerToMouse = floorHit.point - transform.position;

            // rester en y
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

	bool levelFinished() {
		return( (playerRigidbody.transform.position - levelEnd.transform.position).magnitude < 1.0 );
	}

}
