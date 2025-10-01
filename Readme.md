# Proyecto de Demostración en Unity

Este es un proyecto de demostración simple creado en Unity que integra varios assets y funcionalidades básicas, incluyendo un sistema para entrar y salir de un vehículo.

## Demostración Rápida

<p align="center">
  <img src="resources/video.gif" alt="Demostración de la jugabilidad" width="80%"/>
</p>

## Contenido del Proyecto
Este escenario ha sido construido utilizando los siguientes elementos:

*   **Paquete Starter Assets (Third Person):** Se utiliza el prefab `PlayerArmature` como personaje controlable.
*   **POLYGON - Low Poly City Pack:** Asset libre de la Asset Store utilizado para construir el entorno de la ciudad (edificios, calles, etc.).
*   **Objetos 3D Primitivos:** Se han incluido cubos y esferas como elementos adicionales en la escena.
*   **Coche "Prometeo":** Vehículo principal con el que el jugador puede interactuar.

## Vistas del Proyecto

<p align="center">
  <b>Vista general del entorno de la ciudad</b>
</p>
<p align="center">
  <img src="resources/calle.png" alt="Vista general del escenario" width="80%"/>
</p>

<br>

<p align="center">
  <b>Assets utilizados en el proyecto</b>
</p>
<p align="center">
  <img src="resources/assets.png" alt="Assets utilizados en el proyecto" width="80%"/>
</p>

## Configuración y Uso
Para probar la escena, simplemente abre el proyecto en Unity y dale a Play.

### Controles
*   **Movimiento:** `WASD`
*   **Saltar:** `Barra Espaciadora`
*   **Correr:** `Shift Izquierdo`
*   **Entrar/Salir del coche:** `E` (cuando estás cerca del vehículo)

## Etiquetas de Objetos (Tags)
Cada objeto principal en la escena ha sido identificado con una etiqueta para su fácil localización y gestión a través de scripts.

| Objeto | Etiqueta (Tag) |
|---|---|
| Personaje (PlayerArmature) | `Player` |
| Coche (Prometeo) | `Car` |


## Script de Información
El proyecto incluye un script llamado `PositionAndTagScript.cs` que, al iniciar la escena, escribe en la consola la etiqueta y la posición de todos los objetos principales utilizados.

## Script de interacción
Se ha añadido un script por investigar un poco más unity para interactuar con el coche llamado enterandexit que consigue que el jugador "se meta dentro del coche" y lo controle una vez esté dentro.