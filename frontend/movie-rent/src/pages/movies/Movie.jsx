import { useState, useEffect } from "react";
import MovieList from './MovieList';
import api from "../../api/movierent";
import { Button, Modal } from "react-bootstrap";
import TitlePage from "../../components/TitlePage";
import { CheckCircle, Plus, XCircle } from "phosphor-react";
import MovieForm from "./MovieForm";

function Movie() {
  const [showMovieModal, setShowMovieModal] = useState(false);
  const [smshowConfirmModal, setSmshowConfirmModal] = useState(false);
  const [movies, setMovies] = useState([]);
  const [movie, setMovie] = useState({ id: 0 });

  const handleMovieModal = () => setShowMovieModal(!showMovieModal);

  const handleConfirmModal = (id) => {
    if (id !== 0 && id !== undefined) {
      const movie = movies.filter((m) => m.id === id);
      setMovie(movie[0]);
    } else {
      setMovie({ id: 0 });
    }
    setSmshowConfirmModal(!smshowConfirmModal);
  };

  const getMovies = async () => {
    const response = await api.get("Movie/read/all");
    return response.data;
  };

  const newMovie = () => {
    setMovie({ id: 0 });
    handleMovieModal();
  };

  useEffect(() => {
    const catchMovies = async () => {
      const all = await getMovies();
      if (all) setMovies(all);
    };
    catchMovies();
  }, []);

  const addMovie = async (m) => {
    handleMovieModal();
    const response = await api.post("Movie/new", m);
    setMovies([...movies, response.data]);
  };

  const deleteMovie = async (id) => {
    handleConfirmModal(0);
    if (await api.delete(`Movie/delete/${id}`)) {
      const moviesFilter = movies.filter((m) => m.id !== id);
      setMovies([...moviesFilter]);
    }
  };

  const cancelMovie = () => {
    setMovie({ id: 0 });
    handleMovieModal();
  };

  const updateMovie = async (m) => {
    handleMovieModal();
    const response = await api.put("Movie/update/", m);
    const { id } = response.data;
    setMovies(movies.map((item) => (item.id === id ? response.data : item)));
    setMovie({ id: 0 });
  };

  const editMovie = (id) => {
    const movie = movies.filter((m) => m.id === id);
    setMovie(movie[0]);
    handleMovieModal();
  };

  return (
    <>
      <TitlePage>
        <Button variant="primary" onClick={newMovie}>
          <Plus size={22} weight="bold" />
        </Button>
      </TitlePage>

      <MovieList
        movies={movies}
        editMovie={editMovie}
        handleConfirmModal={handleConfirmModal}
      />

      <Modal show={showMovieModal} onHide={handleMovieModal}>
        <Modal.Header closeButton>
          <Modal.Title>Cliente</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <MovieForm
            addMovie={addMovie}
            cancelMovie={cancelMovie}
            updateMovie={updateMovie}
            movieSelected={movie}
            movies={movies}
          />
        </Modal.Body>
      </Modal>

      <Modal size="sm" show={smshowConfirmModal} onHide={handleConfirmModal}>
        <Modal.Header closeButton>
          <Modal.Title>Excluir Filme</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Tem certeza que deseja excluir o filme {movie.title}?
        </Modal.Body>
        <Modal.Footer className="d-flex justify-content-between">
          <button
            className="btn btn-outline-success me-2"
            onClick={() => deleteMovie(movie.id)}>
            <CheckCircle size={20} weight="bold" />
          </button>

          <button
            className="btn btn-danger me-2"
            onClick={() => handleConfirmModal(0)}>
            <XCircle size={20} weight="bold" />
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default Movie;
