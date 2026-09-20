# AGENTS.md

# Sistema Acuícola — Migración de .EXE a Web

## 1. Propósito del proyecto

Este proyecto consiste en migrar a una aplicación web un sistema existente utilizado por una acuícola.

El sistema actual existe como aplicación de escritorio `.EXE`.

El objetivo es llevarlo a una aplicación web moderna manteniendo la lógica, estructura funcional, flujos de trabajo y experiencia de uso que los usuarios actuales ya conocen.

La aplicación web será desarrollada utilizando:

* Next.js
* React
* TypeScript
* SQL Server

La base de datos del sistema será SQL Server.

Codex ya tiene conocimiento del contexto, estructura y necesidades relacionadas con SQL Server. No asumir una tecnología de base de datos diferente.

---

# 2. Metodología de desarrollo

Este proyecto utiliza:

**Spec-Driven Development (SDD) — variante Spec-Anchored.**

Las especificaciones proporcionadas en este archivo constituyen la fuente principal de verdad para determinar qué debe hacer el sistema.

El código existente, el sistema original y las especificaciones deben analizarse conjuntamente para realizar la migración correctamente.

El objetivo NO es reconstruir el sistema desde cero basándose en suposiciones.

El objetivo es realizar una transferencia controlada de:

```text
Sistema .EXE
      ↓
Análisis
      ↓
Especificación
      ↓
Plan de implementación
      ↓
Autorización
      ↓
Implementación
      ↓
Verificación
      ↓
Sistema Web
```

---

# 3. Flujo obligatorio de trabajo

Antes de realizar cualquier cambio significativo, Codex debe seguir este flujo:

## Paso 1 — Analizar

Analizar:

* la especificación correspondiente
* el código existente
* la estructura del proyecto
* las dependencias relacionadas
* las tablas y datos involucrados
* los componentes afectados
* el comportamiento actual del sistema

No comenzar a modificar código inmediatamente.

---

## Paso 2 — Identificar el alcance

Determinar exactamente qué parte del sistema será modificada.

Identificar:

* archivos afectados
* componentes afectados
* páginas afectadas
* APIs afectadas
* servicios afectados
* tablas o consultas afectadas
* reglas de negocio afectadas
* funcionalidades nuevas
* funcionalidades modificadas
* funcionalidades eliminadas

---

## Paso 3 — Crear un plan de implementación

Antes de modificar cualquier archivo, Codex debe presentar un **Plan de Implementación**.

El plan debe explicar claramente:

### Qué se va a modificar

Indicar:

* archivo
* componente
* función
* página
* API
* consulta
* tabla
* configuración

cuando corresponda.

### Qué se va a implementar

Describir las funcionalidades nuevas o el comportamiento que se agregará.

### Qué se va a modificar

Explicar qué comportamiento existente cambiará y por qué.

### Qué se va a borrar

Identificar explícitamente cualquier:

* archivo
* componente
* función
* endpoint
* campo
* tabla
* comportamiento

que se pretenda eliminar.

**Nunca ocultar eliminaciones dentro de un cambio mayor.**

### Impacto

Explicar qué otras partes del sistema podrían verse afectadas.

### Riesgos

Identificar posibles problemas relacionados con:

* datos
* compatibilidad
* usuarios existentes
* reglas de negocio
* seguridad
* rendimiento

---

## Paso 4 — Solicitar autorización

Después de presentar el Plan de Implementación, Codex debe **esperar autorización explícita antes de realizar los cambios**.

No modificar archivos todavía.

La autorización debe entenderse como la aprobación del plan propuesto.

Si el plan cambia significativamente después de la autorización, Codex debe detenerse y presentar el nuevo cambio antes de implementarlo.

---

## Paso 5 — Implementar

Una vez autorizado el plan:

* realizar únicamente los cambios aprobados
* mantener el alcance definido
* evitar modificaciones no relacionadas
* respetar todas las reglas de este archivo
* respetar las especificaciones

No aprovechar una tarea autorizada para realizar refactors o mejoras independientes.

---

## Paso 6 — Verificar

Después de implementar:

* revisar los cambios realizados
* verificar que coincidan con el plan
* comprobar TypeScript
* comprobar lint
* comprobar build
* ejecutar pruebas relevantes
* verificar reglas de negocio
* verificar navegación
* verificar estados de UI
* verificar integración con SQL Server

---

## Paso 7 — Reportar

Al finalizar, presentar:

1. Qué se modificó.
2. Qué se implementó.
3. Qué se eliminó.
4. Qué archivos fueron afectados.
5. Qué pruebas se realizaron.
6. Resultado de las pruebas.
7. Cualquier problema pendiente.
8. Cualquier diferencia entre el comportamiento original y el nuevo.

