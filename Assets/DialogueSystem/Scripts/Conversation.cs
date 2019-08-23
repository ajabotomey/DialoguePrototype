using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public Character character;

    [TextArea(2, 5)]
    public string text;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    [SerializeField] private Character speakerLeft;
    [SerializeField] private Character speakerRight;
    
    [SerializeField] private Line[] lines;
    [SerializeField] private Question question;
    [SerializeField] private Conversation nextConversation;

    public Character GetSpeakerLeft()
    {
        return speakerLeft;
    }

    public Character GetSpeakerRight()
    {
        return speakerRight;
    }

    public Line GetLine(int index)
    {
        return lines[index];
    }

    public int GetConversationLength()
    {
        return lines.Length;
    }

    public Question GetQuestion()
    {
        return question;
    }

    public Conversation GetNextConversation()
    {
        return nextConversation;
    }
}
