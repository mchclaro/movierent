import React from 'react'
import TitlePage from '../../components/TitlePage'
import { Laptop } from "phosphor-react";

export default function Home() {
    return (
        <>
            <TitlePage title='Home' />
            <div class="card text-center">
                <div class="card-header" card text-bg-dark mb-3>
                    <ul class="nav nav-tabs bg-info">
                        <li class="nav-item">
                            <a class="nav-link active ms-2 me-2">Descrição do Projeto</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link me-2" href="https://github.com/mchclaro/movierent">GitHub do Projeto</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="https://www.linkedin.com/in/michel-claro/">Meu LinkedIn</a>
                        </li>
                    </ul>
                </div>
                <div class="card-body">
                    <h5 class="card-title">Uma breve descrição...</h5>
                    <p class="card-text"> Este projeto foi desenvolvido como umas das etapas de entrevista da empresa <strong>e-AUDITORIA.</strong>
                        <br />
                        No qual foi feito uma Web Api em .NET 6.0 com C# utilizando EF e o banco de dados MySql, o seu frontend foi
                        criado utilizando ReactJs.
                        <br />
                        Estou fazendo este projeto para uma vaga de <strong>Desenvolvedor Fullstack <Laptop size={20} weight="bold" /></strong>
                         </p>
                </div>
            </div>

        </>
    )
}
