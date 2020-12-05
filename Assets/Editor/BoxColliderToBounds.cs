using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

namespace UnityEditor.ProBuilder.Actions
{
    /// <summary>
    /// This is the actual action that will be executed.
    /// </summary>
    [ProBuilderMenuAction]
    public class BoxColliderToBounds : MenuAction
    {
        public override ToolbarGroup group { get { return ToolbarGroup.Object; } }
        public override Texture2D icon { get { return null; } }
        public override TooltipContent tooltip { get { return k_Tooltip; } }

        /// <summary>
        /// What to show in the hover tooltip window.
        /// TooltipContent is similar to GUIContent, with the exception that it also includes an optional params[]
        /// char list in the constructor to define shortcut keys (ex, CMD_CONTROL, K).
        /// </summary>
        static readonly TooltipContent k_Tooltip = new TooltipContent
        (
            "Box Collider 2D Resize",
            "Set 2D Box Collider to size"
        );

        /// <summary>
        /// Determines if the action should be enabled or grayed out.
        /// </summary>
        /// <returns></returns>
        public override bool enabled
        {
            get { return MeshSelection.selectedVertexCount > 0; }
        }

        /// <summary>
        /// This action is applicable in Face selection modes.
        /// </summary>
        public override SelectMode validSelectModes
        {
            get { return SelectMode.Vertex | SelectMode.TextureVertex; }
        }

        /// <summary>
        /// Return a pb_ActionResult indicating the success/failure of action.
        /// </summary>
        /// <returns></returns>
        public override ActionResult DoAction()
        {
            var selection = MeshSelection.activeMesh.GetVertices(MeshSelection.activeMesh.selectedVertices);

            Vector2[] points = new Vector2[selection.Length];
            for (int i = 0; i < selection.Length; i++) points[i] = selection[i].position;

            GameObject selectedObj = MeshSelection.activeMesh.gameObject;
            BoxCollider2D collider = selectedObj.GetComponent<BoxCollider2D>();
            if (collider == null)
            {
                collider = selectedObj.AddComponent<BoxCollider2D>();
            }

            float left = Mathf.Infinity;
            float right = Mathf.NegativeInfinity;
            float bottom = Mathf.Infinity;
            float top = Mathf.NegativeInfinity;

            foreach (var point in points)
            {
                if (point.x < left) left = point.x;
                if (point.x > right) right = point.x;
                if (point.y < bottom) bottom = point.y;
                if (point.y > top) top = point.y;
            }

            float midX = (right - left) / 2 + left;
            float midY = (top - bottom) / 2 + bottom;

            collider.offset = new Vector2(midX, midY);
            collider.size = new Vector2(right - left, top - bottom);

            // Rebuild the pb_Editor caches
            ProBuilderEditor.Refresh();
            return new ActionResult(ActionResult.Status.Success, "Set Polygon Collider");
        }
    }
}