---

# 4. No negociables

## 4.1 Mantener la experiencia de usuario

La interfaz **sí puede modernizarse visualmente**.

Está permitido modificar:

* colores
* tipografías
* bordes
* sombras
* iconografía
* espaciado visual
* estilos de botones
* estilos de tablas
* estilos de formularios
* apariencia general
* diseño visual
* responsive design
* otros elementos puramente visuales

El objetivo es que la aplicación web pueda tener un aspecto moderno y profesional.

Sin embargo:

### NO se debe modificar la estructura funcional que los usuarios ya conocen.

No cambiar sin especificación explícita:

* orden de las opciones
* ubicación funcional de las acciones
* flujo de trabajo
* funcionamiento
* comportamiento
* navegación
* significado de botones
* propósito de campos
* relación entre pantallas
* pasos necesarios para realizar una operación
* reglas de interacción

La modernización visual **NO debe obligar a los usuarios actuales a volver a aprender el sistema**.

Un usuario que ya conoce el sistema original debe poder reconocer fácilmente:

* dónde está cada función
* dónde están los datos
* cómo realizar cada operación
* qué botón utilizar
* qué pasos seguir

La regla es:

> **Se puede modernizar la apariencia, pero no se debe cambiar la forma en que el usuario entiende y utiliza el sistema.**

---

# 5. Fidelidad al sistema original

El sistema original es una referencia fundamental para la migración.

Debe analizarse el comportamiento real del `.EXE` cuando sea necesario.

Para cada módulo se debe identificar:

* qué hace
* quién lo utiliza
* qué información muestra
* qué información recibe
* qué acciones permite
* qué validaciones realiza
* qué resultados produce
* qué errores puede producir
* qué otras partes del sistema afecta

No asumir que una función funciona de determinada manera solamente por el nombre que tiene.

Cuando sea posible, verificar su comportamiento real.

---

# 6. No inventar funcionalidades

Codex NO debe agregar funcionalidades que no estén:

* especificadas
* presentes en el sistema original
* explícitamente autorizadas

No agregar por iniciativa propia:

* filtros
* reportes
* botones
* campos
* dashboards
* automatizaciones
* permisos
* procesos
* validaciones
* cambios de flujo

Si se identifica una mejora potencial, debe proponerse por separado.

No implementarla automáticamente.

---

# 7. No eliminar funcionalidades

No eliminar funcionalidades del sistema original solamente porque:

* parecen antiguas
* parecen innecesarias
* podrían hacerse de otra manera
* no parecen utilizadas
* una alternativa parece mejor

Si una funcionalidad debe eliminarse, debe estar especificado o ser autorizado explícitamente.

---

# 8. Preservación de reglas de negocio

Las reglas de negocio existentes deben conservarse.

No modificar una regla simplemente para:

* simplificar código
* facilitar una consulta
* reducir complejidad
* mejorar UX
* seguir una práctica moderna

Si la aplicación web necesita modificar una regla existente, debe documentarse y autorizarse.

---

# 9. Especificaciones

Todas las especificaciones del proyecto se encuentran en este archivo `AGENTS.md`.

No asumir que existe un archivo externo llamado:

```text
specs.txt
```

o una carpeta:

```text
/specs
```

a menos que posteriormente se cree explícitamente.

Las especificaciones pueden describir:

* módulos
* pantallas
* flujos
* reglas de negocio
* datos
* usuarios
* permisos
* validaciones
* comportamiento
* migración
* excepciones
* criterios de aceptación

Cuando una especificación sea demasiado extensa para mantenerse razonablemente dentro de este archivo, Codex puede proponer dividirla en archivos separados.

---

# 10. Estructura de documentación

La documentación debe mantenerse lo más cercana posible a la estructura conceptual del sistema original.

La intención es que los programadores que desarrollaron el sistema `.EXE` puedan entender fácilmente la migración.

Antes de proponer una estructura nueva de documentación:

1. Analizar la estructura existente del sistema.
2. Identificar sus módulos.
3. Identificar sus procesos.
4. Identificar sus pantallas.
5. Identificar sus relaciones.
6. Proponer una estructura equivalente para la documentación web.

No crear una estructura excesivamente abstracta si dificulta relacionarla con el sistema original.

---

# 11. Estructura del proyecto web

La estructura de Next.js debe ser clara y mantenible.

Preferir una estructura que permita identificar fácilmente:

* módulos
* páginas
* componentes
* servicios
* acceso a datos
* tipos
* validaciones
* utilidades

La estructura debe favorecer que un desarrollador del sistema original pueda localizar rápidamente la parte equivalente en la aplicación web.

