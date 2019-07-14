using UnityEngine;

namespace SimpleNodeEditor
{
    public class Node
    {
        public Rect Rect;
        public string Title;
        public GUIStyle Style;

        private bool _isDragging;

        public Node(Vector2 position, float width, float height, GUIStyle nodeStyle)
        {
            Rect = new Rect(position.x, position.y, width, height);
            Style = nodeStyle;
        }

        /// <summary>
        /// Used to change the position of the node when dragging.
        /// </summary>
        /// <param name="delta"></param>
        public void Drag(Vector2 delta)
        {
            Rect.position += delta;
        }

        /// <summary>
        /// Draw the GUI to the screen.
        /// </summary>
        public void Draw()
        {
            GUI.Box(Rect, Title, Style);
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
                        if (Rect.Contains(evnt.mousePosition))
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