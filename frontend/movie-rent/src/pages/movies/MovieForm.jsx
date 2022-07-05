import { useState, useEffect } from 'react'

const initialMovie = {
    id: 0,
    title: '',
    classification: '',
    type: ''
}

export default function MovieForm(props) {
    const [movie, setMovie] = useState(currentMovie());

    useEffect(() => {
        if (props.movieSelected.id !== 0)
            setMovie(props.movieSelected);
    }, [props.movieSelected]);

    const inputTextHandler = (e) => {
        const { name, value } = e.target;

        setMovie({ ...movie, [name]: value })
    }

    function currentMovie() {
        if (props.movieSelected.id !== 0) {
            return props.movieSelected;
        }
        else {
            return initialMovie;
        }
    }

    const handleSubmit = (e) => {
        e.preventDefault();

        if (props.movieSelected.id !== 0)
            props.updateMovie(movie)
        else
            props.addMovie(movie);

        setMovie(initialMovie);
    }

    const handleCancel = (e) => {
        e.preventDefault();
        props.cancelMovie();

        setMovie(initialMovie);
    }

    return (
        <>
            <form className='row g-3' onSubmit={handleSubmit}>
                <div className="col-md-6">
                    <label className="form-label">Titulo</label>
                    <input
                        name="title"
                        value={movie.title}
                        onChange={inputTextHandler}
                        id="title"
                        type="text"
                        className="form-control"
                    />
                </div>

                <div className="col-md-6">
                    <label className="form-label">Classificação</label>
                    <input
                        name="classification"
                        value={movie.classification}
                        onChange={inputTextHandler}
                        id="classification"
                        type="number"
                        className="form-control"
                    />
                </div>

                <div className="col-md-6">
                    <label className="form-label">Tipo</label>
                    <select
                        name="type"
                        value={movie.type}
                        onChange={inputTextHandler}
                        id="type"
                        type="text"
                        className="form-select"
                    >
                        <option defaultValue="Não definido">Selecionar</option>
                        <option value="Release">Lançamento</option>
                        <option value="Classic">Clássico</option>
                    </select>
                    <br />
                </div>

                <div className="col-12 mt-0">
                    {
                        movie.id === 0 ?
                            <button
                                className="btn btn-outline-success position: relative"
                                type='submit'
                            >
                                Salvar
                            </button>
                            :
                            <>
                                <button
                                    className="btn btn-outline-success position: relative me-2"
                                    type='submit'
                                >
                                    Salvar
                                </button>
                                <button
                                    className="btn btn-outline-warning position: relative me-2"
                                    onClick={handleCancel}
                                >
                                    Cancelar
                                </button>
                            </>
                    }
                </div>
            </form>
        </>

    )
}
