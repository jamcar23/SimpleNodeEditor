using UnityEngine;

namespace SimpleNodeEditor
{
    public class Node: INode
    {
        private Rect _rect;
        private string _title;
        private GUIStyle _style;
        private bool _isDragging;

        public Rect Rect => _rect;

        public Node(Vector2 position, INodeGraph graph)
        {
            _rect = new Rect(position.x, position.y, graph.DefaultNodeSize.x, graph.DefaultNodeSize.y);
            _style = graph.NodeStyle;
        }

        /// <summary>
        /// Used to change the position of the node when dragging.
        /// </summary>
        /// <param name="delta"></param>
        public void Drag(Vector2 delta)
        {
            _rect.position += delta;
        }

        /// <summary>
        /// Draw the GUI to the screen.
        /// </summary>
        public void Draw()
        {
            GUI.Box(_rect, _title, _style);
        }

        /// <summary>
        /// Allow the node to process the same events as the graph.
        /// </summary>
        /// <param name="evnt"></param>
        /// <returns>Returns true when GUI needs to be updated.</returns>
        public bool ProcessEvent(Event evnt)
        {
            switch (evnt.type)
            {
                case EventType.MouseDown:
                    if (evnt.button == 0)
                    {
                        if (_rect.Contains(evnt.mousePosition))
                        {
                            _isDragging = true;
                            GUI.changed = true;
                        }
                    }
                    break;
                case EventType.MouseUp:
                    _isDragging = false;
                    break;
                case EventType.MouseDrag:
                    if (evnt.button == 0 && _isDragging)
                    {
                        Drag(evnt.delta);
                        evnt.Use();
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}