﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    void OnGUI()
    {
        const int buttonWidth = 84;
        const int buttonHeight = 60;

        // Affiche un bouton pour démarrer la partie
        if (
          GUI.Button(
            // Centré en x, 2/3 en y
            new Rect(
              Screen.width / 2 - (buttonWidth / 2) - 50,
              (2 * Screen.height / 3) - (buttonHeight / 2) + 50,
              buttonWidth,
              buttonHeight
            ),
            "Start"
          )
        )
        {
            // Sur le clic, on démarre le niveau
            Application.LoadLevel("main_scene");
        }

        if (
            GUI.Button(
             // Centré en x, 2/3 en y
            new Rect(
         Screen.width / 2 - (buttonWidth / 2) + 50,
         (2 * Screen.height / 3) - (buttonHeight / 2) + 50,
         buttonWidth,
        buttonHeight
         ),
            "Quit"
         )
)
        {
            // Sur le clic, on démarre le niveau
            Application.Quit();
        }

    }
}
