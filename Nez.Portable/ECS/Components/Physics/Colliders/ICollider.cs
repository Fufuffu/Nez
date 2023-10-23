using Microsoft.Xna.Framework;
using Nez.PhysicsShapes;

namespace Nez.ECS.Components.Physics.Colliders
{
	public interface ICollider
	{
		Shape Shape { get; set; }
		Vector2 LocalOffset { get; set; }

	}
}
