import React from 'react'
import TitlePage from '../../components/TitlePage';
import MovieItem from './MovieItem'

export default function MovieList(props) {
    return (
        <>
            <TitlePage title={'Todos os filmes'} />

            <div className='mt-3'>
                {props.movies.map(m => (
                    <MovieItem
                        key={m.id}
                        m={m}
                        editMovie={props.editMovie}
                        handleConfirmModal={props.handleConfirmModal}
                    />
                ))}
            </div>
        </>
    );
}
