using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AngleNormalizer
{
	public static Vector3 NormalizeAngle(Vector3 v)
	{
		return new Vector3(NormalizeAngle(v.x), NormalizeAngle(v.y), NormalizeAngle(v.z));
	}

	public static float NormalizeAngle(float a)
	{
		if (a > 180)
		{
			return a - 360;

		}

		if (a < -180)
		{
			return 360 + a;
		}

		return a;
	}
}
