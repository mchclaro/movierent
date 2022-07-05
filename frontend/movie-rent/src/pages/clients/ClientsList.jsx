import React from 'react'
import TitlePage from '../../components/TitlePage'
import ClientItem from './ClientItem'

export default function ClientsList(props) {
  return (
    <>
      <TitlePage title={'Todos os clientes'} />

      <div className='mt-3'>
        {props.clients.map(c => (
          <ClientItem
            key={c.id}
            c={c}
            editClient={props.editClient}
            handleConfirmModal={props.handleConfirmModal}
          />
        ))}
      </div>
    </>
  )
}
