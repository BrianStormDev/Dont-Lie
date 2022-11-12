using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] Menu[] menus;

    void Awake(){
        Instance = this;
    }

    public void OpenMenu (string menuName){
        for (int i=0; i < menus.Length; i++){
            if(menus[i].menuName==menuName){
                if (menus[i].open)
                    menus[i].Close();
            }
            else if (menus[i].open)
                menus[i].Close();
            menus[i].Open();
        }
    }

    

    
}
