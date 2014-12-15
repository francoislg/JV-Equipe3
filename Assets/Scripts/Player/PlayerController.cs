using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float constantSpeed;

    float camRayLength = 100f;
    Rigidbody playerRigidbody;
	GameObject levelEnd;
	GameObject gameEnd;
	PlayerStatus status;
    GameObject playerModel;
	ScreenFader fader;

	void Start() {
		levelEnd = GameObject.FindGameObjectWithTag("levelEnd");
		gameEnd = GameObject.FindGameObjectWithTag("gameEnd");
		status = GetComponent<PlayerStatus>() as PlayerStatus;
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
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
			Application.LoadLevel("GameScene");
		}

		if (gameFinished()) {
			EndGameMenu.finalScore = PlayerStatus.score;
			Application.LoadLevel("EndGameScene");
		}

    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * (constantSpeed + status.speed);
        if (movement.magnitude > 0)
            playerModel.animation.Play("run");
        else
            playerModel.animation.Play("Idle");
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
		return( (playerRigidbody.transform.position - levelEnd.transform.position).magnitude < 2.0 );
	}

	bool gameFinished() {
		return( (playerRigidbody.transform.position - gameEnd.transform.position).magnitude < 2.0 );
	}
}
