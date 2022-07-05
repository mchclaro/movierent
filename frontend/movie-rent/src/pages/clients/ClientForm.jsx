import { useEffect, useState } from 'react'

const initialClient = {
  id: 0,
  name: '',
  cpf: '',
  birthdate: ''
}

export default function ClientForm(props) {
  const [client, setClient] = useState(currentClient());

  
  useEffect(() => {
    if (props.clientSelected.id !== 0)
      setClient(props.clientSelected);
  }, [props.clientSelected]);

  const inputTextHandler = (e) => {
    const { name, value } = e.target;

    setClient({ ...client, [name]: value })
  }

  function currentClient() {
    if (props.clientSelected.id !== 0) {
      return props.clientSelected;
    }
    else {
      return initialClient;
    }
  }

  const handleSubmit = (e) => {
    e.preventDefault();

    if (props.clientSelected.id !== 0)
      props.updateClient(client)
    else
      props.addClient(client);

    setClient(initialClient);
  }

  const handleCancel = (e) => {
    e.preventDefault();
    props.cancelClient();

    setClient(initialClient);
  }

  return (
    <>
      <form className='row g-3' onSubmit={handleSubmit}>
        <div className="col-md-6">
          <label className="form-label">Nome</label>
          <input
            name="name"
            value={client.name}
            onChange={inputTextHandler}
            id="name"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">CPF</label>
          <input
            name="cpf"
            value={client.cpf}
            onChange={inputTextHandler}
            id="cpf"
            type="text"
            className="form-control"
          />
        </div>

        <div className="col-md-6">
          <label className="form-label">Data de Nascimento</label>
          <input
            name="birthdate"
            value={client.birthdate}
            onChange={inputTextHandler}
            id="birthdate"
            type="text"
            className="form-control"
          />
          <br />
        </div>

        <div className="col-12 mt-0">
          {
            client.id === 0 ?
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
