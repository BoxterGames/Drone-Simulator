[System.Serializable]
public class PID
{
	public float pFactor;
	public float iFactor;
	public float dFactor;

	float i;
	float lastP;

	public PID(float p, float i, float d)
	{
		pFactor = p;
		iFactor = i;
		dFactor = d;
	}


	public float Update(float p, float dt)
	{
		float d = (p - lastP) / dt;
		i += p * dt;
		lastP = p;
		return p * pFactor + i * iFactor + d * dFactor;
	}

	public void Reset()
    {
		i = 0;
		lastP = 0;
    }
}