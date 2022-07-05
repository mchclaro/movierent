import { PencilSimple, Trash } from 'phosphor-react'
import React from 'react'

export default function RentItem(props) {
  return (
    <div className="card mb-2 shadow-sm" >
      <div className="card-body">

        <div className="card-text">
          <strong>Cliente:</strong> {props.r.client} <br/>
          <strong>Filme:</strong>  {props.r.movie} <br/>
          <strong>Data de Locação:</strong> {props.r.rentalDate} <br/>
          <strong>Data de Devolução:</strong> {props.r.returnDate} 
        </div>
        <div className='d-flex justify-content-end pt-2 m-0'>
          <button 
          className="btn  btn-sm btn-outline-primary me-2"
            onClick={() => props.editRent(props.r.id)}>
            < PencilSimple size={18} weight="bold" />
          </button>
          <button
            className="btn btn-sm btn-outline-danger me-2"
            onClick={() => props.handleConfirmModal(props.r.id)}>
            < Trash size={18} weight="bold" />
          </button>
        </div>
      </div>
    </div>
  )
}
