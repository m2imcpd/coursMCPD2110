import React, {useState, useEffect} from "react"

export const Client = (props) => {
    return(
        <div>
            <div> Nom : {props.nom}</div>
            <div> Prénom : {props.prenom}</div>
            <div> Téléphone : {props.telephone}</div>
        </div>
    )
}