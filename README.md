## XMLGenerator
---
Crear hoja de configuracion XML para entities al realizar el cambio. Facilita la conversion de los maestros a entities.

### Table of contents
1. [Validaciones y TODO](#validacionestodo)
2. [Funcionamiento](#funcionamiento)
3. [Vistas](#vistas)
4. [Impresion](#impresion)
5. [Exception Buttons](#exceptionbuttons)
6. [Columnas](#columnas)

![alt text](https://github.com/Xelarey97/XMLGenerator/blob/master/img/program.png?raw=true)

<div id="validacionestodo"/>

## Validaciones 


1. No se puede dejar ningún campo en blanco excepto los botones de búsqueda que son opcionales.
2. Al dejarte cualquiera de los campos obligatorios sin rellenar saltará una excepción indicando cual es el campo que falta.

## TODO
1. Falta por poder seleccionar la carpeta donde se desa guardar el archivo, de momento para poder ser usado se tendrá que cambiar el directorio que viene hardcoded antes de compilar.
2. Añadir un check para indicar si el filtro es obligatorio u opcional.

<div  id="funcionamiento"/>

## Funcionamiento (Campos)

**Entidad** : Aquí irá el nombre de la entidad que hemos debido crear anteriormente.
```
Ejemplo: DGEST.Presentation.Entities.Inmueblesv2.GestionChequeEfectivo
```

<div id="vistas"/>

## Vista

**Caption**: Indicaremos el nombre del archivo de traducción de los campos que se muestren en el grid.
```
Ejemplo: EntNotarioRequest
```

**Recurso**: Nombre del recurso (imagen) que mostrará el maestro.
```
Ejemplo: Notario_32
```

**MDIBusqueda**: Indicaremos el MDI correspondiente utilizado para realizar las búsquedas.
```
Ejemplo: BuscaNotario
```

**MDIEdita**: Indicaremos el MDI correspondiente utilizado para poder modificar.
```
Ejemplo: EditaNotario
```

**AutoSize**: Entre True o False, indica si se ajustará automáticamente el grid de busqueda.

<div id="impresion"/>

## Impresión

**Caption**: Indica la traducción del título del report del maestro en cuestión.
```
Ejemplo: Report_ListadoNotario_Titulo
```

**TipoReport**: Nombre del report del maestro que estemos modificando.
```
Ejemplo: BusquedaNotario
```

**Engine**: Nombre del motor de creación del report. Solo tiene 2 valores.
```
Ejemplo: AR
```

<div id="exceptionbuttons"/>

## Exception Buttons

### BeforeBusqueda y AfterBusqueda

> Dependiendo de si queremos que se un botón este habilitado antes o despues de la busqueda tendremos que indicar la acción y el valor.
Para deshabilitar el botón antes de realizar la búsqueda, añadiremos la acción en BeforeBusqueda y si queremos que sea después lo añadiremos en AfterBusqueda. Se puede añadir la misma acción en ambos lados.

**Clave**: Aquí añadiremos el valor de la acción, normalmente solo són 2, pero pueden haber personalizadas, por eso el ComboBox en cuestión es editable.
```
Ejemplo: AccionNuevo
```

**Valor**: Alterna entre True o False para indicar si los botones estarán habilitados.

<div id="columnas"/>

## Columnas

>Según las columnas que muestre el grid de la búsqueda tendremos que añadir más o menos.

**Campo**: Indicaremos el campo que queremos que se muestre. Suele estar relacionado con el nombre que aparece en el Request del maestro.
```
Ejemplo: Procedencia (Segun el request)
```

**Width**: Ancho de la columna del grid. Si el valor no es numérico saltará un error. Tampoco acepta comas.
```
Ejemplo: 250
```

**Format Text**: Formato del texto que queremos mostrar. Podemos intercambiar entre custom y enumeration principalmente.
```
Ejemplo: Enumeration / Custom
```

**Enumerable**: Si en la opción anterior hemos indicado "Enumerable", **no se debe** añadir el campo de "ConverterType".
```
Ejemplo: Shared.Tipos.Inmuebles.TipoSolicitud
```

**Enumerable**: Si en la opción anterior hemos indicado "Custom", **no se debe** añadir el campo de "Enumerable".
```
Ejemplo: DGEST.Presentation.Entities.Converters.ShortDatetimeConverter
```