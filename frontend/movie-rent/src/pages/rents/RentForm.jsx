import { useEffect, useState } from 'react'

const initialRent = {
  id: 0,
  name: '',
  cpf: '',
  birthdate: ''
}

export default function RentForm(props) {
  const [rent, setRent] = useState(currentRent());


  useEffect(() => {
    if (props.rentSelected.id !== 0)
      setRent(props.rentSelected);
  }, [props.rentSelected]);

  const inputTextHandler = (e) => {
    const { name, value } = e.target;

    setRent({ ...rent, [name]: value })
  }

  function currentRent() {
    if (props.rentSelected.id !== 0) {
      return props.rentSelected;
    }
    else {
      return initialRent;
    }
  }

  const handleSubmit = (e) => {
    e.preventDefault();

    if (props.rentSelected.id !== 0)
      props.updateRent(rent)
    else
      props.addRent(rent);

    setRent(initialRent);
  }

  const handleCancel = (e) => {
    e.preventDefault();
    props.cancelRent();

    setRent(initialRent);
  }

  return (
    <>
      <form className='row g-3' onSubmit={handleSubmit}>
        <div className="col-md-6">
          <label className="form-label">Cliente</label>
          <input
            name="client"
            value={rent.client}
            onChange={inputTextHandler}
            id="client"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Filme</label>
          <input
            name="movie"
            value={rent.movie}
            onChange={inputTextHandler}
            id="movie"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Data de Locação</label>
          <input
            name="rentalDate"
            value={rent.rentalDate}
            onChange={inputTextHandler}
            id="rentalDate"
            type="date"
            className="form-control"
          />
        </div>
      
        <div className="col-md-6">
          <label className="form-label">Data de Devolução</label>
          <input
            name="returnDate"
            value={rent.returnDate}
            onChange={inputTextHandler}
            id="returnDate"
            type="date"
            className="form-control"
          />
          <br />
        </div>

        <div className="col-12 mt-0">
          {
            rent.id === 0 ?
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
