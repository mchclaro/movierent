import React from 'react'
import { PencilSimple, Trash } from 'phosphor-react'

export default function ClientItem(props) {
  return (
    <div className="card mb-2 shadow-sm" >
      <div className="card-body">

        <div className="card-text">
          <strong>Nome:</strong> {props.c.name} <br />
          <strong>CPF:</strong>  {props.c.cpf} <br />
          <strong>Data de Nascimento:</strong> {props.c.birthdate}
        </div>
        <div className='d-flex justify-content-end pt-2 m-0'>
          <button
            className="btn  btn-sm btn-outline-primary me-2"
            onClick={() => props.editClient(props.c.id)}>
            < PencilSimple size={18} weight="bold" />
          </button>
          <button
            className="btn btn-sm btn-outline-danger me-2"
            onClick={() => props.handleConfirmModal(props.c.id)}>
            < Trash size={18} weight="bold" />
          </button>
        </div>
      </div>
    </div>
  )
}