No realizar reorganizaciones masivas de carpetas sin necesidad.

---

# 12. Next.js

El proyecto utiliza **Next.js**.

No introducir Vite como herramienta principal del proyecto.

Utilizar las capacidades de Next.js cuando sean apropiadas, incluyendo:

* App Router
* Server Components
* Server Actions cuando corresponda
* Route Handlers
* middleware cuando sea necesario
* rendering del lado del servidor cuando sea apropiado

No utilizar una característica de Next.js únicamente por utilizarla.

La arquitectura debe mantenerse sencilla y coherente con las necesidades del sistema.

---

# 13. React / TypeScript

Utilizar React y TypeScript.

TypeScript debe mantenerse con tipado fuerte.

Evitar:

```ts
any
```

salvo que exista una justificación técnica clara.

No utilizar casts para ocultar errores:

```ts
as any
```

o equivalentes.

Preferir:

* tipos explícitos
* interfaces
* type aliases
* tipos derivados
* unions
* funciones correctamente tipadas

---

# 14. SQL Server

La base de datos utilizada por el sistema web es:

**SQL Server**

No sustituir SQL Server por otra base de datos.

Antes de modificar la base de datos:

1. Analizar el esquema actual.
2. Revisar tablas relacionadas.
3. Revisar relaciones.
4. Revisar constraints.
5. Revisar índices.
6. Revisar procedimientos almacenados cuando existan.
7. Revisar consultas existentes.
8. Revisar dependencias del sistema.

No realizar cambios destructivos sin autorización explícita.

---

# 15. Datos existentes

La migración debe considerar que pueden existir datos históricos importantes.

Nunca asumir que los datos existentes pueden:

* eliminarse
* transformarse destructivamente
* renombrarse
* ignorarse

sin analizar previamente las consecuencias.

Las modificaciones de datos deben tratarse con especial cuidado.

---

# 16. Seguridad

Nunca:

* exponer credenciales
* colocar secretos en el frontend
* hardcodear contraseñas
* confiar exclusivamente en validaciones del cliente
* permitir acceso a datos sin autorización
* saltarse controles de permisos

Las operaciones sensibles deben protegerse en la capa correspondiente del servidor.

---

# 17. Validaciones

Las validaciones existentes deben conservarse.

Cuando una validación sea una regla de negocio crítica, no depender exclusivamente del frontend.

El frontend puede proporcionar una buena experiencia de validación, pero la capa del servidor debe proteger las operaciones que lo requieran.

---

# 18. Manejo de errores

Los errores deben ser claros para el usuario.

No mostrar innecesariamente:

* stack traces
* consultas SQL
* credenciales
* detalles internos
* información técnica sensible

Los errores deben conservar información suficiente para debugging interno.

---

# 19. Estados de interfaz

Las pantallas que trabajen con datos deben considerar, cuando corresponda:

* loading
* vacío
* éxito
* error
* guardando
* deshabilitado
* validación
* sin permisos

No asumir que las consultas siempre devolverán información.

---

# 20. Rendimiento

Priorizar un sistema rápido y estable.

Evitar:

* consultas innecesarias
* consultas duplicadas
* peticiones repetidas
* renders innecesarios
* cargar datos que no se necesitan
* componentes excesivamente pesados

No realizar optimizaciones complejas sin una razón concreta.

---

# 21. Código

El código debe ser:

* claro
* mantenible
* predecible
* consistente
* fácil de entender por otros desarrolladores

Preferir soluciones simples antes que abstracciones innecesarias.

No realizar refactors que no estén relacionados con la tarea autorizada.

---

# 22. Comentarios

Los comentarios deben explicar principalmente:

* por qué existe una decisión
* reglas de negocio no evidentes
* workarounds
* limitaciones
* compatibilidad con el sistema original

No escribir comentarios que simplemente repitan lo que hace el código.

---

# 23. Cambios destructivos

Considerar como cambios destructivos:

* eliminar archivos
* eliminar componentes
* eliminar rutas
* eliminar endpoints
* eliminar columnas
* eliminar tablas
* modificar tipos de datos
* modificar relaciones
* modificar permisos
* cambiar autenticación
* eliminar funcionalidades

Estos cambios requieren una explicación específica en el Plan de Implementación y autorización antes de realizarse.

---

# 24. Regla de alcance

Una tarea autorizada solamente autoriza los cambios descritos en el Plan de Implementación.

No realizar cambios adicionales porque:

> "ya que estoy aquí..."

o porque:

> "sería mejor hacerlo así."

Si se encuentra otro problema:

1. documentarlo
2. explicarlo
3. proponerlo como cambio separado

---

# 25. Pruebas

