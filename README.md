# Parkour 3D: \[TP01\_PVJ1_SebastianLucianoMartinez / Juego]

> \\\*\\\*Asignatura:\\\*\\\* Programación de Videojuegos I 
> \\\*\\\*Carrera:\\\*\\\* Tecnicatura Universitaria en Diseño Integral de Videojuegos (TUDIVJ) — UNJu 
> \\\*\\\*Trabajo Práctico N° 1:\\\*\\\* Entorno Interactivo 3D, Temporizadores y Git/GitHub 
> \\\*\\\*Estudiante:\\\*\\\* \\\[Sebastian Luciano Martinez] 
> \\\*\\\*LU:\\\*\\\* \\\[TUV000621]
**Repositorio:** https://github.com/SebasMartinez07/TP01\_PVJ1\_SebastianLucianoMartinez  
**Versión de Unity:** 2022.3.62f3 LTS (Built-in Render Pipeline)
>\\\*\\\*Equipo Docente:\\\*\\\* Mg. Ing. Ariel Alejandro Vega | Tecn. Kevin Alexis Roman Llampa 

\---

## Descripción del juego

Prototipo 3D en tercera persona donde el jugador debe atravesar un escenario con plataformas móviles, recoger un objeto clave y depositarlo en la GoalZone para ganar.

El nivel cuenta con una zona de inicio, un sector de plataformas móviles simples y otra zona de plataformas móviles sincronizadas sobre una pared, zona con generador de plataformas mientras esquivamos las balas de los enemigos, un objeto transportable y una zona de meta con feedback visual de victoria.

El objetivo es validar el uso de temporizadores (`Invoke`, `InvokeRepeating`, `CancelInvoke`), movimiento de plataformas, `SetParent` para transporte, cambio de `Tag` para power-ups, detección por `Trigger` y patrullaje de enemigos.

\---

## Controles

|Acción|Tecla|
|-|-|
|Moverse adelante/atrás/izquierda/derecha|`W A S D` / Flechas|
|Saltar|`Espacio`|
|Recoger objeto|`E` (cuando estás en rango)|
|Soltar objeto / Depositar en GoalZone|`Q` (fuera de la zona lo suelta al piso, dentro de la zona lo entrega)|

Cámara sigue al player.

\---

## Mecánicas implementadas

### Consigna 1 - Escenario y Preparación

* Escenario modular con colliders y Rigidbody.
* Player con `CapsuleCollider` + `Rigidbody` (Freeze Rotation X,Z).
* Organización de carpetas: `Scripts`, `Materials`, `Textures`, `Prefabs`.

### Consigna 2 - Acciones Temporizadas

* Uso de `Invoke`, `InvokeRepeating` y `CancelInvoke` para aparición de plataformas / power-ups / reseteo de efectos.

### Consigna 3 - Plataforma Móvil

* Script `WallPlatformsMovement.cs` - movimiento en eje Z con `Mathf.PingPong(Time.time \* speed, distancia)` para mantener sincronización perfecta y evitar el bug de estancamiento por `speed \*= -1`.
* Límites configurables `limiteMin` y `limiteMax` en el Inspector.

### Consigna 4 - Recolección con SetParent

* `PickItem.cs`: `OnTriggerEnter` detecta `Item`, `E` hace `SetParent(hand)`, pone `isKinematic = true` y desactiva collider.
* `Q` restaura independencia jerárquica `SetParent(null)`, reactiva collider y `isKinematic = false` con un pequeño impulso.
* Si se presiona `Q` dentro de la GoalZone, llama a `DeliverItem()` en lugar de soltar.

### Consigna 5 - Power-up con cambio de Tag

* Al recoger power-up se cambia `gameObject.tag = "PoweredPlayer"` y se modifica velocidad.
* Al finalizar el efecto con `Invoke` se restaura el Tag a `Player`.

### Consigna 6 - Efectos por Trigger

* `GoalZone.cs` con `CylinderCollider IsTrigger = true`.
* Detecta la orden manual `Q` dentro del radio, no automática al entrar.

### Consigna 7 - Enemigo Patrullero

* Patrullaje entre puntos con `NavMeshAgent` o `Translate`.
* Detección del Player por `OnTriggerEnter`.

## Cómo abrir y ejecutar el proyecto

1. **Clonar el repositorio**

```bash
   git clone https://github.com/SebasMartinez07/TP01\_PVJ1\_SebastianLucianoMartinez.git
   ```

2. **Abrir en Unity Hub**

   * Unity Hub > Open > Seleccionar la carpeta clonada.
   * Asegúrate de tener instalada **Unity 2022.3.62f3 LTS** (Built-in).
   * Al abrir por primera vez Unity importará los paquetes.
3. **Abrir la escena principal**

   * `Assets/Scenes/SampleScene.unity`
4. **Ejecutar**

   * Presioná `Play` en el editor.

### Vista general del escenario

[Escenario general 1](Screenshots/01_escenario_general.png)
[Escenario general 2](Screenshots/02_escenario_general.png)

### Spawner de Plataformas y Enemigos con lanzado balas
[Plataformas](Screenshots/spawnerplataformas_enemigos.png)

### Recogiendo el objeto con E

[Pick](Screenshots/pick_item.png)

### Depositando en GoalZone con Q + feedback de victoria

[GoalZone](Screenshots/goalzone_victoria.png)

\

## Licencia de Assets

Texturas CC0 de ambientCG.com y Poly Haven. Modelos primitivos de Unity.

