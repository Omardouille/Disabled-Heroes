using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticCode
{
    public static void stopAllMusic() {
		FMODUnity.StudioEventEmitter[] objs = GameObject.FindObjectsOfType<FMODUnity.StudioEventEmitter>();
		foreach (FMODUnity.StudioEventEmitter o in objs)
			o.Stop();
	}
}
