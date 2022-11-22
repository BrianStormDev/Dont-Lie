using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Role", menuName = "Role")]
public class RoleInfo : ScriptableObject //MonoBehaviour //ScriptableObject needed to reuse code accross objects
{
    public new string name;
    public string description;

    public Sprite icon;

    public string color;  //  FIXME Look up the actual way to modify text color

    public void print()
    {
        Debug.Log("Role: " + name + ", Abilities: " + description + ", Text color: " + color);
    }

}