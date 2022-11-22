using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public RoleInfo role;
    //public Role role;

    public TMP_Text roleName;
    public TMP_Text roleDescription;

    public Image roleIcon;

    // Start is called before the first frame update
    void Start()
    {
        roleName.text = role.name;
        roleDescription.text = role.description;

        roleIcon.sprite = role.icon;
    }
}
