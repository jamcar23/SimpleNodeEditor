using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace SimpleNodeEditor
{
    public class NodeEditor : EditorWindow, INodeGraph
    {
        private readonly List<Node> _nodes = new List<Node>();
        private GUIStyle _nodeStyle;

        #region Unity Methods

        private void OnEnable()
        {
            _nodeStyle = new GUIStyle();
            _nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
            _nodeStyle.border = new RectOffset(12, 12, 12, 12);
        }

        private void OnGUI()
        {
            DrawNodes();
            ProcessEvent(Event.current);

            if (GUI.changed)
            {
                Repaint();
            }
        }

        #endregion

        #region Protected Methods

        protected void CreateContextMenu(Vector2 mousePosition)
        {
            GenericMenu gm = new GenericMenu();
            gm.AddItem(new GUIContent("Add Note"), false, () => OnClickAddNode(mousePosition));
            gm.ShowAsContext();
        }

        protected void OnClickAddNode(Vector2 mousePosition)
        {
            _nodes.Add(new Node(mousePosition, 200, 50, _nodeStyle));
        }

        #endregion

        public void DrawNodes()
        {
            if (_nodes != null && _nodes.Count > 0)
            {
                foreach (Node node in _nodes)
                {
                    if (node == null) continue;

                    node.Draw();
                }
            }
        }

        public void ProcessEvent(Event evnt)
        {
            switch (evnt.type)
            {
                case EventType.MouseDown:
                    if (evnt.button == 1)
                    {
                        CreateContextMenu(evnt.mousePosition);
                    }
                    break;
                case EventType.MouseUp:
                    break;
                case EventType.MouseMove:
                    break;
                case EventType.MouseDrag:
                    break;
                case EventType.KeyDown:
                    break;
                case EventType.KeyUp:
                    break;
                case EventType.ScrollWheel:
                    break;
                case EventType.Repaint:
                    break;
                case EventType.Layout:
                    break;
                case EventType.DragUpdated:
                    break;
                case EventType.DragPerform:
                    break;
                case EventType.DragExited:
                    break;
                case EventType.Ignore:
                    break;
                case EventType.Used:
                    break;
                case EventType.ValidateCommand:
                    break;
                case EventType.ExecuteCommand:
                    break;
                case EventType.ContextClick:
                    break;
                case EventType.MouseEnterWindow:
                    break;
                case EventType.MouseLeaveWindow:
                    break;
                default:
                    break;
            }
        }

        [MenuItem("Window/Simple Node Editor")]
        public static void OpenWindow()
        {
            NodeEditor window = GetWindow<NodeEditor>("Simple Node Editor");
        }
    }
}