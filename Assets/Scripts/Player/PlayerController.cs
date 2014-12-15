using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float CamRayLength = 100f;

    public float constantSpeed;

    Rigidbody _playerRigidbody;
    PlayerStatus _status;
    GameObject _playerModel;
    SceneConfiguration _sceneConfiguration;
    GameObject _levelEnd;

    void Start()
    {
        _status = GetComponent<PlayerStatus>();
        _sceneConfiguration = FindObjectOfType<SceneConfiguration>();
        _playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
        _levelEnd = GameObject.FindGameObjectWithTag("levelEnd");
    }

    void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Turn();

        if (IsNearLevelEnd())
        {
            EndGameMenu.FinalScore = PlayerStatus.Score;
            Application.LoadLevel(_sceneConfiguration.NextScene);
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

    bool IsNearLevelEnd()
    {
        return ((_playerRigidbody.transform.position - _levelEnd.transform.position).magnitude < 2.0);
    }

}
