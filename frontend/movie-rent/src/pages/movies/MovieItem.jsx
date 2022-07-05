import { PencilSimple, Trash } from 'phosphor-react'
import React from 'react'

export default function MovieItem(props) {
  return (
    <div className="card mb-2 shadow-sm" >
      <div className="card-body">

        <div className="card-text">
          <strong>Título:</strong> {props.m.title} <br />
          <strong>Classificação:</strong>  {props.m.classification} <br />
          <strong>Tipo:</strong> {props.m.type}
        </div>
        <div className='d-flex justify-content-end pt-2 m-0'>
          <button
            className="btn  btn-sm btn-outline-primary me-2"
            onClick={() => props.editMovie(props.m.id)}>
            < PencilSimple size={18} weight="bold" />
          </button>
          <button
            className="btn btn-sm btn-outline-danger me-2"
            onClick={() => props.handleConfirmModal(props.m.id)}>
            < Trash size={18} weight="bold" />
          </button>
        </div>
      </div>
    </div>
  )
}
