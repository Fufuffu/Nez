﻿using Microsoft.Xna.Framework;


namespace Nez.PhysicsShapes
{
	public abstract class Shape
	{
		/// <summary>
		/// having a separate position field lets us alter the position of the shape for collisions checks as opposed to having to change the
		/// Entity.position which triggers collider/bounds/hash updates.
		/// </summary>
		public Vector2 position;

		/// <summary>
		/// center is kind of a misnomer. This value isnt necessarily the center of an object. It is more accurately the Collider.localOffset
		/// with any Transform rotations applied
		/// </summary>
		public Vector2 center;

		/// <summary>
		/// cached bounds for the Shape
		/// </summary>
		public RectangleF bounds;

		public void RecalculateBounds(Collider collider)
		{
			RecalculateBounds(collider.LocalOffset,
							  collider._localOffsetLength,
							  collider.Entity.Transform.Position,
							  collider.Entity.Transform.Scale,
							  collider.Entity.Transform.Rotation,
							  collider.ShouldColliderScaleAndRotateWithTransform,
							  collider._isRotationDirty);
		}

		public abstract void RecalculateBounds(Vector2 localOffset, float localOffsetLength, Vector2 entityPosition, Vector2 entityScale, float entityRotation, bool shouldRotateAndScale, bool isRotationDirty);

		public abstract bool Overlaps(Shape other);

		public abstract bool CollidesWithShape(Shape other, out CollisionResult result);

		public abstract bool CollidesWithLine(Vector2 start, Vector2 end, out RaycastHit hit);

		public abstract bool ContainsPoint(Vector2 point);

		public abstract bool PointCollidesWithShape(Vector2 point, out CollisionResult result);


		public virtual Shape Clone()
		{
			return MemberwiseClone() as Shape;
		}
	}
}