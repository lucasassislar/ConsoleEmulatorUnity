using System;
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
            //Console.WriteLine(@"You need to supply a GUIStyle along with your draw call. GUI.Label can take a style as a third parameter.private void OnGUI() { GUIStyle myStyle = new GUIStyle(); myStyle.font = myFont; GUI.Label(new Rect(10, 10, 100, 30), Hello World!, myStyle); } The Font must be created as a game asset and can be assigned to the script via the property inspector.It can contain a material that will specify color.           As for creating the initial Font, it is often best to find a good ttf font that you like, import that, then assign a material with the appropriate color.This site has a bunch of great references on fonts.");
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