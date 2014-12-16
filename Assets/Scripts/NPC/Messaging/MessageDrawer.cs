using UnityEngine;
using System.Collections;

public abstract class MessageDrawer : MonoBehaviour
{
    const float MessageDuration = 5;
    const float MessageHeight = 175f;
    const float MessageMargin = 100f;
    const float MessageBottomMargin = 20f;

    Rect _messagePosition;
    string _message;
    float _messageShowAt;

    protected virtual void Start()
    {
        _message = "";
        _messageShowAt = 0;
        _messagePosition = new Rect(
            MessageMargin,
            Screen.height - MessageHeight - MessageBottomMargin,
            Screen.width - 2 * MessageMargin,
            MessageHeight);
    }

    protected virtual void Update()
    {
        if (_messageShowAt > 0 &&
            _messageShowAt + MessageDuration < Time.time)
        {
            _messageShowAt = 0;
        }
    }

    protected void ShowMessage(string message)
    {
        _message = message.ToUpper();
        _messageShowAt = Time.time;
    }

    protected bool IsMessageVisible()
    {
        return _messageShowAt > 0;
    }

    void OnGUI()
    {
        if (_messageShowAt > 0)
        {
            GUI.Label(_messagePosition, _message);
        }
    }
}
