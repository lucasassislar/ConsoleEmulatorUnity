﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace ConsoleEmulatorUnity {
    public class ConsoleEmulatorComponent : MonoBehaviour {
        Thread t;

        void Start() {
            Console.SetOut(new EmulatorTextWriter());

            t = new Thread(GameThread);
            t.Start();
        }

        void GameThread() {
            Atari_II.Program.Main(null);
        }

        void Update() {
            if (Input.GetKey(KeyCode.UpArrow)) {
                ConsoleU.InputString = ConsoleKey.UpArrow.ToString();
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                ConsoleU.InputString = ConsoleKey.DownArrow.ToString();
            } else if (Input.GetKey(KeyCode.LeftArrow)) {
                ConsoleU.InputString = ConsoleKey.LeftArrow.ToString();
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                ConsoleU.InputString = ConsoleKey.RightArrow.ToString();
            } else if (Input.GetKey(KeyCode.Return)) {
                ConsoleU.InputString = ConsoleKey.Enter.ToString();
            } else if (Input.GetKey(KeyCode.Space)) {
                ConsoleU.InputString = ConsoleKey.Spacebar.ToString();
            } else {
                ConsoleU.InputString = Input.inputString.ToUpper();
            }
        }

        private void OnGUI() {
            ConsoleU.OnGUI();
        }
    }
}