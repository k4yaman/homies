using UnityEngine;

public class GravityObject : MonoBehaviour
{
	public GameObject planet; // assign your planet GO in unity editor here

	public float distanceMassLimit = 1f;
	public bool fixInSpace = false;
	public const float gravityConstant = 6.67f;

	public void applyGravity() {
		if (!fixInSpace) {
			//get list of Objects nearby, calculate distanceMass factor , apply force when factor is under distanceMassLimit
			Object[] bodies = GameObject.FindObjectsOfType (typeof(Rigidbody2D));
			Vector2 forceToApply = Vector2.zero;
			Rigidbody2D currentBody = GetComponent<Rigidbody2D> ();
			float dist = 0f;

			foreach (Rigidbody2D body in bodies) {
				if (body.GetInstanceID () == currentBody.GetInstanceID ())
					continue;
				//Debug.Log ("Calculating Force to: " + body.name + " ID: " + body.GetInstanceID ());

				//limit to distanceMassLimit
				dist = Vector2.Distance(currentBody.position, body.position);

				forceToApply = body.position - currentBody.position;
				forceToApply *= (gravityConstant * currentBody.mass * body.mass) / Mathf.Pow (dist, 2);


			}
			Debug.Log ("Vector: " + forceToApply.ToString());

			currentBody.AddForce (forceToApply);
			//Fgrav= (G*m1*m2)/r^2
			//get the vector to the other object
			//multiply with calculated force
			//add to final vector


		}
	}
}


