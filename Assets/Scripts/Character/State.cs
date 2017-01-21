using UnityEngine;

public abstract class State
{
	protected CharacterStates states;

	public State(CharacterStates states)
	{
		this.states = states;
	}

	public abstract void OnStep();
	public abstract void OnStop();
}