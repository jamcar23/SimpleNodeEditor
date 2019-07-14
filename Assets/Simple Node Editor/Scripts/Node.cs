using UnityEngine;

namespace SimpleNodeEditor
{
    public class Node
    {
        public Rect Rect;
        public string Title;
        public GUIStyle Style;

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
        public bool ProcessEvents(Event evnt)
        {
            return false;
        }
    }
}