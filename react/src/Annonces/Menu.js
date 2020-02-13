import React from "react";
import {Link} from "react-router-dom"
export const Menu = (props) => {
    return(
        <header className="container-fluid">
            <nav className="row">
                <li className="col">
                    <Link to="/">Accueil</Link>
                </li>
                <li className="col">
                    <Link to="/Add">Ajouter une annonce</Link>
                </li>
            </nav>
        </header>
    )
}