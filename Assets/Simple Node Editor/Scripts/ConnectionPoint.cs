using System;
using UnityEngine;

namespace SimpleNodeEditor
{
    public enum ConnectionPointType
    {
        In,
        Out,
    }

    public class ConnectionPoint: IDrawer
    {
        private Rect _rect;
        private readonly ConnectionPointType _type;
        private readonly INode _node;
        private readonly IConnectionPointStyle _style;
        private readonly Action<ConnectionPoint> OnConnectionPointClicked;

        public ConnectionPoint(ConnectionPointType type, INode node, IConnectionPointStyle style, Action<ConnectionPoint> onConnectionPointClicked)
        {
            _type = type;
            _node = node;
            _style = style;
            OnConnectionPointClicked = onConnectionPointClicked;
            _rect = new Rect(Vector2.zero, _style.Size);
        }

        public void Draw()
        {
            _rect.y = _node.Rect.y + (_node.Rect.height * _style.NodeOffset.y) - _rect.height * _style.NodeOffset.y;

            switch (_type)
            {
                case ConnectionPointType.In:
                    _rect.x = _node.Rect.x - _rect.width + _style.NodeOffset.x;
                    break;
                case ConnectionPointType.Out:
                    _rect.x = _node.Rect.x + _rect.width - _style.NodeOffset.x;
                    break;
                default:
                    break;
            }

            if (GUI.Button(_rect, "", _style.ConnectionPointStyle))
            {
                OnConnectionPointClicked?.Invoke(this);
            }
        }
    }
}