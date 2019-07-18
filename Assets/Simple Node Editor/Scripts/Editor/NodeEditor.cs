using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace SimpleNodeEditor
{
    public class NodeEditor : EditorWindow, INodeGraph
    {
        private readonly List<Node> _nodes = new List<Node>();
        private readonly Vector2 _defaultNodeSize = new Vector2(200, 50);
        private GUIStyle _nodeStyle;

        public Vector2 DefaultNodeSize => _defaultNodeSize;
        public GUIStyle NodeStyle => _nodeStyle;

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
            ProcessNodeEvents(Event.current);
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
            _nodes.Add(new Node(mousePosition, this));
        }

        #endregion

        public void DrawNodes()
        {
            if (_nodes.Count == 0) return;

            foreach (Node node in _nodes)
            {
                if (node == null) continue;

                node.Draw();
            }
        }

        public void ProcessNodeEvents(Event evnt)
        {
            if (_nodes.Count == 0) return;

            foreach (Node node in _nodes)
            {
                if (node == null) continue;

                if (node.ProcessEvent(evnt))
                {
                    GUI.changed = true;
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