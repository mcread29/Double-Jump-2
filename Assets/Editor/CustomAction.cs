// This script demonstrates how to create a new action that can be accessed from the ProBuilder toolbar.
// A new menu item is registered under "Geometry" actions called "Make Double-Sided".
// To enable, remove the #if PROBUILDER_API_EXAMPLE and #endif directives.

using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.ProBuilder;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;

namespace UnityEditor.ProBuilder.Actions
{
    /// <summary>
    /// This is the actual action that will be executed.
    /// </summary>
    [ProBuilderMenuAction]
    public class MakeFacesDoubleSided : MenuAction
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
            "Set Polygon Collider",
            "Set 2D Polygon Collider"
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

            PolygonCollider2D collider = MeshSelection.activeMesh.gameObject.GetComponent<PolygonCollider2D>();
            if (collider == null)
            {
                collider = MeshSelection.activeMesh.gameObject.AddComponent<PolygonCollider2D>();
            }

            collider.points = points;

            // Rebuild the pb_Editor caches
            ProBuilderEditor.Refresh();
            return new ActionResult(ActionResult.Status.Success, "Set Polygon Collider");
        }
    }
}