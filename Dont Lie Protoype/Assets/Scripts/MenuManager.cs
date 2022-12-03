using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    [SerializeField] Menu[] menus;

    void Awake(){ //Called when script object is initialized
        Instance = this; //"this" refers to the instance of the script
    }

    public void OpenMenu (string menuName){
        for (int i=0; i < menus.Length; i++){
            if(menus[i].menuName==menuName){
                if (menus[i].open)
                    menus[i].Close();
                menus[i].Open();
            }
            else if (menus[i].open)
                menus[i].Close();
        }
    } 

    public void Quit(){
        Application.Quit();
    }
}
