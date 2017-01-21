using UnityEngine;

public class Manager<SingletonType> : MonoBehaviour where SingletonType : Manager<SingletonType>
{
	public static SingletonType Instance { get; private set; }

	protected virtual void Awake()
	{
		Instance = (SingletonType)this;
	}
}
