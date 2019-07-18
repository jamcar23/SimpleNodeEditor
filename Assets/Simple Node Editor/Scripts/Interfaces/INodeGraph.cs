using UnityEngine;

namespace SimpleNodeEditor
{
    public interface INodeGraph
    {
        Vector2 DefaultNodeSize { get; }
        GUIStyle NodeStyle { get; }

        void DrawNodes();
        void ProcessEvent(Event evnt);
    }
}