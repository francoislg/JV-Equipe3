using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float CamRayLength = 100f;

    public float constantSpeed;

    Rigidbody _playerRigidbody;
    GameObject _levelEnd;
    GameObject _gameEnd;
    PlayerStatus _status;
    GameObject _playerModel;

    void Start()
    {
        _levelEnd = GameObject.FindGameObjectWithTag("levelEnd");
        _gameEnd = GameObject.FindGameObjectWithTag("gameEnd");
        _status = GetComponent<PlayerStatus>();
        _playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
    }

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Turn();

        if (IsLevelFinished())
        {
            Application.LoadLevel("GameScene");
        }

        if (IsGameFinished())
        {
            EndGameMenu.finalScore = PlayerStatus.Score;
            Application.LoadLevel("EndGameScene");
        }
    }

    void Move()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * (constantSpeed + _status.Speed);
        _playerModel.animation.Play(movement.magnitude > 0 ? "run" : "Idle");
    }

    void Turn()
    {
        //rayon de la souris à l'écran en direction de la camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        // si le raycast atteint qqchose
        if (Physics.Raycast(camRay, out floorHit, CamRayLength))
        {
            // vecteur de player au point du plancher frappé par le raycast
            Vector3 playerToMouse = floorHit.point - transform.position;

            // rester en y
            playerToMouse.y = 0f;
            _playerRigidbody.MoveRotation(Quaternion.LookRotation(playerToMouse));
        }
    }

    bool IsLevelFinished()
    {
        return ((_playerRigidbody.transform.position - _levelEnd.transform.position).magnitude < 2.0);
    }

    bool IsGameFinished()
    {
        return ((_playerRigidbody.transform.position - _gameEnd.transform.position).magnitude < 2.0);
    }
}
