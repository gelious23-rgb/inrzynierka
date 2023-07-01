using UnityEngine;

namespace Script.UI.Text
{
    public class DescExplanations : ScriptableObject
    {
        public string[] Descs; //should've named effects but whatever
        [TextArea] public string[] Explanations;
    }
}
