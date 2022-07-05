import React from 'react'
import TitlePage from '../../components/TitlePage'
import RentItem from './RentItem'

export default function RentList(props) {
  return (
    <>
      <TitlePage title={'Todos as locações'} />

      <div className='mt-3'>
        {props.rents.map(r => (
          <RentItem
            key={r.id}
            r={r}
            editRent={props.editRent}
            handleConfirmModal={props.handleConfirmModal}
          />
        ))}
      </div>
    </>
  )
}
