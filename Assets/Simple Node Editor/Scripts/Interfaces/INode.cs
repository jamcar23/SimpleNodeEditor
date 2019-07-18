using UnityEngine;

namespace SimpleNodeEditor
{
    public interface INode: IDrawer
    {
        Rect Rect { get; }
    }
}