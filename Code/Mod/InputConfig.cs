using Rewired;
using System;
using System.IO;

namespace Mod
{

    [System.Serializable]
    public struct InputConfig
    {
        public string up;
        public string down;
        public string left;
        public string right;
        public string jump;
        public string quickAttack;
        public string heavyAttack;
        public string specialAttack;
        public string block;
        public string recruit;
        public string start;

        public int[] ToKeycodeArray()
        {
            return new int[] {
                ParseKeycode(up),
                ParseKeycode(down),
                ParseKeycode(left),
                ParseKeycode(right),
                ParseKeycode(start),
                ParseKeycode(quickAttack),
                ParseKeycode(heavyAttack),
                ParseKeycode(jump),
                ParseKeycode(specialAttack),
                ParseKeycode(block),
                ParseKeycode(recruit),
                ParseKeycode(jump),
                ParseKeycode(specialAttack)
            };
        }

        private int ParseKeycode(string keycodeStr)
        {
            KeyboardKeyCode keyboardKeyCode;
            try
            {
                keyboardKeyCode = (KeyboardKeyCode)Enum.Parse(typeof(KeyboardKeyCode), keycodeStr);
            }
            catch (Exception e)
            {
                File.WriteAllText(string.Format(".\\{0}.txt", keycodeStr), e.Message);
                keyboardKeyCode = KeyboardKeyCode.None;
            }
            return (int)keyboardKeyCode;
        }
    }

}