Las pruebas deben verificar el comportamiento definido en las especificaciones.

Prioridad:

1. reglas de negocio
2. operaciones críticas
3. validaciones
4. permisos
5. flujos principales
6. integración con SQL Server
7. componentes importantes
8. detalles visuales

Cuando exista una pantalla equivalente en el sistema original, verificar que la versión web conserve el mismo flujo funcional.

---

# 26. Definition of Done

Una tarea no se considera terminada únicamente porque el código compile.

Debe cumplirse:

* [ ] Se revisó la especificación.
* [ ] Se analizó el código relacionado.
* [ ] Se identificó el alcance.
* [ ] Se presentó un Plan de Implementación.
* [ ] El plan fue autorizado.
* [ ] Se implementaron únicamente los cambios autorizados.
* [ ] Se respetó el comportamiento del sistema original.
* [ ] La interfaz mantiene la misma estructura funcional.
* [ ] La apariencia puede modernizarse sin alterar la experiencia.
* [ ] Las reglas de negocio están implementadas.
* [ ] Las validaciones funcionan.
* [ ] Los permisos son correctos.
* [ ] SQL Server funciona correctamente.
* [ ] No se agregaron funcionalidades no autorizadas.
* [ ] No se eliminaron funcionalidades sin autorización.
* [ ] TypeScript no presenta errores.
* [ ] Lint pasa.
* [ ] Build pasa.
* [ ] Las pruebas relevantes pasan.
* [ ] Se verificaron casos límite.
* [ ] Se documentaron problemas pendientes.

---

# 27. Protocolo ante ambigüedad

Si algo no está definido:

## Decisión menor

Puede utilizarse la solución que mejor coincida con:

1. el sistema original
2. las especificaciones existentes
3. los patrones del proyecto

Documentar la decisión cuando sea relevante.

## Decisión importante

No inventar.

Solicitar aclaración antes de implementar si puede afectar:

* reglas de negocio
* datos
* seguridad
* permisos
* flujo
* experiencia de usuario
* arquitectura
* compatibilidad
* integridad de datos

---

# 28. Mejoras y propuestas

Codex puede detectar oportunidades de mejora.

Sin embargo, detectar una mejora NO significa que esté autorizado implementarla.

Las propuestas deben separarse de la implementación solicitada.

Ejemplo:

```text
PROPUESTA NO IMPLEMENTADA

Se detectó que X podría mejorarse mediante Y.

No se implementó porque está fuera del alcance autorizado.
```

---

# 29. Comparación EXE → Web

Durante la migración, cuando sea posible, utilizar esta relación:

```text
Sistema original
      ↓
Módulo original
      ↓
Pantalla original
      ↓
Flujo original
      ↓
Reglas originales
      ↓
Equivalente web
```

Cada módulo migrado debe poder relacionarse fácilmente con su equivalente del sistema original.

El objetivo es facilitar la transición y mantenimiento por parte de los desarrolladores que ya conocen el sistema.

---

# 30. Principio fundamental

La migración debe seguir esta regla:

> **Modernizar la tecnología y la apariencia, no cambiar innecesariamente la forma de trabajar.**

El sistema web debe sentirse como una evolución del sistema original, no como un sistema completamente diferente.

La interfaz puede verse moderna.

La tecnología puede cambiar.

La arquitectura interna puede mejorar.

Pero los usuarios deben reconocer:

* sus pantallas
* sus opciones
* sus procesos
* sus datos
* sus botones
* sus flujos de trabajo

sin tener que reaprender el sistema.

---

# 31. Prioridad de decisiones

Cuando existan varias soluciones técnicas válidas, utilizar este orden:

1. Cumplimiento de la especificación.
2. Conservación del comportamiento original.
3. Conservación de la experiencia de usuario.
4. Integridad de los datos.
5. Seguridad.
6. Mantenibilidad.
7. Simplicidad.
8. Rendimiento.
9. Preferencias personales del agente.

---

# 32. Regla final para Codex

Codex debe comportarse como un ingeniero encargado de realizar una migración controlada.

No debe actuar como un diseñador de producto que decide qué debería hacer el sistema.

Antes de programar:

```text
ANALIZAR
   ↓
ENTENDER
   ↓
IDENTIFICAR ALCANCE
   ↓
PLAN DE IMPLEMENTACIÓN
   ↓
SOLICITAR AUTORIZACIÓN
   ↓
ESPERAR
```

Después de recibir autorización:

```text
IMPLEMENTAR
   ↓
VERIFICAR
   ↓
PROBAR
   ↓
REVISAR CONTRA EL PLAN
   ↓
REPORTAR RESULTADOS
```

Nunca saltarse la etapa de autorización para cambios significativos.
