import React, { Component } from 'react';


export class AddBook extends Component {
    static displayName = AddBook.name;

    constructor(props) {
        super(props);
        this.state = { id: 0, noVolumen: "", descripcion: "", loading: true, modeEdit: false };

    }

    componentDidMount() {

        var bookId = window.location.href.match(/(\d+)$/g);

        if (bookId > 0) {
            this.populateEditData(bookId);
        }
        else {
            this.setState({
                modeEdit: false,
                loading: false
            });
        }
    }

    async populateEditData(bookId) {

        const response = await fetch('/Book/GetById/' + bookId);

        const data = await response.json();

        this.setState({
            id: data[0].id,
            noVolumen: data[0].noVolumen,
            descripcion: data[0].descripcion,
            loading: false,
            modeEdit: true
        });
    }

    handleUpdate = () => {

        var newBook = JSON.stringify({
            id: this.state.id,
            noVolumen: this.state.noVolumen,
            descripcion: this.state.descripcion
        });

        if (this.state.modeEdit) {
            fetch('/Book/Update', {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: newBook,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetch-book");
                });
        }
        else {
            fetch('/Book/Create', {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: newBook,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/fetch-book");
                });
        }
    }

    updateInputValue = (evt, source) => {
        this.setState({
            [source]: evt.target.value
        });
    }

    handleCancel = () => {
        this.props.history.push("/fetch-book/");
    }

    render() {

        let title = this.state.modeEdit ? "Actualizar libro" : "Ingresar nuevo libro";

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <div>
                <div className="form-group row" >
                    <input type="hidden" name="id" value={this.state.id} />
                </div>

                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="NoVolumen">No Volumen</label>
                    <div className="col-md-4">
                        <input
                            className="form-control"
                            type="text"
                            name="NoVolumen"
                            value={this.state.noVolumen}
                            onChange={e => this.updateInputValue(e, "noVolumen")}
                            required />
                    </div>
                </div >

                <div className="form-group row" >
                    <label className=" control-label col-md-12" htmlFor="Descripcion">Descripcion</label>
                    <div className="col-md-4">
                        <input
                            className="form-control"
                            type="text"
                            name="Descripcion"
                            value={this.state.descripcion}
                            onChange={e => this.updateInputValue(e, "descripcion")}
                            required />
                    </div>
                </div >

                <div className="form-group">
                    <button className="btn btn-default" onClick={() => this.handleUpdate()} >Save</button>
                    <button className="btn" onClick={() => this.handleCancel()}>Cancel</button>
                </div >
            </div>

        return (
            <div>
                <h1 id="tabelLabel" >{title}</h1>
                <p>.</p>
                {contents}
            </div>
        );
    }    
}
