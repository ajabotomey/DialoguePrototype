using UnityEngine;
using UnityEngine.UI;

public class SpeakerUI : MonoBehaviour
{
    [SerializeField] private Image portrait;
    [SerializeField] private Text fullName;
    [SerializeField] private Text dialog;
    [SerializeField] private TMPro.TMP_Text dialogText;

    private Character speaker;
    public Character Speaker {
        get { return speaker; }
        set {
            speaker = value;
            portrait.sprite = speaker.GetPortrait();
            fullName.text = speaker.GetFullName();
        }
    }

    public string Dialog {
        set {
            //dialog.text = value;
            dialogText.SetText(value);
        }
    }

    public bool HasSpeaker()
    {
        return speaker != null;
    }

    public bool SpeakerIs(Character character)
    {
        return speaker == character;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
