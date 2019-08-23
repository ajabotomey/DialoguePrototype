using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class QuestionEvent : UnityEvent<Question> { }

public class ConversationController : MonoBehaviour
{
    [SerializeField] private Conversation conversation;
    [SerializeField] private QuestionEvent questionEvent;

    [SerializeField] private SpeakerUI speakerUILeft;
    [SerializeField] private SpeakerUI speakerUIRight;

    private int activeLineIndex = 0;
    private bool conversationStarted = false;

    public void ChangeConversation(Conversation nextConversation)
    {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }

    // Start is called before the first frame update
    void Start()
    {
        speakerUILeft.Speaker = conversation.GetSpeakerLeft();
        speakerUIRight.Speaker = conversation.GetSpeakerRight();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            AdvanceLine();
        } else if (Input.GetKeyDown("x")) {
            EndConversation();
        }
    }

    private void EndConversation()
    {
        conversation = null;
        conversationStarted = false;
        speakerUILeft.Hide();
        speakerUIRight.Hide();
    }

    private void Initialize()
    {
        conversationStarted = true;
        activeLineIndex = 0;
        speakerUILeft.Speaker = conversation.GetSpeakerLeft();
        speakerUIRight.Speaker = conversation.GetSpeakerRight();
    }

    private void AdvanceLine()
    {
        if (conversation == null) return;
        if (!conversationStarted) Initialize();

        if (activeLineIndex < conversation.GetConversationLength()) {
            DisplayLine();
        } else {
            AdvanceConversation();
        }
    }

    private void DisplayLine()
    {
        Line line = conversation.GetLine(activeLineIndex);
        Character character = line.character;

        string text = ParseEmojis.Parse(line.text);

        if (speakerUILeft.SpeakerIs(character)) {
            SetDialog(speakerUILeft, speakerUIRight, text);
        } else {
            SetDialog(speakerUIRight, speakerUILeft, text);
        }

        activeLineIndex++;
    }

    void AdvanceConversation()
    {
        if (conversation.GetQuestion() != null) {
            questionEvent.Invoke(conversation.GetQuestion());

            // Clear the conversation dialog box
            SetDialog(speakerUILeft, speakerUIRight, "");
            SetDialog(speakerUIRight, speakerUILeft, "");
        }
        else if (conversation.GetNextConversation() != null)
            ChangeConversation(conversation.GetNextConversation());
        else
            EndConversation();
    }

    void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text)
    {
        activeSpeakerUI.Dialog = text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
    }
}
