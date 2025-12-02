using UnityEngine;

// Este script no necesita estar en ningun objeto.

public static class GestorDeTeletransporteEscenas
{
	// Las coordenadas donde debemos aparecer
	public static Vector3 proximaPosicion;

	// Una bandera para saber si venimos de un portal
	// o si simplemente hemos cargado la escena normalmente.
	public static bool tienePosicionGuardada = false;
}
