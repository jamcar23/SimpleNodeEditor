using UnityEngine;

namespace SimpleNodeEditor
{
    public interface IConnectionPointStyle
    {
        Vector2 Size { get; }
        Vector2 NodeOffset { get; }
        GUIStyle ConnectionPointStyle { get; }
}