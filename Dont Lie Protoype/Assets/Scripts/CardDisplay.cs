using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Role role;  //  "And now, we can access all of the data inside of our script..."

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
