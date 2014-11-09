using UnityEngine;
using System.Collections;

public abstract class TalkToPlayer : MonoBehaviour
{
    GameObject player;

    float messageHeight = 100f;
    float messageMargin = 20f;
    float messageDuration = 2;

    Rect messagePosition;
    float messageShowAt = 0;
    string message;

    protected abstract string GenerateMessage();

    void Start()
    {
        messagePosition = new Rect(
            messageMargin,
            Screen.height - messageHeight - messageMargin,
            Screen.width - 2 * messageMargin,
            messageHeight);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        HandlePlayerAction();
        HandleMessageTime();
    }

    void HandlePlayerAction()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 3 &&
            Input.GetKeyDown(KeyCode.Space) && 
            messageShowAt == 0)
        {
            messageShowAt = Time.time;
            message = GenerateMessage();
        }
    }

    void HandleMessageTime()
    {
        if (messageShowAt > 0 &&
            messageShowAt + messageDuration < Time.time)
        {
            messageShowAt = 0;
        }
    }

    void OnGUI()
    {
        if (messageShowAt > 0)
        {
            GUI.TextArea(messagePosition, message);
        }
    }
}
