using Microsoft.Xna.Framework;
using Nez.PhysicsShapes;

namespace Nez.ECS.Components.Physics.Colliders
{
	public interface ICollider
	{
		Nez.Physics RegisteredPhysics { get; }

		Shape Shape { get; set; }
		Vector2 LocalOffset { get; set; }
		float LocalOffsetLength { get; }
		RectangleF Bounds { get; }
		RectangleF RegisteredPhysicsBounds { get; set; }
		Vector2 Position { get; }
		float Rotation { get; }
		Vector2 Scale { get; }
		int PhysicsLayer { get; set; }
		int CollidesWithLayers { get; set; }
		bool IsTrigger { get; set; }
		bool ShouldRotateAndScale { get; }
		bool IsRotationDirty { get; }

		void RegisterColliderWithPhysicsSystem();
		void UnregisterColliderWithPhysicsSystem();
		bool CollidesWith(ICollider collider, out CollisionResult result);
		bool CollidesWith(ICollider collider, Vector2 motion, out CollisionResult result);
		bool CollidesWithAny(out CollisionResult result);
		bool CollidesWithAny(ref Vector2 motion, out CollisionResult result);
	}
}
