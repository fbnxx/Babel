import React, { Component } from 'react';

export class FetchBook extends Component {
    static displayName = FetchBook.name;

    constructor(props) {
        super(props);
        this.state = { books: [], loading: true };

    }

    componentDidMount() {
        this.populateBooksData();
    }

    handleDelete = (id) => {
        
            fetch('book/Delete/' + id, {
                method: 'delete'
            }).then(data => {
                this.setState(
                    {
                        empList: this.state.books.filter((rec) => {
                            return (rec.id !== id);
                        })
                    });
            });
        
    }
    handleEdit = id => {
        this.props.history.push("/add-book/" + id);
    }  

    static renderBooksTable(books, handleDelete, handleEdit) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>No Volumen</th>
                        <th>Descripcion</th>
                    </tr>
                </thead>
                <tbody>
                    {books.map(book =>
                        <tr key={book.id}>
                            <td>{book.id}</td>
                            <td>{book.noVolumen}</td>
                            <td>{book.descripcion}</td>
                            <td>
                                <a className="action" onClick={(id) => handleEdit(book.id)}>Editar</a>  |
                                <a className="action" onClick={(id) => handleDelete(book.id)}>Borrar</a>
                            </td> 
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchBook.renderBooksTable(this.state.books, this.handleDelete, this.handleEdit);

        return (
            <div>
                <h1 id="tabelLabel" >Books</h1>
                <p>Este componente (fetchBook.js) consulta todos los libros usando el endpoint GetAll de BookController.</p>
                {contents}
            </div>
        );
    }

    async populateBooksData() {
        const response = await fetch('/Book/GetAll');
        
        const data = await response.json();
        console.log("+++ :: ", data);
        this.setState({ books: data, loading: false });
    }
}

