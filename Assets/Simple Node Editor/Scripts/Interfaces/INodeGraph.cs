using UnityEngine;

namespace SimpleNodeEditor
{
    public interface INodeGraph
    {
        void DrawNodes();
        void ProcessEvent(Event evnt);
    }
}