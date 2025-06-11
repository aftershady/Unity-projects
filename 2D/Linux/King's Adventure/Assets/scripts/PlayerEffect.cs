using UnityEngine;
using System.Collections;

public class PlayerEffect : MonoBehaviour
{
	public void AddSpeed(int speedGiven, float duration)
	{
		PlayerMovement.instance.moveSpeed += speedGiven;
		StartCoroutine(RemoveSpeed(speedGiven, duration));
	}
	private IEnumerator RemoveSpeed(int speedGiven, float duration)
	{
		yield return new WaitForSeconds(duration);
		PlayerMovement.instance.moveSpeed -= speedGiven;
	}
}
