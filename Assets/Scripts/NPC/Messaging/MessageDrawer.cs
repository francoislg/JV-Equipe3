using UnityEngine;
using System.Collections;

public abstract class MessageDrawer : MonoBehaviour
{
    const float messageDuration = 5;
    const float messageHeight = 100f;
    const float messageMargin = 100f;
	const float messageBottomMargin = 20f;

    Rect messagePosition;
    string message;

    float messageShowAt = 0;

    protected virtual void Start()
    {
        messagePosition = new Rect(
            messageMargin,
			Screen.height - messageHeight - messageBottomMargin,
            Screen.width - 2 * messageMargin,
            messageHeight);
    }

    protected virtual void Update()
    {
        if (messageShowAt > 0 &&
            messageShowAt + messageDuration < Time.time)
        {
            messageShowAt = 0;
        }
    }

    protected void ShowMessage(string message)
    {
        this.message = message.ToUpper();
        messageShowAt = Time.time;
    }

    protected bool IsMessageVisible()
    {
        return messageShowAt > 0;
    }

    void OnGUI()
    {
        if (messageShowAt > 0)
        {
            GUI.TextArea(messagePosition, message);
        }
    }
}
