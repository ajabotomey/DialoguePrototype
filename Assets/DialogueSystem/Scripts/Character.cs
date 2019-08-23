using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    [SerializeField] private string fullName;
    [SerializeField] private Sprite portrait;

    public string GetFullName()
    {
        return fullName;
    }

    public Sprite GetPortrait()
    {
        return portrait;
    }
}
