import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Biblioteca Babel</h1>
        <p><b>Guillermo Fabian Padila Lam</b>, segunda parte del examen.</p>

            <p> La primera parte contiene todo el back-end, utilizando Entityframework code-first, migrations, Repository pattern, unit of work pattern, tareas asincronas, arquitectura en capas con Injeccion de dependencias, e incluye los end-points para el acceso a los metodos de persistencia de datos. </p>

            <p> Esta segunda parte esta enfocada al front-end con React, se muestra la creacion de dos componentes: FetchBook para consultar todos los libros y el componente AddBook que se utiliza para ingresar nuevos libros y para actualizar libros ya existentes. Tambien se muestra la opcion para eliminar un Libro desde el grid de la consulta.</p>
            <p> El objetivo principal es el de mostrar la creacion de los componentes, el manejos del state, el flujo de los controles (como el componenDidMound) y la comunicacion con el back-end usando promises y llamadas asincronas con fetch de typescript. </p>
            <p><b> El objetivo es el de mostrar el manejo de React, no se realiza persistencia de datos, eso esta en la parte 1.</b></p>
        </div>
    );
  }
}
